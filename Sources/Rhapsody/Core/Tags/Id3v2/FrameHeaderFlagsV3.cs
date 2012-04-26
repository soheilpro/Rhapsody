using System;

namespace Rhapsody.Core.Tags.Id3v2
{
    [Flags]
    internal enum FrameHeaderFlagsV3
    {
        None = 0x0,
        GroupingIdentity = 0x20,
        Encryption = 0x40,
        Compression = 0x80,
        ReadOnly = 0x2000,
        FileAlterPreservation = 0x4000,
        TagAlterPreservation = 0x8000
    }
}
