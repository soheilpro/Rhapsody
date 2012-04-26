using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TalbFrame : TextFrame
    {
        public const string FrameId = "TALB";

        public TalbFrame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public TalbFrame(string text) : base(FrameId, text)
        {
        }
    }
}
