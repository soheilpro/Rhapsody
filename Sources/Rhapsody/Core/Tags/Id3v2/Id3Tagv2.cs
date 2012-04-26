using System;
using System.IO;
using System.Text;
using Rhapsody.Core.Tags.Id3v2.Frames;
using Rhapsody.Utilities;

namespace Rhapsody.Core.Tags.Id3v2
{
    internal class Id3Tagv2
    {
        private static readonly byte[] Id3TagV2Signature = {0x49, 0x44, 0x33}; // ID3

        public FrameCollection Frames
        {
            get;
            private set;
        }

        public Version Version
        {
            get;
            set;
        }

        public bool Unsynchronise
        {
            get;
            set;
        }

        public int PaddingSize
        {
            get;
            set;
        }

        public Id3Tagv2()
        {
            Frames = new FrameCollection();
        }

        public void WriteTo(Stream stream)
        {
            if (Version.Major == 3)
            {
                if (Version.Minor != 0)
                    throw new NotSupportedException();

                WriteV3To(stream);
                return;
            }

            throw new NotSupportedException();
        }

        private void WriteV3To(Stream stream)
        {
            if (Frames.Count == 0)
                throw new Exception("There must be at least one frame in the tag.");

            var writer = new BinaryWriter(stream);
            var framesBytes = GetFramesBytesV3();
            var headerFlags = TagHeaderFlags.None;

            if (Unsynchronise)
            {
                if (UnsynchroniseBuffer(ref framesBytes))
                    headerFlags |= TagHeaderFlags.Unsynchronisation;
            }

            writer.Write(Id3TagV2Signature);
            writer.Write((byte)Version.Major);
            writer.Write((byte)Version.Minor);
            writer.Write((byte)headerFlags);
            writer.Write(EndianHelper.LittleToBigEndianInt32(framesBytes.Length, true));
            writer.Write(framesBytes);

            var padding = new byte[PaddingSize];
            writer.Write(padding);

            writer.Flush();
        }

        private byte[] GetFramesBytesV3()
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (var frame in Frames)
                    {
                        var flags = FrameHeaderFlagsV3.None;
                        var frameData = frame.GetBytes();

                        if (frameData.Length == 0)
                            throw new Exception("A frame must be at least one byte big.");

                        writer.Write(Encoding.ASCII.GetBytes(frame.Id));
                        writer.Write(EndianHelper.LittleToBigEndianInt32(frameData.Length));
                        writer.Write(EndianHelper.LittleToBigEndianInt16((short)flags));
                        writer.Write(frameData);
                    }
                }

