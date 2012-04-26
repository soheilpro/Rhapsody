using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TrckFrame : TextFrame
    {
        public const string FrameId = "TRCK";

        public TrckFrame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public TrckFrame(string text) : base(FrameId, text)
        {
        }
    }
}
