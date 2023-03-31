using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Utilities
{
	public static partial class Gizmos
	{
		private static Vector3 ToXZ(Vector2 vector) => new Vector3(vector.x, 0f, vector.y);
		private static Vector2 FromXZ(Vector3 vector) => new Vector2(vector.x, vector.z);
	}
}
