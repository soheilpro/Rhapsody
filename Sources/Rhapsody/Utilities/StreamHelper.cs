using System;
using System.IO;

namespace Rhapsody.Utilities
{
    internal static class StreamHelper
    {
        public static void Copy(Stream source, Stream destination, long offset, long size)
        {
            source.Seek(offset, SeekOrigin.Begin);

            var bytesCopied = 0;

            while (bytesCopied < size)
            {
                var buffer = new byte[Math.Min(16 * 1024, size - bytesCopied)];
                var bytesRead = source.Read(buffer, 0, buffer.Length);

                destination.Write(buffer, 0, bytesRead);
                bytesCopied += bytesRead;
            }
        }
    }
}
