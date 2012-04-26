using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TposFrame : TextFrame
    {
        public const string FrameId = "TPOS";

        public TposFrame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public TposFrame(string text) : base(FrameId, text)
        {
        }
    }
}
