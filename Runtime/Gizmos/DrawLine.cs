using UnityEngine;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		public static void DrawLine(Vector3[] points)
		{
			int limit = points.Length - 1;
			for (int i = 0; i < limit; i++)
			{
				DrawLine(points[i], points[i + 1]);
			}
		}
	}
}