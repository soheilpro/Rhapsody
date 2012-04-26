using System;
using System.IO;

namespace Rhapsody.Core.Tags.Id3v2
{
    internal class Id3v2Tag : ITag
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
            return (ReadFromBeginning(stream) || ReadFromEnd(stream));
        }

        public bool ReadFromBeginning(Stream stream)
        {
            // ID3 tag v2.x header is 10 bytes
            if (stream.Length < 10)
                return false;

            stream.Seek(0, SeekOrigin.Begin);

            var reader = new BinaryReader(stream);

            var signature = reader.ReadBytes(3);

            if (signature[0] != 'I' ||
                signature[1] != 'D' ||
                signature[2] != '3')
            {
                return false;
            }

            // Get version
            var major = reader.ReadByte();
            var minor = reader.ReadByte();

            if (major == 0xFF || minor == 0xFF)
                return false;

            // Only versions 2, 3 & 4 are supported
            if (major < 2 || major > 4)
                throw new NotSupportedException(string.Format("ID3 Tag version 2.{0}.{1}", major, minor));

            Version = new Version(2, major, minor);

            // Skip flags
            reader.ReadByte();

            // Get size
            var size = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4), true);

            Position = TagPosision.Beginning;
            Size = 10 + size;

            return true;
        }

        public bool ReadFromEnd(Stream stream)
        {
            // ID3 tag v2.x footer is 10 bytes
            if (stream.Length < 10)
                return false;

            stream.Seek(-10, SeekOrigin.End);

            var reader = new BinaryReader(stream);

            var signature = reader.ReadBytes(3);

            if (signature[0] != '3' ||
                signature[1] != 'D' ||
                signature[2] != 'I')
            {
                return false;
            }

            // Get version
            var major = reader.ReadByte();
            var minor = reader.ReadByte();

            if (major == 0xFF || minor == 0xFF)
                return false;

            // Only versions 2, 3 & 4 are supported
            if (major < 2 || major > 4)
                throw new NotSupportedException(string.Format("ID3 Tag version 2.{0}.{1}", major, minor));

            // Only version 4 allows footer
            if (major != 4)
                return false;

            Version = new Version(2, major, minor);

            // Skip flags
            var flags = reader.ReadByte();

            // Make sure the footer present bit is set
            if ((flags & 0x10) == 0) // 000[1]0000
                return false;

            // Get size
            var size = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4), true);

            Position = TagPosision.End;
            Size = 10 + size;

            return true;
        }

        public override string ToString()
        {
            return string.Format("ID3 {0}", Version.ToString(2));
        }
    }
}
