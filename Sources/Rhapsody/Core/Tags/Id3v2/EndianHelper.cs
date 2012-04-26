using System;

namespace Rhapsody.Core.Tags.Id3v2
{
    internal static class EndianHelper
    {
        public static int BigToLittleEndianInt32(byte[] bytes, bool synchSafe = false)
        {
            var effectiveBits = (byte)(synchSafe ? 7 : 8);
            var upperBound = bytes.GetUpperBound(0);
            var value = 0;

            for (var i = 0; i <= upperBound; i++)
            {
                // Syncsafed bytes should be less than 0x80 (128)
                if (synchSafe && (bytes[i] >= 0x80))
                    throw new Exception();

                value += (int)(bytes[i] * (Math.Pow(2, ((upperBound - i) * effectiveBits))));
            }

            return value;
        }

        public static short BigToLittleEndianInt16(byte[] bytes, bool synchSafe = false)
        {
            var effectiveBits = (byte)(synchSafe ? 7 : 8);
            var upperBound = bytes.GetUpperBound(0);
            short value = 0;

            for (var i = 0; i <= upperBound; i++)
            {
                // Syncsafed bytes should be less than 0x80 (128)
                if (synchSafe && (bytes[i] >= 0x80))
                    throw new Exception();

                value += (short)(bytes[i] * (Math.Pow(2, ((upperBound - i) * effectiveBits))));
            }

            return value;
        }

        public static byte[] LittleToBigEndianInt32(int value, bool synchSafe = false)
        {
            var effectiveBits = (byte)(synchSafe ? 7 : 8);
            var bytes = new byte[4];
            var byteIndex = 0;

            while (value > 0)
            {
                bytes[3 - byteIndex] = ((byte)(value & (byte)(Math.Pow(2, effectiveBits) - 1)));
                value = value >> effectiveBits;
                byteIndex++;
            }

            return bytes;
        }

        public static byte[] LittleToBigEndianInt16(short value, bool synchSafe = false)
        {
            var effectiveBits = (byte)(synchSafe ? 7 : 8);
            var bytes = new byte[2];
            var byteIndex = 0;

            while (value > 0)
            {
                bytes[1 - byteIndex] = ((byte)(value & (byte)(Math.Pow(2, effectiveBits) - 1)));
                value = (short)(value >> effectiveBits);
                byteIndex++;
            }

            return bytes;
        }
    }
}
