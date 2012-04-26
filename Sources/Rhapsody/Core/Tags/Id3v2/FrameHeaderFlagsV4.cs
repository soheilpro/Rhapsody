using System;

namespace Rhapsody.Core.Tags.Id3v2
{
    [Flags]
    internal enum FrameHeaderFlagsV4 : short
    {
        None = 0x0,
        DataLengthIndicator = 0x1,
        Unsynchronisation = 0x2,
        Encryption = 0x4,
        Compression = 0x8,
        GroupingIdentity = 0x40,
        ReadOnly = 0x1000,
        FileAlterPreservation = 0x2000,
        TagAlterPreservation = 0x4000
    }
}
