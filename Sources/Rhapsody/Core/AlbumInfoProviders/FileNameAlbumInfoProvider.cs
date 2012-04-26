using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Rhapsody.Utilities;

namespace Rhapsody.Core.AlbumInfoProviders
{
    internal class FileNameAlbumInfoProvider : IAlbumInfoProvider
    {
        public string Name
        {
            get
            {
                return "File and Folder Name";
            }
        }

        public Image Icon
        {
            get
            {
                return null;
            }
        }

        public AlbumInfo GetAlbumInfo(Album album, Session session, Context context)
        {
            var albumInfo = new AlbumInfo();
            var directoryName = album.SourceDirectory.Parent.Name + @"\" + album.SourceDirectory.Name;

            var formats = new[]
            {
                new Regex(@"^.*\\(?<artist>.*)-(?<album>.*)-.*-(?<year>\d{4})$"),
                new Regex(@"^.*\\(?<artist>.*)-( )*(?<album>.*)( )*\(?(?<year>\d{4})\)?$"),
                new Regex(@"^.*\\(?<artist>.*)-( )*(?<year>\d{4})( )*-(?<album>.*)$"),
                new Regex(@"^(?<artist>.*)\\(?<year>\d{4}) - (?<album>.*)$"),
                new Regex(@"^(?<artist>.*)\\(?<album>.*)$")
            };

            foreach (var format in formats)
            {
                var match = format.Match(directoryName);

                if (match.Success)
                {
                    albumInfo.ArtistName = StringHelper.Normalize(match.Groups["artist"].Value);
                    albumInfo.Name = StringHelper.Normalize(match.Groups["album"].Value);
                    albumInfo.ReleaseYear = StringHelper.Trim(match.Groups["year"].Value);
                    break;
                }
            }

            foreach (var disc in album.Discs)
            {
                albumInfo.DiscNames[disc] = null;

                var discTrackNames = new Dictionary<Track, string>();

                foreach (var track in disc.Tracks)
                    discTrackNames[track] = Path.GetFileNameWithoutExtension(track.SourceFile.Name).Replace("_", " ");

                TrimLeft(discTrackNames);
                TrimRight(discTrackNames);

                foreach (var pair in new Dictionary<Track, string>(albumInfo.TrackNames))
                    discTrackNames[pair.Key] = StringHelper.MakeProperCase(StringHelper.Trim(pair.Value));

                foreach (var pair in discTrackNames)
                    albumInfo.TrackNames[pair.Key] = pair.Value;
            }

            var imageFiles = album.SourceDirectory.EnumerateFilesEx(@"\.jpg|\.png|\.gif").ToArray();
            var coverImageFile = SelectCoverImage(imageFiles, albumInfo);

            if (coverImageFile != null)
                albumInfo.Cover = Picture.Load(coverImageFile.FullName);

            return albumInfo;
        }

        private static FileInfo SelectCoverImage(IEnumerable<FileInfo> imageFiles, AlbumInfo albumInfo)
        {
            var cachedImageFiles = imageFiles.Cache();

            var patterns = new List<Regex>();
            patterns.Add(new Regex(@"cover", RegexOptions.IgnoreCase));
            patterns.Add(new Regex(@"front", RegexOptions.IgnoreCase));

            if (albumInfo.Name != null)
                patterns.Add(new Regex(Regex.Escape(albumInfo.Name), RegexOptions.IgnoreCase));

            foreach (var pattern in patterns)
                foreach (var imageFile in cachedImageFiles)
                    if (pattern.IsMatch(imageFile.Name))
                        return imageFile;

            return null;
        }

        private static void TrimLeft(Dictionary<Track, string> trackNames)
        {
            if (trackNames.Count < 2)
                return;

            while (true)
            {
                if (trackNames.Values.Any(trackName => trackName.Length == 0))
                    return;

                var areAllFirstCharsEqual = trackNames.Values.AllEqual(trackName => trackName.First());
                var areAllFirstCharsDigit = trackNames.Values.All(trackName => char.IsDigit(trackName.First()));

                if (!areAllFirstCharsEqual && !areAllFirstCharsDigit)
                    break;

                foreach (var pair in new Dictionary<Track, string>(trackNames))
                    trackNames[pair.Key] = pair.Value.Remove(0, 1);
            }
        }

        private static void TrimRight(Dictionary<Track, string> trackNames)
        {
            if (trackNames.Count < 2)
                return;

            while (true)
            {
                if (trackNames.Values.Any(trackName => trackName.Length == 0))
                    return;

                var areAllLastCharsEqual = trackNames.Values.AllEqual(trackName => trackName.Last());

                if (!areAllLastCharsEqual)
                    break;

                var lastChar = trackNames.First().Value.Last();

                if (lastChar == ')')
                    break;

                foreach (var pair in new Dictionary<Track, string>(trackNames))
                    trackNames[pair.Key] = pair.Value.Remove(pair.Value.Length - 1, 1);
            }
        }
    }
}
