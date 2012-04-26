using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TyerFrame : TextFrame
    {
        public const string FrameId = "TYER";

        public TyerFrame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public TyerFrame(string text) : base(FrameId, text)
        {
        }
    }
}
