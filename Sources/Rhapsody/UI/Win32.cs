using System;

namespace Rhapsody.UI
{
    internal static class Win32
    {
        public const int WM_NCHITTEST = 0x0084;

        public enum HitTest
        {
            Caption = 2,
            Transparent = -1,
            Nowhere = 0,
            Client = 1,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
            Border = 18
        }
    }
}
