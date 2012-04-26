using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TsstFrame : TextFrame
    {
        public const string FrameId = "TSST";

        public TsstFrame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public TsstFrame(string text) : base(FrameId, text)
        {
        }
    }
}
