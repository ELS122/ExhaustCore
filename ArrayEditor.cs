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

		if (placement < 0)
			placement = array.Length;

		placement = Mathf.Clamp(placement, 0, array.Length);
		Array.Resize(ref array, array.Length + 1);
		for (int i = array.Length - 1; i > placement; i--)
			array[i] = array[i - 1];

		array[placement] = item;

		return array;
	}
}
