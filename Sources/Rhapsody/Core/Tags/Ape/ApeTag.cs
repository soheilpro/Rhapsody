using System;
using System.IO;

namespace Rhapsody.Core.Tags.Ape
{
    internal class ApeTag : ITag
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

        public Version Version
        {
            get;
            private set;
        }

        public bool Read(Stream stream)
        {
            return (ReadFromEnd(stream) || ReadFromBeginning(stream));
        }

        public bool ReadFromBeginning(Stream stream)
        {
            // APE tag header is 32 bytes
            if (stream.Length < 32)
                return false;

            var reader = new BinaryReader(stream);

            stream.Seek(0, SeekOrigin.Begin);

            var signature = reader.ReadBytes(8);

            if (signature[0] != 'A' ||
                signature[1] != 'P' ||
                signature[2] != 'E' ||
                signature[3] != 'T' ||
                signature[4] != 'A' ||
                signature[5] != 'G' ||
                signature[6] != 'E' ||
                signature[7] != 'X')
            {
                return false;
            }

            // Get version
            var version = reader.ReadInt32();

            switch (version)
            {
                case 1000:
                    // APE tag v1 cannot be at the beginning
                    return false;

                case 2000:
                    Version = new Version(2, 0);
                    break;

                default:
                    throw new NotSupportedException(string.Format("APE Tag version {0}", version));
            }

            // Get size
            var size = reader.ReadInt32();

            // Get number of items
            var itemCount = reader.ReadInt32();

            // Get flags
            var flags = reader.ReadInt32();

            // Make sure the header bit is set
            if ((flags & 0x20000000) == 0) // 00[1]00000 00000000 00000000 00000000
                return false;

            Position = TagPosision.Beginning;
            Size = 32 + size;

            return true;
        }

        public bool ReadFromEnd(Stream stream)
        {
            // APE tag footer is 32 bytes
            if (stream.Length < 32)
                return false;

            var reader = new BinaryReader(stream);

            stream.Seek(-32, SeekOrigin.End);

            var signature = reader.ReadBytes(8);

            if (signature[0] != 'A' ||
                signature[1] != 'P' ||
                signature[2] != 'E' ||
                signature[3] != 'T' ||
                signature[4] != 'A' ||
                signature[5] != 'G' ||
                signature[6] != 'E' ||
                signature[7] != 'X')
            {
                return false;
            }

            // Get version
            var version = reader.ReadInt32();

            switch (version)
            {
                case 1000:
                    Version = new Version(1, 0);
                    break;

                case 2000:
                    Version = new Version(2, 0);
                    break;

                default:
                    throw new NotSupportedException(string.Format("APE Tag version {0}", version));
            }

            // Get size
            var size = reader.ReadInt32();

            // Get number of items
            var itemCount = reader.ReadInt32();

            // Get flags
            var flags = reader.ReadUInt32();

            // Make sure the footer bit is set
            if ((flags & 0x20000000) != 0) // 00[0]00000 00000000 00000000 00000000
                return false;

            Position = TagPosision.End;
            Size = 32 + size;

            return true;
        }

        public override string ToString()
        {
            return string.Format("APE {0}", Version.ToString(2));
        }
    }
}
