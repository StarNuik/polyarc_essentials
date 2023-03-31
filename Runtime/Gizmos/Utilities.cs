using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector3 ToXZ(Vector2 vector)
		{
			return new Vector3(vector.x, 0f, vector.y);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector2 FromXZ(Vector3 vector)
		{
			return new Vector2(vector.x, vector.z);
		}
	}
}
