using System;
using Rhapsody.Core.Mpeg;

namespace Rhapsody.Core
{
    internal interface IEncoder
    {
        string Name
        {
            get;
        }

        string SetupInstructions
        {
            get;
        }

        bool IsPresent();

        void Encode(string sourceFilePath, string destinationFilePath, int minBitrate, int maxBitrate, int sampleRate, ChannelMode channelMode);
    }
}
