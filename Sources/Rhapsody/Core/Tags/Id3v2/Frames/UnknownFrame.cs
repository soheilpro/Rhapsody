using System;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class UnknownFrame : Frame
    {
        private byte[] _bytes;

        public UnknownFrame(string id, byte[] bytes) : base(id)
        {
            _bytes = bytes;
        }

        public override byte[] GetBytes()
        {
            return _bytes;
        }
    }
}
