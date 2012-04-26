using System;

namespace Rhapsody.Core.Tags.Id3v2
{
    [Flags]
    internal enum TagHeaderFlags : byte
    {
        None = 0x0,
        FooterPresent = 0x10,
        ExperimentalIndicator = 0x20,
        ExtendedHeader = 0x40,
        Unsynchronisation = 0x80
    };
}
