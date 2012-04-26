using System;
using System.Drawing;

namespace Rhapsody.UI
{
    internal interface IInfoProvider
    {
        string Name
        {
            get;
        }

        Image Icon
        {
            get;
        }

        void ShowArtistInfo(string name);

        void ShowAlbumInfo(string name);
    }
}
