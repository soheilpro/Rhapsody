using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Rhapsody.Core.Mpeg;
using Rhapsody.Core.Tags.Ape;
using Rhapsody.Core.Tags.Id3v1;
using Rhapsody.Core.Tags.Id3v2;
using Rhapsody.Core.Tags.Id3v2.Frames;
using Rhapsody.Core.Tags.Lyrics3v2;
using Rhapsody.Utilities;

namespace Rhapsody.Core
{
    internal class Track
    {
        private Context _context;
        private Session _session;
        private long _mpegDataOffset;
        private long _mpegDataSize;

        public event EventHandler NameChanged;

        public string Name
        {
            get;
            set;
        }

        public string FileName
        {
            get
            {
                return string.Format("{0:00} - {1}.mp3", Index, StringHelper.MakeFileSystemFriendly(Name));
            }
        }

        public FileInfo SourceFile
        {
            get;
            private set;
        }

        public MpegFileInfo MpegFileInfo
        {
            get;
            private set;
        }

        public List<ITag> Tags
        {
            get;
            private set;
        }

        public Disc Disc
        {
            get;
            set;
        }

        public int Index
        {
            get
            {
                return Disc.Tracks.IndexOf(this) + 1;
            }
        }

        public bool IsMpegDataValid
        {
            get
            {
                if (!MpegFileInfo.Exists)
                    return false;

                if (MpegFileInfo.Errors.Count > 0)
                    return false;

                if (IsInvalidVbr)
                    return false;

                return true;
            }
        }

        public bool IsAudioVersionValid
        {
            get
            {
                return MpegFileInfo.AudioVersion == AudioVersion.Mpeg1;
            }
        }

        public bool IsLayerValid
        {
            get
            {
                return MpegFileInfo.Layer == Layer.Layer3;
            }
        }

        public bool IsBitrateValid
        {
            get
            {
                return MpegFileInfo.IsVbr || MpegFileInfo.Bitrate >= 128000;
            }
        }

        public bool IsSampleRateValid
        {
            get
            {
                return MpegFileInfo.SampleRate >= 44100;
            }
        }

        public bool IsChannelModeValid
        {
            get
            {
                return MpegFileInfo.ChannelMode == ChannelMode.JointStereo || MpegFileInfo.ChannelMode == ChannelMode.Stereo;
            }
        }

        public List<TimeSpan> Glitches
        {
            get
            {
                return MpegFileInfo.Errors.OfType<MisplacedFrameMpegError>().Select(error => TimeSpan.FromSeconds(Math.Floor(error.Time.TotalSeconds))).Distinct().ToList();
            }
        }

        public bool IsTruncated
        {
            get
            {
                return MpegFileInfo.Errors.Any(error => error is LastFrameTruncatedMpegError);
            }
        }

        public bool IsInvalidVbr
        {
            get
            {
                return MpegFileInfo.IsVbr && !(MpegFileInfo.HasXingHeader || MpegFileInfo.HasVbriHeader);
            }
        }

        private Track()
        {
            Tags = new List<ITag>();
        }

        private Track(Session session, Context context) : this()
        {
            _session = session;
            _context = context;
        }

