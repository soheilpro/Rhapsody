using System;
using System.IO;

namespace Rhapsody.Utilities
{
    internal class SubStream : Stream
    {
        private Stream _baseStream;
        private long _start;
        private long _length;

        public override bool CanRead
        {
            get
            {
                return _baseStream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return _baseStream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return _baseStream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return _length;
            }
        }

        public override long Position
        {
            get
            {
                return _baseStream.Position - _start;
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        public SubStream(Stream baseStream, long start, long length)
        {
            _baseStream = baseStream;
            _start = start;
            _length = length;

            Seek(0, SeekOrigin.Begin);
        }

        public override int ReadByte()
        {
            if (_baseStream.Position >= _start + _length)
                throw new ArgumentException();

            return _baseStream.ReadByte();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_baseStream.Position + count > _start + _length)
                count = (int)(_start + _length - _baseStream.Position);

            return _baseStream.Read(buffer, offset, count);
        }

        public override sealed long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    offset = _start + offset;
                    break;

                case SeekOrigin.Current:
                    offset = _baseStream.Position + offset;
                    break;

                case SeekOrigin.End:
                    offset = _start + _length + offset;
                    break;
            }

            if (offset < _start)
                throw new ArgumentException();

            if (offset > _start + _length)
                throw new ArgumentException();

            _baseStream.Seek(offset, SeekOrigin.Begin);

            return Position;
        }

        public override void SetLength(long value)
        {
            if (value < 0)
                throw new ArgumentException();

            _length = value;
        }

        public override void WriteByte(byte value)
        {
            if (_baseStream.Position >= _start + _length)
                throw new ArgumentException();

            _baseStream.WriteByte(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_baseStream.Position + count > _start + _length)
                count = (int)(_start + _length - _baseStream.Position);

            _baseStream.Write(buffer, offset, count);
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            _baseStream.Dispose();
        }
    }
}
