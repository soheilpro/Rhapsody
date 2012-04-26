using System;

namespace Rhapsody.Utilities
{
    internal static class VersionHelper
    {
        public static string GetAppVersion()
        {
            return StringHelper.ToString(typeof(Program).Assembly.GetName().Version);
        }
    }
}
