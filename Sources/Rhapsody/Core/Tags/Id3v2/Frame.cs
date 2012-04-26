using System;
using System.IO;
using System.Text;
using Rhapsody.Utilities;

namespace Rhapsody.Core.Tags.Id3v2
{
    internal abstract class Frame
    {
        public string Id
        {
            get;
            private set;
        }

        protected Frame(string id)
        {
            Id = id;
        }

        public abstract byte[] GetBytes();

        protected string DecodeText(byte[] text, TextEncodings encoding)
        {
            switch (encoding)
            {
                case TextEncodings.Iso55591:
                    return Encoding.GetEncoding(0x6faf).GetString(text).TrimEnd('\0');

                case TextEncodings.Utf8:
                    return Encoding.UTF8.GetString(text).TrimEnd('\0');

                case TextEncodings.Utf16:

                    if (text.Length == 0)
                        return string.Empty;

                    if (text[0] == 0xFE && text[1] == 0xFF)
                        return Encoding.BigEndianUnicode.GetString(text, 2, text.Length - 2).TrimEnd('\0');

                    if (text[0] == 0xFF && text[1] == 0xFE)
                        return Encoding.Unicode.GetString(text, 2, text.Length - 2).TrimEnd('\0');

                    throw new NotSupportedException();

                case TextEncodings.Utf16Be:
                    return Encoding.BigEndianUnicode.GetString(text).TrimEnd('\0');

                default:
                    throw new NotSupportedException();
            }
        }

        protected byte[] EncodeText(string text, TextEncodings encoding)
        {
            switch (encoding)
            {
                case TextEncodings.Iso55591:
                    return Encoding.GetEncoding(0x6faf).GetBytes(text + "\0");

                case TextEncodings.Utf8:
                    return Encoding.UTF8.GetBytes(text + "\0\0");

                default:
                    throw new NotSupportedException();
            }
        }

        protected string ReadText(BinaryReader reader, TextEncodings encoding)
        {
            switch (encoding)
            {
                case TextEncodings.Iso55591:
                {
                    var bytes = new ByteBuffer();

                    while (true)
                    {
                        var b = reader.ReadByte();
                        if (b == 0)
                            break;

                        bytes.Add(b);
                    }

                    if (bytes.Length == 0)
                        return string.Empty;

                    return DecodeText(bytes.ToArray(), encoding);
                }
                case TextEncodings.Utf16:
                {
                    var bytes = new ByteBuffer();

                    while (true)
                    {
                        var b = reader.ReadByte();
                        if (b == 0)
                        {
                            var n = reader.ReadByte();

                            if (n == 0)
                                break;

                            bytes.Add(b);
                            bytes.Add(n);
                            break;
                        }

                        bytes.Add(b);
                    }

                    return DecodeText(bytes.ToArray(), encoding);
                }
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
