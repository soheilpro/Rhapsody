using System;
using System.Diagnostics;
using System.Drawing;
using Rhapsody.Resources;

namespace Rhapsody.UI.InfoProviders
{
    internal class LastFmInfoProvider : IInfoProvider
    {
        public string Name
        {
            get
            {
                return "Last.fm";
            }
        }

        public Image Icon
        {
            get
            {
                return Images.LastFm;
            }
        }

        public void ShowArtistInfo(string name)
        {
            var url = string.Format("http://www.last.fm/search?q={0}&type=artist", Uri.EscapeDataString(name));
            Process.Start(url);
        }

        public void ShowAlbumInfo(string name)
        {
            var url = string.Format("http://www.last.fm/search?q={0}&type=album", Uri.EscapeDataString(name));
            Process.Start(url);
        }
    }
}
