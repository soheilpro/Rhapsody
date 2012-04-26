using System;
using System.Globalization;

namespace Rhapsody.Core.Mpeg
{
    internal static class MpegHelper
    {
        public static string GetAudioVersionString(MpegFileInfo mpegFileInfo)
        {
            switch (mpegFileInfo.AudioVersion)
            {
                case AudioVersion.Mpeg1:
                    return "MPEG 1";

                case AudioVersion.Mpeg2:
                    return "MPEG 2";

                case AudioVersion.Mpeg25:
                    return "MPEG 2.5";
            }

            return null;
        }

        public static string GetLayerString(MpegFileInfo mpegFileInfo)
        {
            switch (mpegFileInfo.Layer)
            {
                case Layer.Layer1:
                    return "Layer I";

                case Layer.Layer2:
                    return "Layer II";

                case Layer.Layer3:
                    return "Layer III";
            }

            return null;
        }

        public static string GetBitrateString(MpegFileInfo mpegFileInfo)
        {
            if (mpegFileInfo.IsVbr)
                return "VBR";

            return (mpegFileInfo.Bitrate / 1000).ToString(CultureInfo.InvariantCulture);
        }

        public static string GetSampleRateString(MpegFileInfo mpegFileInfo)
        {
            return mpegFileInfo.SampleRate.ToString("#,###");
        }

        public static string GetChannelModeString(MpegFileInfo mpegFileInfo)
        {
            switch (mpegFileInfo.ChannelMode)
            {
                case ChannelMode.DualChannel:
                    return "Dual Channel";

                case ChannelMode.JointStereo:
                    return "Joint Stereo";

                case ChannelMode.Mono:
                    return "Mono";

                case ChannelMode.Stereo:
                    return "Stereo";
            }

            return null;
        }
    }
}
