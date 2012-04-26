using System;
using System.Collections.Generic;

namespace Rhapsody.Core
{
    internal class AlbumInfo
    {
        public string ArtistName
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ReleaseYear
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public Picture Cover
        {
            get;
            set;
        }

        public Dictionary<Disc, string> DiscNames
        {
            get;
            private set;
        }

        public Dictionary<Track, string> TrackNames
        {
            get;
            private set;
        }

        public AlbumInfo()
        {
            DiscNames = new Dictionary<Disc, string>();
            TrackNames = new Dictionary<Track, string>();
        }
    }
}
