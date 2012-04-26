using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Rhapsody.Core.Mpeg;
using Rhapsody.Properties;
using Rhapsody.Utilities;

namespace Rhapsody.Core
{
    internal class Disc
    {
        private Context _context;
        private Session _session;

        public event EventHandler NameChanged;

        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get
            {
                var fullName = string.Format("Disc {0}", Index);

                if (!string.IsNullOrEmpty(Name))
                    fullName += " - " + Name;

                return fullName;
            }
        }

        public string DirectoryName
        {
            get
            {
                return StringHelper.MakeFileSystemFriendly(FullName);
            }
        }

        public List<Track> Tracks
        {
            get;
            private set;
        }

        public Album Album
        {
            get;
            private set;
        }

        public int Index
        {
            get
            {
                return Album.Discs.IndexOf(this) + 1;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return Tracks.Aggregate(TimeSpan.Zero, (current, track) => current + track.MpegFileInfo.Duration);
            }
        }

        public int? MostCommonBitrate
        {
            get
            {
                return Tracks.Where(track => !track.MpegFileInfo.IsVbr).MostCommon(track => track.MpegFileInfo.Bitrate);
            }
        }

        public int? MostCommonSampleRate
        {
            get
            {
                return Tracks.MostCommon(track => track.MpegFileInfo.SampleRate);
            }
        }

        public ChannelMode? MostCommonChannelMode
        {
            get
            {
                return Tracks.MostCommon(track => track.MpegFileInfo.ChannelMode);
            }
        }

        private Disc()
        {
            Tracks = new List<Track>();
        }

        private Disc(Session session, Context context) : this()
        {
            _session = session;
            _context = context;
        }

        public Disc(Album album, Session session, Context context) : this(session, context)
        {
            Album = album;
        }

        public void SaveTo(DirectoryInfo albumDirectory, IProgress progress, CancellationToken cancellationToken)
        {
            var discDirectory = Album.Discs.Count == 1 ? albumDirectory : albumDirectory.CreateSubdirectory(DirectoryName);

            foreach (var track in Tracks)
            {
                cancellationToken.ThrowIfCancellationRequested();

                progress.Advance(string.Format(@"{0}\{1}", FullName, track.Name));

                track.SaveTo(discDirectory, progress, cancellationToken);
            }

            if (_session.Album.Cover != null)
            {
                var coverFilePath = Path.Combine(discDirectory.FullName, "Cover" + Picture.GetExtensionByMimeType(_session.Album.Cover.MimeType));

                File.WriteAllBytes(coverFilePath, _session.Album.Cover.Data);
            }

            if (Album.Discs.Count > 1)
                GeneratePlaylist(discDirectory);
        }

        private void GeneratePlaylist(DirectoryInfo discDirectory)
        {
            if (Settings.Default.NoPlaylist)
                return;

            var filename = Path.Combine(discDirectory.FullName, string.Format("@ {0} - {1} ({2}).m3u", StringHelper.MakeFileSystemFriendly(Album.Name), StringHelper.MakeFileSystemFriendly(FullName), Album.ReleaseYear));

            using (Stream stream = File.Open(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                var writer = new StreamWriter(stream);

                writer.WriteLine("#EXTM3U");

                foreach (var track in Tracks)
                {
                    writer.WriteLine("#EXTINF:{0},{1} - {2}", track.MpegFileInfo.Duration.TotalSeconds, Album.ArtistName, track.Name);
                    writer.WriteLine(track.FileName);
                }

                writer.Flush();
            }
        }

        public void Remove()
        {
            Album.Discs.Remove(this);
        }

        public void OnNameChanged()
        {
            if (NameChanged != null)
                NameChanged(this, EventArgs.Empty);
        }
    }
}
