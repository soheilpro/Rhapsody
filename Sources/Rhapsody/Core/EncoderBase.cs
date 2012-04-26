using System;
using Rhapsody.Core.Mpeg;

namespace Rhapsody.Core
{
    internal abstract class EncoderBase : IEncoder
    {
        public abstract string Name
        {
            get;
        }

        public abstract string SetupInstructions
        {
            get;
        }

        public abstract bool IsPresent();

        public abstract void Encode(string sourceFilePath, string destinationFilePath, int minBitrate, int maxBitrate, int sampleRate, ChannelMode channelMode);
    }
}
