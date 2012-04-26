using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Rhapsody.Properties;
using Rhapsody.Utilities;

namespace Rhapsody.Core
{
    internal class Album
    {
        private Context _context;
        private Session _session;

        public event EventHandler ArtistNameChanged;
        public event EventHandler NameChanged;
        public event EventHandler YearChanged;
        public event EventHandler TypeChanged;
        public event EventHandler CoverChanged;

        public string ArtistName
        {
            get;
            set;
        }

        public string ArtistDirectoryName
        {
            get
            {
                return StringHelper.MakeFileSystemFriendly(ArtistName);
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get
            {
                var fullName = Name;
                var marks = GetMarksString();

                if (marks != null)
                    fullName += " " + marks;

                return fullName;
            }
        }

        public string AlbumDirectoryName
        {
            get
            {
                var albumDirectoryName = string.Format("{0} - {1}", ReleaseYear, StringHelper.MakeFileSystemFriendly(Name));
                var marks = GetMarksString();

                if (marks != null)
                    albumDirectoryName += " " + marks;

                return albumDirectoryName;
            }
        }

        public DirectoryInfo AlbumDirectory
        {
            get;
            private set;
        }

        public string ReleaseYear
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public Picture Cover
        {
            get;
            set;
        }

        public List<Disc> Discs
        {
            get;
            private set;
        }

        public DirectoryInfo SourceDirectory
        {
            get;
            private set;
        }

        public FileInfo PlaylistFile
        {
            get;
            private set;
        }

        public bool AreFilesDamaged
        {
            get
            {
                return Discs.SelectMany(disc => disc.Tracks).Any(track => !track.IsMpegDataValid);
            }
        }

        public bool AreFilesOfLowQuality
        {
            get
            {
                return Discs.SelectMany(disc => disc.Tracks).Any(track => track.MpegFileInfo.Exists && (!track.IsAudioVersionValid || !track.IsLayerValid || !track.IsBitrateValid || !track.IsSampleRateValid || !track.IsChannelModeValid));
            }
        }

        public bool AreFilesInconsistent
        {
            get
            {
                return !Discs.SelectMany(disc => disc.Tracks).AllEqual(track => track.MpegFileInfo.Exists ? string.Format("{0}/{1}/{2}/{3}/{4}", track.MpegFileInfo.AudioVersion, track.MpegFileInfo.Layer, track.MpegFileInfo.IsVbr ? -1 : track.MpegFileInfo.Bitrate, track.MpegFileInfo.SampleRate, track.MpegFileInfo.ChannelMode) : string.Empty);
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return Discs.Aggregate(TimeSpan.Zero, (current, disc) => current + disc.Duration);
            }
        }

        private Album()
        {
            Discs = new List<Disc>();
        }

        private Album(Session session, Context context) : this()
        {
            _session = session;
            _context = context;
        }

        public Album(DirectoryInfo sourceDirectory, IProgress progress, CancellationToken cancellationToken, Session session, Context context) : this(session, context)
        {
            var discDirectories = new List<DirectoryInfo>();
            discDirectories.Add(sourceDirectory);
            discDirectories.AddRange(sourceDirectory.GetDirectories());

            progress.Begin(discDirectories.Sum(directory => directory.GetFiles("*.mp3").Length));

            foreach (var directory in discDirectories)
            {
                var disc = new Disc(this, _session, _context);

                foreach (var file in directory.GetFiles("*.mp3"))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progress.Advance(file.Name);

                    var track = new Track(file, disc, _session, _context);
                    disc.Tracks.Add(track);
                }

                if (disc.Tracks.Count > 0)
                    Discs.Add(disc);
            }

            SourceDirectory = sourceDirectory;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(ArtistName))
                return false;

            if (string.IsNullOrEmpty(Name))
                return false;

            if (string.IsNullOrEmpty(ReleaseYear))
                return false;

            if (!StringHelper.IsValidYear(ReleaseYear))
                return false;

            if (Discs.Count == 0)
                return false;

            foreach (var disc in Discs)
            {
                if (disc.Tracks.Count == 0)
                    return false;

                foreach (var track in disc.Tracks)
                    if (string.IsNullOrEmpty(track.Name))
                        return false;
            }

            return true;
        }

