using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Rhapsody.Core.Mpeg;

namespace Rhapsody.Core.Encoders
{
    internal class LameEncoder : EncoderBase
    {
        private const string ExecutableName = "lame.exe";

        public override string Name
        {
            get
            {
                return "LAME MP3 Encoder";
            }
        }

        public override string SetupInstructions
        {
            get
            {
                return "Download lame.exe from http://lame.sourceforge.net and save it in the same folder as Rhapsody.";
            }
        }

        public override bool IsPresent()
        {
            return File.Exists(GetLameExePath());
        }

        public override void Encode(string sourceFilePath, string destinationFilePath, int minBitrate, int maxBitrate, int sampleRate, ChannelMode channelMode)
        {
            var lameProcess = new Process();
            lameProcess.StartInfo.FileName = GetLameExePath();
            lameProcess.StartInfo.Arguments = GetLameExeArguments(sourceFilePath, destinationFilePath, minBitrate, maxBitrate, sampleRate, channelMode);
            lameProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            lameProcess.Start();
            lameProcess.WaitForExit();

            if (lameProcess.ExitCode != 0)
                throw new Exception(string.Format("lame.exe was terminated with an exit code of {0}.", lameProcess.ExitCode));
        }

        private static string GetLameExePath()
        {
            return Path.Combine(Application.StartupPath, ExecutableName);
        }

        private static string GetLameExeArguments(string sourceFilePath, string destinationFilePath, int minBitrate, int maxBitrate, int sampleRate, ChannelMode channelMode)
        {
            string arguments;

            if (minBitrate == maxBitrate)
                arguments = string.Format("-b {0}", minBitrate / 1000);
            else
                arguments = string.Format("-v -b {0} -B {1}", minBitrate / 1000, maxBitrate / 1000);

            arguments += string.Format(" --resample {0} -m {1} \"{2}\" \"{3}\"", sampleRate / 1000, channelMode.ToString().Substring(0, 1).ToLower(), sourceFilePath, destinationFilePath);

            return arguments;
        }
    }
}