        public Track(FileInfo sourceFile, Disc disc, Session session, Context context) : this(session, context)
        {
            SourceFile = sourceFile;
            Disc = disc;

            // Find tags
            using (var stream = new BufferedStream(sourceFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                _mpegDataOffset = 0;
                _mpegDataSize = stream.Length;
                Stream dataStream;

                // Better be sorted from outer to inner
                Type[] tagTypes = {
                    typeof(Id3v2Tag),
                    typeof(Id3v1Tag),
                    typeof(Lyrics3v2Tag),
                    typeof(ApeTag)
                };

                while (true)
                {
                    dataStream = new SubStream(stream, _mpegDataOffset, _mpegDataSize);

                    var anyTagFound = false;

                    foreach (var tagType in tagTypes)
                    {
                        var tag = (ITag)Activator.CreateInstance(tagType);

                        if (!tag.Read(dataStream))
                            continue;

                        if (tag.Position == TagPosision.Beginning)
                        {
                            _mpegDataOffset += tag.Size;
                            _mpegDataSize -= tag.Size;
                        }
                        else
                        {
                            _mpegDataSize -= tag.Size;
                        }

                        Tags.Add(tag);
                        anyTagFound = true;
                        break;
                    }

                    if (!anyTagFound)
                        break;
                }

                MpegFileInfo = new MpegFileInfo(dataStream);
            }
        }

        public void SaveTo(DirectoryInfo discDirectory, IProgress progress, CancellationToken cancellationToken)
        {
            var sourceFilePath = SourceFile.FullName;
            var mpegDataOffset = _mpegDataOffset;
            var mpegDataSize = _mpegDataSize;
            string reEncodedFilePath = null;

            if (NeedsReEncoding() && _session.ReEncodeFiles)
            {
                var encoder = _context.GetEncoder();
                reEncodedFilePath = Path.GetTempFileName();

                var minBirtate = Disc.MostCommonBitrate != null ? Disc.MostCommonBitrate.Value : MpegFileInfo.MinBitrate;
                var maxBirtate = Disc.MostCommonBitrate != null ? Disc.MostCommonBitrate.Value : MpegFileInfo.MaxBitrate;
                var sampleRate = Disc.MostCommonSampleRate.Value;
                var channelMode = Disc.MostCommonChannelMode.Value;

                encoder.Encode(sourceFilePath, reEncodedFilePath, minBirtate, maxBirtate, sampleRate, channelMode);

                var tempTrack = new Track(new FileInfo(reEncodedFilePath), null, _session, _context);
                mpegDataOffset = tempTrack._mpegDataOffset;
                mpegDataSize = tempTrack._mpegDataSize;

                sourceFilePath = reEncodedFilePath;
            }

            using (var sourceStream = File.Open(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var destinationStream = File.Open(Path.Combine(discDirectory.FullName, FileName), FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    var id3Tagv2 = new Id3Tagv2();
                    id3Tagv2.Version = new Version(3, 0);
                    id3Tagv2.Frames.Add(new Tpe1Frame(Disc.Album.ArtistName));
                    id3Tagv2.Frames.Add(new TyerFrame(Disc.Album.ReleaseYear));
                    id3Tagv2.Frames.Add(new TalbFrame(Disc.Album.FullName));
                    id3Tagv2.Frames.Add(new TposFrame(string.Format("{0}/{1}", Disc.Index, Disc.Album.Discs.Count)));
                    id3Tagv2.Frames.Add(new TrckFrame(string.Format("{0}/{1}", Index, Disc.Tracks.Count)));
                    id3Tagv2.Frames.Add(new Tit2Frame(Name));
                    id3Tagv2.Frames.Add(new PrivFrame("RHAPSODY", Encoding.ASCII.GetBytes(string.Format("RHAPSODY/{0}", VersionHelper.GetAppVersion()))));

                    if (Disc.Album.Cover != null)
                        id3Tagv2.Frames.Add(new ApicFrame(Disc.Album.Cover, PictureType.FrontCover));

                    if (!string.IsNullOrEmpty(Disc.Name))
                        id3Tagv2.Frames.Add(new TsstFrame(Disc.Name));

                    id3Tagv2.WriteTo(destinationStream);

                    StreamHelper.Copy(sourceStream, destinationStream, mpegDataOffset, mpegDataSize);
                }
            }

            if (reEncodedFilePath != null)
                File.Delete(reEncodedFilePath);
        }

        private bool NeedsReEncoding()
        {
            if (IsTruncated)
                return true;

            if (Glitches.Count > 0)
                return true;

            if (MpegFileInfo.AudioVersion != AudioVersion.Mpeg1)
                return true;

            if (MpegFileInfo.Layer != Layer.Layer3)
                return true;

            if (!MpegFileInfo.IsVbr)
                if (MpegFileInfo.Bitrate != Disc.MostCommonBitrate)
                    return true;

            if (MpegFileInfo.SampleRate != Disc.MostCommonSampleRate)
                return true;

            if (MpegFileInfo.ChannelMode != Disc.MostCommonChannelMode)
                return true;

            return false;
        }

        public void Remove()
        {
            Disc.Tracks.Remove(this);

            if (Disc.Tracks.Count == 0)
                Disc.Remove();
        }

        public void OnNameChanged()
        {
            if (NameChanged != null)
                NameChanged(this, EventArgs.Empty);
        }
    }
}
