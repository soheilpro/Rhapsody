using System;
using System.IO;

namespace Rhapsody.Core.Tags.Lyrics3v2
{
    internal class Lyrics3v2Tag : ITag
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
            // Lyrics3 tag v2 header is 9 bytes
            if (stream.Length < 9)
                return false;

            var reader = new BinaryReader(stream);

            stream.Seek(-9, SeekOrigin.End);

            var footerSignature = reader.ReadBytes(9);

            if (footerSignature[0] != 'L' ||
                footerSignature[1] != 'Y' ||
                footerSignature[2] != 'R' ||
                footerSignature[3] != 'I' ||
                footerSignature[4] != 'C' ||
                footerSignature[5] != 'S' ||
                footerSignature[6] != '2' ||
                footerSignature[7] != '0' ||
                footerSignature[8] != '0')
            {
                return false;
            }

            stream.Seek(-(9 + 6), SeekOrigin.Current);

            int size;
            if (!int.TryParse(new string(reader.ReadChars(6)), out size))
                return false;

            stream.Seek(-(6 + size), SeekOrigin.Current);

            var headerSignature = reader.ReadBytes(11);

            if (headerSignature[0] != 'L' ||
                headerSignature[1] != 'Y' ||
                headerSignature[2] != 'R' ||
                headerSignature[3] != 'I' ||
                headerSignature[4] != 'C' ||
                headerSignature[5] != 'S' ||
                headerSignature[6] != 'B' ||
                headerSignature[7] != 'E' ||
                headerSignature[8] != 'G' ||
                headerSignature[9] != 'I' ||
                headerSignature[10] != 'N')
            {
                return false;
            }

            Position = TagPosision.End;
            Size = size + 6 + 9;

            return true;
        }

        public override string ToString()
        {
            return "Lyrics3 2.0";
        }
    }
}
