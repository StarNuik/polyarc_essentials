using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class ListExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Random<T>(this List<T> list)
		{
			Assert.IsNotNull(list);
			Assert.IsTrue(list.Count > 0);

			var randomIndex = UnityEngine.Random.Range(0, list.Count);
			return list[randomIndex];
		}
	}
}