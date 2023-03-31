using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class Vector3Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 X0Z(this Vector3 vector)
		{
			return new Vector3(vector.x, 0f, vector.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 XY0(this Vector3 vector)
		{
			return new Vector3(vector.x, vector.y, 0f);
		}
	}
}