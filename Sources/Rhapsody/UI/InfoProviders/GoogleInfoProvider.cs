using System;
using System.Diagnostics;
using System.Drawing;
using Rhapsody.Resources;

namespace Rhapsody.UI.InfoProviders
{
    internal class GoogleInfoProvider : IInfoProvider
    {
        public string Name
        {
            get
            {
                return "Google";
            }
        }

        public Image Icon
        {
            get
            {
                return Images.Google;
            }
        }

        public void ShowArtistInfo(string name)
        {
            var url = string.Format("http://www.google.com/search?&q={0}", Uri.EscapeDataString(name));
            Process.Start(url);
        }

        public void ShowAlbumInfo(string name)
        {
            var url = string.Format("http://www.google.com/search?&q={0}", Uri.EscapeDataString(name));
            Process.Start(url);
        }
    }
}
