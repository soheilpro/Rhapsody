using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rhapsody.Utilities
{
    internal static class DirectoryInfoHelper
    {
        public static IEnumerable<FileInfo> EnumerateFilesEx(this DirectoryInfo directory, string searchPatternExpression = "", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var searchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);
            
            return directory.EnumerateFiles("*", searchOption).Where(file => searchPattern.IsMatch(Path.GetExtension(file.FullName)));
        }
    }
}
