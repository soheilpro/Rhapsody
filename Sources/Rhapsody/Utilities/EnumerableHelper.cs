using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Rhapsody.Utilities
{
    internal static class EnumerableHelper
    {
        [DebuggerStepThrough]
        public static ICollection<T> Cache<T>(this IEnumerable<T> list)
        {
            if (list is ICollection<T>)
                return (ICollection<T>)list;

            return list.ToArray();
        }

        public static K MostCommon<T, K>(this IEnumerable<T> items, Func<T, K> selector)
        {
            return items.GroupBy(selector).OrderByDescending(item => item.Count()).Select(item => item.Key).FirstOrDefault();
        }

        public static T MostCommon<T>(this IEnumerable<T> items)
        {
            return MostCommon(items, item => item);
        }

        public static bool AllEqual<T, K>(this IEnumerable<T> items, Func<T, K> selector) where K : IComparable
        {
            using (var enumerator = items.GetEnumerator())
            {
                // Empty list
                if (!enumerator.MoveNext())
                    return true;

                var id = selector(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    if (id.CompareTo(selector(enumerator.Current)) != 0)
                        return false;
                }
            }

            return true;
        }
    }
}
