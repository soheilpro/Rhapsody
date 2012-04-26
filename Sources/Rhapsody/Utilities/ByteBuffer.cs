using System;
using System.Diagnostics;

namespace Rhapsody.Utilities
{
    [DebuggerDisplay("Length: {Length}")]
    internal class ByteBuffer
    {
        private byte[] _data;
        private int _start;
        private int _length;
        private int _initialSize;

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public ByteBuffer() : this(16)
        {
        }

        public ByteBuffer(int size)
        {
            _data = new byte[size];
            _initialSize = size;
        }

        public void Add(byte[] buffer, int offset, int count)
        {
            Debug.Assert(buffer != null);
            Debug.Assert(offset >= 0);
            Debug.Assert(offset < buffer.Length || count == 0);
            Debug.Assert(count >= 0);
            Debug.Assert(offset + count <= buffer.Length);

            if (count == 0)
                return;

            EnsureSize(count);

            Buffer.BlockCopy(buffer, offset, _data, _start + _length, count);
            _length += count;
        }

        public void Add(byte[] data)
        {
            Debug.Assert(data != null);

            if (data.Length == 0)
                return;

            Add(data, 0, data.Length);
        }

        public void Add(byte value)
        {
            EnsureSize(1);

            _data[_length] = value;
            _length += 1;
        }

        public byte[] ToArray()
        {
            var array = new byte[_length];
            Buffer.BlockCopy(_data, _start, array, 0, _length);

            return array;
        }

        private void EnsureSize(int requiredSize)
        {
            Debug.Assert(requiredSize >= 0);

            var freeBytesAtRight = _data.Length - (_start + _length);

            if (requiredSize <= freeBytesAtRight)
                return;

            var freeBytesAtLeft = _start;
            var freeBytes = freeBytesAtLeft + freeBytesAtRight;
            int newSize;

            // If there are enough free bytes, just re-arrange existing data
            // Otherwise, enlarge the buffer size
            if (requiredSize <= freeBytes)
                newSize = _data.Length;
            else
                newSize = _data.Length + (((requiredSize - freeBytes) / _initialSize) + 1) * _initialSize;

            var newBuffer = new byte[newSize];
            Buffer.BlockCopy(_data, _start, newBuffer, 0, _length);

            _data = newBuffer;
            _start = 0;
        }
    }
}
