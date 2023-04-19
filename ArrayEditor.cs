using System;
using System.Linq;

public static class Extensions
{
	/// <summary>
        /// Inserts thing into array, increasing the size of array by 1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <param name="placement">if not set, will add onto the end of array</param>
        /// <returns>Returns edited array</returns>
        public static T[] Insert<T>(this T[] array, T item, int placement = -1)
        {
            if (array == null)
                return new T[] { item };

            int length = array.Length;
            int newLength = length + 1;

            if (placement < 0 || placement >= length)
                placement = length;

            T[] newArray = new T[newLength];
            int i = 0;

            for (; i < placement; i++)
                newArray[i] = array[i];

            newArray[i] = item;

            for (; i < length; i++)
                newArray[i + 1] = array[i];

            return newArray;
        }
}
