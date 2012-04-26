using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Rhapsody.Resources;

namespace Rhapsody.Core.CoverArtProvider
{
    internal class LastFmAlbumCoverProvider : IAlbumCoverProvider
    {
        private const string ApiKey = @"b25b959554ed76058ac220b7b2e0a026";

        public string Name
        {
            get
            {
                return "last.fm";
            }
        }

        public Image Icon
        {
            get
            {
                return Images.LastFm;
            }
        }

        public Picture GetCover(string artistName, string albumName, Session session, Context context)
        {
            var url = @"http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key={apikey}&artist={artist}&album={album}&autocorrect=1";
            url = url.Replace("{apikey}", ApiKey);
            url = url.Replace("{artist}", Uri.EscapeDataString(artistName));
            url = url.Replace("{album}", Uri.EscapeDataString(albumName));

            var imageSizes = new[] { "mega", "extralarge" };

            try
            {
                var document = XDocument.Load(url);
                var lfmElement = document.Element("lfm");

                if (lfmElement.Attribute("status").Value != "ok")
                    return null;

                var imageElements = lfmElement.Element("album").Elements("image").Where(element => element.Value != string.Empty && imageSizes.Contains(element.Attribute("size").Value));
                var imageElement = imageElements.OrderBy(element => Array.IndexOf(imageSizes, element.Attribute("size").Value)).FirstOrDefault();

                if (imageElement == null)
                    return null;

                using (var webClient = new WebClient())
                {
                    var data = webClient.DownloadData(imageElement.Value);
                    var mimeType = webClient.ResponseHeaders["Content-Type"];

                    return new Picture(data, mimeType);
                }
            }
            catch (WebException exception)
            {
                if (exception.Response is HttpWebResponse && ((HttpWebResponse)exception.Response).StatusCode == HttpStatusCode.BadRequest)
                    return null;

                throw;
            }
        }
    }
}
