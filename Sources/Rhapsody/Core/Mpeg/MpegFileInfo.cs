using System;
using System.Collections.Generic;
using System.IO;
using Rhapsody.Utilities;

namespace Rhapsody.Core.Mpeg
{
    internal class MpegFileInfo
    {
        private static readonly byte[] XingSignature = {0x58, 0x69, 0x6e, 0x67}; // Xing
        private static readonly byte[] VbriSignature = {0x56, 0x42, 0x52, 0x49}; // VBRI

        private MpegFrameHeader _firstMpegFrameHeader;
        private byte[] _firstMpegFrameData;

        public bool Exists
        {
            get
            {
                return _firstMpegFrameHeader != null;
            }
        }

        public AudioVersion AudioVersion
        {
            get
            {
                return _firstMpegFrameHeader.AudioVersion;
            }
        }

        public Layer Layer
        {
            get
            {
                return _firstMpegFrameHeader.Layer;
            }
        }

        public ChannelMode ChannelMode
        {
            get
            {
                return _firstMpegFrameHeader.ChannelMode;
            }
        }

        public int SampleRate
        {
            get
            {
                return _firstMpegFrameHeader.SampleRate;
            }
        }

        public bool IsVbr
        {
            get
            {
                return MinBitrate != MaxBitrate;
            }
        }

        public int Bitrate
        {
            get;
            private set;
        }

        public int MinBitrate
        {
            get;
            private set;
        }

        public int MaxBitrate
        {
            get;
            private set;
        }

        public TimeSpan Duration
        {
            get;
            private set;
        }

        public long StartOffset
        {
            get;
            private set;
        }

        public int Size
        {
            get;
            private set;
        }

        public bool HasXingHeader
        {
            get;
            private set;
        }

        public bool HasVbriHeader
        {
            get;
            private set;
        }

        public List<MpegError> Errors
        {
            get;
            private set;
        }

        private MpegFileInfo()
        {
            Errors = new List<MpegError>();
        }

        public MpegFileInfo(Stream stream) : this()
        {
            MaxBitrate = int.MinValue;
            MinBitrate = int.MaxValue;

            if (stream.Length < 4)
                return;

            stream.Seek(0, SeekOrigin.Begin);

            long expectedNextFrameOffset = 0;
            long frameCount = 0;
            long bitrateSum = 0;

            while (stream.Position <= stream.Length)
            {
                var buffer = new byte[4];
                var bytesRead = stream.Read(buffer, 0, 4);

                if (bytesRead < 4)
                    break;

                if (!MpegFrameHeader.IsValid(buffer))
                {
                    if (stream.Position == stream.Length)
                        break;

                    stream.Seek(-3, SeekOrigin.Current);

                    if (frameCount == 0)
                        expectedNextFrameOffset = stream.Position;

                    // An invalid frame after the first 2 valid frames indicates false detection
                    if (frameCount <= 2)
                    {
                        _firstMpegFrameHeader = null;
                        _firstMpegFrameData = null;
                        MinBitrate = int.MaxValue;
                        MaxBitrate = int.MinValue;
                        frameCount = 0;
                        bitrateSum = 0;
                    }

                    continue;
                }

                if (frameCount > 0 && expectedNextFrameOffset != stream.Position - 4)
                    Errors.Add(new MisplacedFrameMpegError(expectedNextFrameOffset, stream.Position - 4, TimeSpan.FromSeconds(frameCount * _firstMpegFrameHeader.SamplesPerFrame / _firstMpegFrameHeader.SampleRate)));

                var mpegHeader = new MpegFrameHeader(buffer);
                var frameOffset = stream.Position - 4;

                if (frameCount == 0)
                {
                    _firstMpegFrameHeader = mpegHeader;
                    _firstMpegFrameData = new byte[mpegHeader.FrameSize];
                    stream.Read(_firstMpegFrameData, 0, _firstMpegFrameData.Length);

                    StartOffset = frameOffset;
                }

                if (mpegHeader.Bitrate < MinBitrate)
                    MinBitrate = mpegHeader.Bitrate;

                if (mpegHeader.Bitrate > MaxBitrate)
                    MaxBitrate = mpegHeader.Bitrate;

                bitrateSum += mpegHeader.Bitrate;
                frameCount++;
                expectedNextFrameOffset = frameOffset + mpegHeader.FrameSize;

                if (expectedNextFrameOffset == stream.Length)
                    break;

                if (expectedNextFrameOffset > stream.Length)
                {
                    Errors.Add(new LastFrameTruncatedMpegError());
                    break;
                }

                stream.Seek(expectedNextFrameOffset, SeekOrigin.Begin);
                Size = (int)(stream.Position - StartOffset);
            }

            if (frameCount > 0)
            {
                Bitrate = (int)(bitrateSum / frameCount);
                Duration = TimeSpan.FromSeconds(frameCount * _firstMpegFrameHeader.SamplesPerFrame / _firstMpegFrameHeader.SampleRate);
                HasXingHeader = ArrayHelper.CompareArray(_firstMpegFrameData.SubArray(GetXingHeaderOffset(_firstMpegFrameHeader), 4), XingSignature);
                HasVbriHeader = ArrayHelper.CompareArray(_firstMpegFrameData.SubArray(32, 4), VbriSignature);
            }
        }

        private int GetXingHeaderOffset(MpegFrameHeader mpegHeader)
        {
            // TODO: mpegHeader.IsProtected

            switch (mpegHeader.AudioVersion)
            {
                case AudioVersion.Mpeg1:
                    return mpegHeader.ChannelMode != ChannelMode.Mono ? 32 : 17;

                case AudioVersion.Mpeg2:
                case AudioVersion.Mpeg25:
                    return mpegHeader.ChannelMode != ChannelMode.Mono ? 17 : 9;
            }

            throw new NotSupportedException();
        }
    }
}
