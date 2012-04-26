using System;
using System.IO;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class PrivFrame : Frame
    {
        public const string FrameId = "PRIV";

        public string OwnerIdentifier
        {
            get;
            set;
        }

        public byte[] Data
        {
            get;
            set;
        }

        public PrivFrame(byte[] bytes) : base(FrameId)
        {
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new BinaryReader(stream))
                {
                    OwnerIdentifier = ReadText(reader, TextEncodings.Iso55591);
                    Data = reader.ReadBytes((int)(stream.Length - stream.Position));
                }
            }
        }

        public PrivFrame(string ownerIdentifier, byte[] data) : base(FrameId)
        {
            OwnerIdentifier = ownerIdentifier;
            Data = data;
        }

        public override byte[] GetBytes()
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(EncodeText(OwnerIdentifier, TextEncodings.Iso55591));
                    writer.Write(Data);
                }

                return stream.ToArray();
            }
        }
    }
}
