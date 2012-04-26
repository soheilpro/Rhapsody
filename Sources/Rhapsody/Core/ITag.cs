using System;
using System.IO;

namespace Rhapsody.Core
{
    internal interface ITag
    {
        TagPosision Position
        {
            get;
        }

        int Size
        {
            get;
        }

        bool Read(Stream stream);
    }

    internal enum TagPosision
    {
        Beginning,
        End
    }
}
