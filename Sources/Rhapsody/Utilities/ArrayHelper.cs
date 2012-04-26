using System;

namespace Rhapsody.Utilities
{
    internal static class ArrayHelper
    {
        public static bool Contains<T>(T[] array, T elementToFind) where T : IComparable<T>
        {
            foreach (var element in array)
                if (element.CompareTo(elementToFind) == 0)
                    return true;

            return false;
        }

        public static bool CompareArray(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (var i = 0; i < array1.Length; i++)
                if (array1[i] != array2[i])
                    return false;

            return true;
        }

        public static T[] SubArray<T>(this T[] array, int offset, int size)
        {
            var subArray = new T[size];

            Array.Copy(array, offset, subArray, 0, size);

            return subArray;
        }
    }
}
