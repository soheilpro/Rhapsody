using System;
using System.IO;

namespace Rhapsody.Core.Tags.Id3v1
{
    internal class Id3v1Tag : ITag
    {
        public TagPosision Position
        {
            get;
            private set;
        }

        public int Size
        {
            get;
            private set;
        }

        public bool Read(Stream stream)
        {
            // ID3 tag v1.x is 128 bytes
            if (stream.Length < 128)
                return false;

            stream.Seek(-128, SeekOrigin.End);

            var reader = new BinaryReader(stream);
            var signature = reader.ReadBytes(3);

            if (signature[0] != 'T' ||
                signature[1] != 'A' ||
                signature[2] != 'G')
            {
                return false;
            }

            Position = TagPosision.End;
            Size = 128;

            return true;
        }

        public override string ToString()
        {
            return "ID3 1.x";
        }
    }
}
