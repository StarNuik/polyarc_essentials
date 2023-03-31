using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Utilities
{
	public partial class Gizmos
	{
		public static void DrawLoop(Vector3[] points)
		{
			DrawLine(points);
			DrawLine(points[0], points[points.Length - 1]);
		}
	}
}
