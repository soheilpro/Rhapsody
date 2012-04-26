using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class Tit2Frame : TextFrame
    {
        public const string FrameId = "TIT2";

        public Tit2Frame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public Tit2Frame(string text) : base(FrameId, text)
        {
        }
    }
}
