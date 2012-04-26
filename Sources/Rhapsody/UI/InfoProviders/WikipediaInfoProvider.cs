using System;
using System.Diagnostics;
using System.Drawing;
using Rhapsody.Resources;

namespace Rhapsody.UI.InfoProviders
{
    internal class WikipediaInfoProvider : IInfoProvider
    {
        public string Name
        {
            get
            {
                return "Wikipedia";
            }
        }

        public Image Icon
        {
            get
            {
                return Images.Wikipedia;
            }
        }

        public void ShowArtistInfo(string name)
        {
            var url = string.Format("http://en.wikipedia.org/wiki/Special:Search?search={0}&go=Go", Uri.EscapeDataString(name));
            Process.Start(url);
        }

        public void ShowAlbumInfo(string name)
        {
            var url = string.Format("http://en.wikipedia.org/wiki/Special:Search?search={0}&go=Go", Uri.EscapeDataString(name));
            Process.Start(url);
        }
    }
}
