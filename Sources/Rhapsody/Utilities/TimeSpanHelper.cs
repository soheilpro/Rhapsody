using System;

namespace Rhapsody.Utilities
{
    internal static class TimeSpanHelper
    {
        public static string ToMinuteString(this TimeSpan time)
        {
            var minutes = (int)(time.TotalSeconds / 60);
            var seconds = (int)(time.TotalSeconds % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