        public IEnumerable<Issue> DetectIssues(IProgress progress, CancellationToken cancellationToken)
        {
            progress.Begin(2 + Discs.Sum(disc => disc.Tracks.Count + 1)); // Artist Name + Album Name + (Disk Name + Track Count)*

            progress.Advance(string.Format("Artist: {0}", ArtistName));

            foreach (var validator in _context.GetArtistValidators(this))
            {
                cancellationToken.ThrowIfCancellationRequested();

                foreach (var issue in validator.Validate())
                    yield return issue;
            }

            progress.Advance(string.Format("Album: {0}", Name));

            foreach (var validator in _context.GetAlbumValidators(this))
            {
                cancellationToken.ThrowIfCancellationRequested();

                foreach (var issue in validator.Validate())
                    yield return issue;
            }

            foreach (var disc in Discs)
            {
                progress.Advance(string.Format("Disc {0} Name: {1}", disc.Index, Name));

                foreach (var validator in _context.GetDiscValidators(disc))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    foreach (var issue in validator.Validate())
                        yield return issue;
                }

                foreach (var track in disc.Tracks)
                {
                    progress.Advance(string.Format(@"Disc {0}\Track {1}: {2}", disc.Index, track.Index, Name));

                    foreach (var validator in _context.GetTrackValidators(track))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        foreach (var issue in validator.Validate())
                            yield return issue;
                    }
                }
            }
        }

        public void SaveTo(DirectoryInfo destinationDirectory, IProgress progress, CancellationToken cancellationToken)
        {
            progress.Begin(Discs.Sum(disc => disc.Tracks.Count));

            if (!destinationDirectory.Exists)
                destinationDirectory.Create();

            var artistDirectory = destinationDirectory.CreateSubdirectory(ArtistDirectoryName);

            if (artistDirectory.GetDirectories(AlbumDirectoryName).Length != 0)
                throw new Exception("Album directory exists!");

            var albumDirectory = artistDirectory.CreateSubdirectory(AlbumDirectoryName);

            foreach (var disc in Discs)
                disc.SaveTo(albumDirectory, progress, cancellationToken);

            GeneratePlaylist(albumDirectory);

            AlbumDirectory = albumDirectory;
        }

        private void GeneratePlaylist(DirectoryInfo albumDirectory)
        {
            if (Settings.Default.NoPlaylist)
                return;

            var filename = Path.Combine(albumDirectory.FullName, string.Format("@ {0} ({1}).m3u", StringHelper.MakeFileSystemFriendly(Name), ReleaseYear));

            using (Stream stream = File.Open(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine("#EXTM3U");

                    foreach (var disc in Discs)
                    {
                        foreach (var track in disc.Tracks)
                        {
                            writer.WriteLine("#EXTINF:{0},{1} - {2}", track.MpegFileInfo.Duration.TotalSeconds, ArtistName, track.Name);

                            if (Discs.Count == 1)
                                writer.WriteLine(string.Format(@"{0}", track.FileName));
                            else
                                writer.WriteLine(string.Format(@"{0}\{1}", disc.DirectoryName, track.FileName));
                        }
                    }
                }
            }

            PlaylistFile = new FileInfo(filename);
        }

        private string GetMarksString()
        {
            var marks = string.Join(" ", GetMarks().Select(mark => string.Format("[{0}]", mark)).ToArray());

            if (marks.Length == 0)
                return null;

            return marks;
        }

        private IEnumerable<string> GetMarks()
        {
            if (!string.IsNullOrEmpty(Type))
                yield return Type;

            if ((AreFilesDamaged || AreFilesInconsistent || AreFilesOfLowQuality) && Settings.Default.MarkDamagedAlbums)
                yield return "Damaged";
        }

        public void OnArtistNameChanged()
        {
            if (ArtistNameChanged != null)
                ArtistNameChanged(this, EventArgs.Empty);
        }

        public void OnNameChanged()
        {
            if (NameChanged != null)
                NameChanged(this, EventArgs.Empty);
        }

        public void OnYearChanged()
        {
            if (YearChanged != null)
                YearChanged(this, EventArgs.Empty);
        }

        public void OnTypeChanged()
        {
            if (TypeChanged != null)
                TypeChanged(this, EventArgs.Empty);
        }

        public void OnCoverChanged()
        {
            if (CoverChanged != null)
                CoverChanged(this, EventArgs.Empty);
        }
    }
}
