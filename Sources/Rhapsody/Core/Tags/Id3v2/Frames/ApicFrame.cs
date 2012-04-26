using System;
using System.IO;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class ApicFrame : Frame
    {
        public const string FrameId = "APIC";

        public TextEncodings TextEncoding
        {
            get;
            set;
        }

        public PictureType PictureType
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public Picture Picture
        {
            get;
            set;
        }

        public ApicFrame() : base(FrameId)
        {
        }

        public ApicFrame(Picture picture, PictureType pictureType) : this()
        {
            Picture = picture;
            PictureType = pictureType;
        }

        public ApicFrame(byte[] bytes) : this()
        {
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new BinaryReader(stream))
                {
                    TextEncoding = (TextEncodings)reader.ReadByte();
                    var mimeType = ReadText(reader, TextEncodings.Iso55591);
                    PictureType = (PictureType)reader.ReadByte();
                    Description = ReadText(reader, TextEncoding);
                    var pictureData = reader.ReadBytes((int)(stream.Length - stream.Position));

                    Picture = new Picture(pictureData, mimeType);
                }
            }
        }

        public override byte[] GetBytes()
        {
            // TODO: Check for supported encodings according to version

            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write((byte)TextEncoding);
                    writer.Write(EncodeText(Picture.MimeType, TextEncodings.Iso55591));
                    writer.Write((byte)PictureType);
                    writer.Write(EncodeText(Description, TextEncoding));
                    writer.Write(Picture.Data);
                }

                return stream.ToArray();
            }
        }
    }
}
