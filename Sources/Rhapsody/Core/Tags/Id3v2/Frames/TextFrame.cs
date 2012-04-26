using System;
using System.IO;

namespace Rhapsody.Core.Tags.Id3v2.Frames
{
    internal class TextFrame : Frame
    {
        public TextEncodings Encoding
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public TextFrame(string id, byte[] bytes) : base(id)
        {
            var encoding = bytes[0];
            var textBytes = new byte[bytes.Length - 1];
            Array.Copy(bytes, 1, textBytes, 0, bytes.Length - 1);

            Encoding = (TextEncodings)encoding;
            Text = DecodeText(textBytes, Encoding);
        }

        public TextFrame(string id, string text) : base(id)
        {
            Text = text;
        }

        public override byte[] GetBytes()
        {
            // TODO: Check for supported encodings according to version

            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write((byte)Encoding);
                    writer.Write(EncodeText(Text, Encoding));
                }

                return stream.ToArray();
            }
        }
    }
}
