using System;
using System.Drawing;
using System.IO;

namespace Rhapsody.Core
{
    internal class Picture
    {
        public byte[] Data
        {
            get;
            private set;
        }

        public string MimeType
        {
            get;
            private set;
        }

        public Picture(byte[] data, string mimeType)
        {
            Data = data;
            MimeType = mimeType;
        }

        public Image ToImage()
        {
            using (var memoryStream = new MemoryStream(Data))
                return Image.FromStream(memoryStream);
        }

        public static Picture Load(string path)
        {
            var data = File.ReadAllBytes(path);
            var contentType = GetMimeTypeByExtension(Path.GetExtension(path));

            return new Picture(data, contentType);
        }

        public static string GetMimeTypeByExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case ".png":
                    return "image/png";

                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";

                case ".gif":
                    return "image/gif";
            }

            throw new NotSupportedException();
        }
        
        public static string GetExtensionByMimeType(string mimeType)
        {
            switch (mimeType.ToLower())
            {
                case "image/png":
                    return ".png";

                case "image/jpeg":
                case "image/jpg":
                    return ".jpg";

                case "image/gif":
                    return ".gif";
            }

            throw new NotSupportedException();
        }
    }
}
