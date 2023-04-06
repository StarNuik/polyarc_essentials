using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class Vector3Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 TakeX0Z(this Vector3 vector)
		{
			return new Vector3(vector.x, 0f, vector.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 TakeXY0(this Vector3 vector)
		{
			return new Vector3(vector.x, vector.y, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ToXY(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.y);
		}
	}
}