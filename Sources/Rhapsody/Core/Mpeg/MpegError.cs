using System;

namespace Rhapsody.Core.Mpeg
{
    internal abstract class MpegError
    {
    }

    internal class LastFrameTruncatedMpegError : MpegError
    {
    }

    internal class MisplacedFrameMpegError : MpegError
    {
        public long ExpectedLocation
        {
            get;
            private set;
        }

        public long FoundLocation
        {
            get;
            private set;
        }

        public TimeSpan Time
        {
            get;
            private set;
        }

        public MisplacedFrameMpegError(long expectedLocation, long foundLocation, TimeSpan time)
        {
            ExpectedLocation = expectedLocation;
            FoundLocation = foundLocation;
            Time = time;
        }
    }
}
