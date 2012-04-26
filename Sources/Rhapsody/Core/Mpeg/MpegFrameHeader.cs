using System;

namespace Rhapsody.Core.Mpeg
{
    internal class MpegFrameHeader
    {
        private static readonly short[] PaddingTable = {
            1, // Layer III
            1, // Layer II
            4 // Layer I
        };

        private static readonly int[,,] BitrateTable = {
            {
                // MPEG 2.5
                {0, 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 0}, // Layer III
                {0, 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 0}, // Layer II
                {0, 32, 48, 56, 64, 80, 96, 112, 128, 144, 160, 176, 192, 224, 256, 0} // Layer I
            },
            {
                // Reserved
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            },
            {
                // MPEG 2
                {0, 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 0}, // Layer III
                {0, 8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 0}, // Layer II
                {0, 32, 48, 56, 64, 80, 96, 112, 128, 144, 160, 176, 192, 224, 256, 0} // Layer I
            },
            {
                // MPEG 1
                {0, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 0}, // Layer III
                {0, 32, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 384, 0}, // Layer II
                {0, 32, 64, 96, 128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, 0} // Layer I
            }
        };

        private static readonly int[,] SampleRateTable = {
            {11025, 12000, 8000}, // MPEG 2.5
            {0, 0, 0}, // Reserved
            {22050, 24000, 16000}, // MPEG 2
            {44100, 48000, 32000} // MPEG 1
        };

        private static readonly short[,] SamplesPerFrameTable = {
            {
                // MPEG 2.5
                576, // Layer III
                1152, // Layer II
                384 // Layer I
            },
            {
                // Reserved
                0, // Layer III
                0, // Layer II
                0 // Layer I
            },
            {
                // MPEG 2
                576, // Layer III
                1152, // Layer II
                384 // Layer I
            },
            {
                // MPEG 1
                1152, // Layer III
                1152, // Layer II
                384 // Layer I
            }
        };

        private byte _audioVersionIndex;
        private byte _layerIndex;

        public AudioVersion AudioVersion
        {
            get;
            private set;
        }

        public Layer Layer
        {
            get;
            private set;
        }

        public bool IsProtected
        {
            get;
            private set;
        }

        public int Bitrate
        {
            get;
            private set;
        }

        public int SampleRate
        {
            get;
            private set;
        }

        public short Padding
        {
            get;
            private set;
        }

        public ChannelMode ChannelMode
        {
            get;
            private set;
        }

        public short SamplesPerFrame
        {
            get;
            private set;
        }

        public int FrameSize
        {
            get;
            private set;
        }

        public MpegFrameHeader(byte[] headerBytes)
        {
            ReadAudioVersion(headerBytes);
            ReadLayer(headerBytes);
            ReadProtectionBit(headerBytes);
            ReadBitrate(headerBytes);
            ReadSampleRate(headerBytes);
            ReadPadding(headerBytes);
            ReadChannelMode(headerBytes);
            CalculateSamplesPerFrame();
            CalculateFrameSize();
        }

        private void ReadAudioVersion(byte[] headerBytes)
        {
            _audioVersionIndex = GetAudioVersionIndex(headerBytes);
            AudioVersion = (AudioVersion)_audioVersionIndex;
        }

        private void ReadLayer(byte[] headerBytes)
        {
            _layerIndex = GetLayerIndex(headerBytes);
            Layer = (Layer)_layerIndex;
        }

        private void ReadProtectionBit(byte[] headerBytes)
        {
            IsProtected = !IsProtectionBitSet(headerBytes);
        }

        private void ReadBitrate(byte[] headerBytes)
        {
            int bitrateIndex = GetBitrateIndex(headerBytes);
            Bitrate = BitrateTable[_audioVersionIndex, _layerIndex - 1, bitrateIndex] * 1000;
        }

        private void ReadSampleRate(byte[] headerBytes)
        {
            int samplingRateIndex = GetSampleRateIndex(headerBytes);
            SampleRate = SampleRateTable[_audioVersionIndex, samplingRateIndex];
        }

        private void ReadChannelMode(byte[] headerBytes)
        {
            int channelModeIndex = GetChannelModeIndex(headerBytes);
            ChannelMode = (ChannelMode)channelModeIndex;
        }

        private void ReadPadding(byte[] headerBytes)
        {
            if (IsPaddingBitSet(headerBytes))
                Padding = PaddingTable[_layerIndex - 1];
        }

        private void CalculateSamplesPerFrame()
        {
            SamplesPerFrame = SamplesPerFrameTable[_audioVersionIndex, _layerIndex - 1];
        }

        private void CalculateFrameSize()
        {
            FrameSize = ((SamplesPerFrame / 8 * Bitrate) / SampleRate) + Padding;
        }

        private static byte GetAudioVersionIndex(byte[] headerBytes)
        {
            return (byte)((headerBytes[1] & 0x18) >> 3);
        }

        private static byte GetLayerIndex(byte[] headerBytes)
        {
            return (byte)((headerBytes[1] & 0x6) >> 1);
        }

        private static bool IsProtectionBitSet(byte[] headerBytes)
        {
            return (headerBytes[1] & 0x1) == 0x1;
        }

        private static byte GetBitrateIndex(byte[] headerBytes)
        {
            return (byte)((headerBytes[2] & 0xF0) >> 4);
        }

        private static byte GetSampleRateIndex(byte[] headerBytes)
        {
            return (byte)((headerBytes[2] & 0xC) >> 2);
        }

        private static bool IsPaddingBitSet(byte[] headerBytes)
        {
            return (headerBytes[2] & 0x2) == 0x2;
        }

        private static byte GetChannelModeIndex(byte[] headerBytes)
        {
            return (byte)(headerBytes[3] >> 6);
        }

        private static byte GetEmphasisIndex(byte[] headerBytes)
        {
            return (byte)(headerBytes[3] & 3);
        }

        public static bool IsValid(byte[] headerBytes)
        {
            if (headerBytes[0] != 0xFF || (headerBytes[1] & 0xE0) != 0xE0)
                return false;

            if ((GetAudioVersionIndex(headerBytes) & 3) == 1)
                return false;

            if ((GetLayerIndex(headerBytes) & 3) == 0)
                return false;

            if ((GetBitrateIndex(headerBytes) & 15) == 0)
                return false;

            if ((GetBitrateIndex(headerBytes) & 15) == 15)
                return false;

            if ((GetSampleRateIndex(headerBytes) & 3) == 3)
                return false;

            if ((GetEmphasisIndex(headerBytes) & 3) == 2)
                return false;

            return true;
        }
    }
}