                return stream.ToArray();
            }
        }

        private static bool UnsynchroniseBuffer(ref byte[] data)
        {
            var stream = new MemoryStream(data.Length);
            byte lastByte = 0;
            var unsynchronised = false;

            foreach (byte b in data)
            {
                if (lastByte == 0xFF)
                {
                    if (b == 0 || (b & 0xE0) == 0xE0)
                    {
                        stream.WriteByte(0);
                        unsynchronised = true;
                    }
                }

                stream.WriteByte(b);
                lastByte = b;
            }

            if (unsynchronised)
                data = stream.ToArray();

            return unsynchronised;
        }

        public static Id3Tagv2 Load(string path)
        {
            using (var stream = File.OpenRead(path))
                return Load(stream);
        }

        public static Id3Tagv2 Load(Stream stream)
        {
            var reader = new BinaryReader(stream);
            var signature = reader.ReadBytes(3);

            if (!ArrayHelper.CompareArray(signature, Id3TagV2Signature))
                return null;

            var versionMajor = reader.ReadByte();
            var versionMinor = reader.ReadByte();

            if (versionMajor == 0xff || versionMinor == 0xff)
                return null;

            if (versionMajor == 4)
                return LoadV4(reader, versionMinor);

            if (versionMajor == 3)
                return LoadV3(reader, versionMinor);

            return null;
        }

        private static Id3Tagv2 LoadV4(BinaryReader reader, byte versionMinor)
        {
            var tag = new Id3Tagv2();
            tag.Version = new Version(4, versionMinor);

            var headerFlags = (TagHeaderFlags)reader.ReadByte();

            if (headerFlags.HasFlag(TagHeaderFlags.Unsynchronisation))
                throw new NotSupportedException();

            if (headerFlags.HasFlag(TagHeaderFlags.ExtendedHeader))
                throw new NotSupportedException();

            if (headerFlags.HasFlag(TagHeaderFlags.FooterPresent))
                throw new NotSupportedException();

            var tagSize = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4), true);

            var offset = 0;
            while (offset < tagSize)
            {
                if (reader.PeekChar() == 0)
                {
                    tag.PaddingSize = tagSize - offset;
                    break;
                }

                var frameId = new string(reader.ReadChars(4));
                var frameSize = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4), true);
                var frameFlags = (FrameHeaderFlagsV4)EndianHelper.BigToLittleEndianInt16(reader.ReadBytes(2));

                if (frameFlags.HasFlag(FrameHeaderFlagsV4.GroupingIdentity))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV4.Compression))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV4.Encryption))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV4.Unsynchronisation))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV4.DataLengthIndicator))
                    throw new NotSupportedException();

                var frameData = reader.ReadBytes(frameSize);

                var frame = GetFrame(frameId, frameData);
                tag.Frames.Add(frame);

                offset += frameSize + 10;
            }

            return tag;
        }

        private static Id3Tagv2 LoadV3(BinaryReader reader, byte versionMinor)
        {
            var tag = new Id3Tagv2();
            tag.Version = new Version(3, versionMinor);

            var headerFlags = (TagHeaderFlags)reader.ReadByte();

            if (headerFlags.HasFlag(TagHeaderFlags.Unsynchronisation))
                throw new NotSupportedException();

            if (headerFlags.HasFlag(TagHeaderFlags.ExtendedHeader))
                throw new NotSupportedException();

            var tagSize = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4), true);

            var offset = 0;
            while (offset < tagSize)
            {
                if (reader.PeekChar() == 0)
                {
                    tag.PaddingSize = tagSize - offset;
                    break;
                }

                var frameId = new string(reader.ReadChars(4));
                var frameSize = EndianHelper.BigToLittleEndianInt32(reader.ReadBytes(4));
                var frameFlags = (FrameHeaderFlagsV3)EndianHelper.BigToLittleEndianInt16(reader.ReadBytes(2));

                if (frameFlags.HasFlag(FrameHeaderFlagsV3.Compression))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV3.Encryption))
                    throw new NotSupportedException();

                if (frameFlags.HasFlag(FrameHeaderFlagsV3.GroupingIdentity))
                    throw new NotSupportedException();

                var frameData = reader.ReadBytes(frameSize);

                var frame = GetFrame(frameId, frameData);
                tag.Frames.Add(frame);

                offset += frameSize + 10;
            }

            return tag;
        }

        private static Frame GetFrame(string frameId, byte[] frameData)
        {
            if (frameId == TrckFrame.FrameId)
                return new TrckFrame(frameData);

            if (frameId == Tit2Frame.FrameId)
                return new Tit2Frame(frameData);

            if (frameId == TyerFrame.FrameId)
                return new TyerFrame(frameData);

            if (frameId == TalbFrame.FrameId)
                return new TalbFrame(frameData);

            if (frameId == Tpe1Frame.FrameId)
                return new Tpe1Frame(frameData);

            if (frameId == TsstFrame.FrameId)
                return new TsstFrame(frameData);

            if (frameId.StartsWith("T"))
                return new TextFrame(frameId, frameData);

            if (frameId == ApicFrame.FrameId)
                return new ApicFrame(frameData);

            if (frameId == PrivFrame.FrameId)
                return new PrivFrame(frameData);

            return new UnknownFrame(frameId, frameData);
        }
    }
}
