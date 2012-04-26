using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rhapsody.Utilities
{
    internal static class StringHelper
    {
        private static char[] _wordSeparators = {' ', '.', ':', '(', '[', '/', '\\'};

        public static string Normalize(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = Trim(text);
            text = text.Replace("_", " ");
            text = MakeProperCase(text);

            return text;
        }

        public static string MakeFileSystemFriendly(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = Regex.Replace(text, "[^ ]:[^ ]", match => match.Value.Replace(":", "-")); // X:Y -> X - Y
            text = Regex.Replace(text, "[^ ]: ", match => match.Value.Replace(":", " -")); // X: Y -> X - Y
            text = text.Replace(":", "-");
            text = text.Replace("/", "-");

            foreach (var invalidChar in Path.GetInvalidFileNameChars())
                text = text.Replace(invalidChar.ToString(CultureInfo.InvariantCulture), " ");

            // It's not pretty to have dashes/underscores at the beginning/end
            text = text.Trim(' ', '-', '_');
            text = RemoveExtraSpaces(text);

            return text;
        }

        public static string Trim(string text, bool aggressive)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (aggressive)
                return text.Trim(' ', '-');

            return text.Trim();
        }

        public static string Trim(string text)
        {
            return Trim(text, false);
        }

        public static bool IsProperlyCased(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            return (text == MakeProperCase(text));
        }

        public static string MakeProperCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var result = string.Empty;
            var makeUpper = true;

            for (var i = 0; i < text.Length; i++)
            {
                var currentChar = text[i];

                if (ArrayHelper.Contains(_wordSeparators, currentChar))
                {
                    makeUpper = true;
                }
                else
                {
                    if (makeUpper)
                    {
                        currentChar = char.ToUpper(currentChar);
                        makeUpper = false;
                    }
                    else
                    {
                        currentChar = char.ToLower(currentChar);
                    }
                }

                result += currentChar;
            }

            result = Regex.Replace(result, @"\bOK\b", "OK", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bI\b", "I", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bII\b", "II", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bIII\b", "III", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bIV\b", "IV", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bIV\b", "IV", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bV\b", "V", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bVI\b", "VI", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bVII\b", "VII", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bVIII\b", "VIII", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bV\.?S\b", "V.S", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bCD\b", "CD", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bDVD\b", "DVD", RegexOptions.IgnoreCase);

            return result;
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);

            return stringBuilder.ToString();
        }

        public static string ReplaceCommonWrongChars(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = text.Replace("´", "'");
            text = text.Replace("`", "'");

            return text;
        }

        public static bool HasExtraSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return (text.IndexOf("  ", StringComparison.Ordinal) > -1);
        }

        public static string RemoveExtraSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            while (text.IndexOf("  ", StringComparison.Ordinal) > -1)
                text = text.Replace("  ", " ");

            return text;
        }

        public static bool HasInvalidNameCharacters(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return (GetInvalidNameCharacters(name).Any());
        }

        public static IEnumerable<string> GetInvalidNameCharacters(string name)
        {
            if (string.IsNullOrEmpty(name))
                yield break;

            foreach (Match match in Regex.Matches(name, @"[^a-zA-Z0-9()!#&%:',?/\.\- ]"))
                yield return match.Value;
        }

        public static bool IsValidYear(string year)
        {
            if (string.IsNullOrEmpty(year))
                return false;

            return Regex.IsMatch(year, @"^\d{4}$");
        }

        public static string ToString(Version version)
        {
            var fieldCount = 4;

            if (version.Revision <= 0)
            {
                fieldCount--;

                if (version.Build <= 0)
                    fieldCount--;
            }

            return version.ToString(fieldCount);
        }

        public static string RemoveDuplicateWords(string text)
        {
            var lastWord = string.Empty;

            text = Regex.Replace(text, @"\b\w+\b", delegate(Match match)
            {
                if (lastWord == match.Value)
                    return string.Empty;

                lastWord = match.Value;

                return match.Value;
            });

            return text;
        }

        public static bool AreNumberSignsNotFollowedByADigit(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            foreach (Match match in Regex.Matches(text, "#(?<post>.?)"))
                if (match.Length != 2 || !char.IsDigit(match.Groups["post"].Value[0]))
                    return true;

            return false;
        }

        public static string RemoveSpacesAfterNumberSigns(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            while (text.IndexOf("# ", StringComparison.Ordinal) != -1)
                text = text.Replace("# ", "#");

            return text;
        }

        /// <returns>
        /// True for:
        ///     a/b
        ///     /b
        ///     a/
        /// 
        /// False for:
        ///     a / b
        ///     / b
        ///     a /
        /// </returns>
        public static bool AreSlashesNotSurroundedBySpace(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            foreach (Match match in Regex.Matches(text, "(?<pre>.?)/(?<post>.?)"))
            {
                var pre = match.Groups["pre"].Value;
                var post = match.Groups["post"].Value;

                if (pre.Length > 0 && pre != " ")
                    return true;

                if (post.Length > 0 && post != " ")
                    return true;
            }

            return false;
        }

        public static string SurroundSlashesBySpace(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = Regex.Replace(text, "(?<pre>.?)/(?<post>.?)", delegate(Match match)
            {
                var pre = match.Groups["pre"].Value;
                var post = match.Groups["post"].Value;

                if (pre.Length > 0 && pre != " ")
                    pre = pre + " ";

                if (post.Length > 0 && post != " ")
                    post = " " + post;

                return string.Format("{0}/{1}", pre, post);
            });

            return text;
        }

        public static bool IsMissingApostrophe(string text)
        {
            // Confusing: "it's", "we're", "we'll", "he'll", "she'll", "i'll"
            // Web service detects all but: whats, cant, wheres

            string[] apostropheWords = {"aint", "im", "youre", "cant", "dont", "doesnt", "wasnt", "werent", "shouldnt", "couldnt", "youll", "whats", "wheres", "whos"};
            var words = text.ToLower().Split(_wordSeparators);

            foreach (var word1 in words)
                foreach (var word2 in apostropheWords)
                    if (word1 == word2)
                        return true;

            return false;
        }
    }
}
