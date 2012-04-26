using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class Tpe1Frame : TextFrame
    {
        public const string FrameId = "TPE1";

        public Tpe1Frame(byte[] bytes) : base(FrameId, bytes)
        {
        }

        public Tpe1Frame(string text) : base(FrameId, text)
        {
        }
    }
}
