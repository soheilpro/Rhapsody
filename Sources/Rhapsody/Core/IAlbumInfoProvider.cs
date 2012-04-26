using System;
using System.Drawing;

namespace Rhapsody.Core
{
    internal interface IAlbumInfoProvider
    {
        string Name
        {
            get;
        }

        Image Icon
        {
            get;
        }

        AlbumInfo GetAlbumInfo(Album album, Session session, Context context);
    }
}
