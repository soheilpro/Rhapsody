using System;
using System.Drawing;

namespace Rhapsody.Core
{
    internal interface IAlbumCoverProvider
    {
        string Name
        {
            get;
        }

        Image Icon
        {
            get;
        }

        Picture GetCover(string artistName, string albumName, Session session, Context context);
    }
}
