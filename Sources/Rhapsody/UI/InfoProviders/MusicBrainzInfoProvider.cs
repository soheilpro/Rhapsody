using System;
using System.Diagnostics;
using System.Drawing;
using Rhapsody.Resources;

namespace Rhapsody.UI.InfoProviders
{
    internal class MusicBrainzInfoProvider : IInfoProvider
    {
        public string Name
        {
            get
            {
                return "MusicBrainz";
            }
        }

        public Image Icon
        {
            get
            {
                return Images.MusicBrainz;
            }
        }

        public void ShowArtistInfo(string name)
        {
            var url = string.Format("http://musicbrainz.org/search?query={0}&type=artist", Uri.EscapeDataString(name));
            Process.Start(url);
        }

        public void ShowAlbumInfo(string name)
        {
            var url = string.Format("http://musicbrainz.org/search?query={0}&type=release", Uri.EscapeDataString(name));
            Process.Start(url);
        }
    }
}
