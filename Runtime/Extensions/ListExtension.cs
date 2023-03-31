using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static class ListExtension
	{
		public static T Random<T>(this List<T> list)
		{
			if (list == null || list.Count == 0) return default(T);
			
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
	}
}