using UnityEngine;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		//TODO .matrix usage
		
		public static void DrawRect(Vector3 center, Rect rect) => DrawRect(center, rect, Quaternion.identity);
		public static void DrawRect(Vector3 center, Rect rect, Vector3 up) => DrawRect(center, rect, Quaternion.LookRotation(Vector3.up, up));
		public static void DrawRect(Vector3 center, Rect rect, Quaternion rotation)
		{
			center = center - ToXZ(rect.center);

			Vector3[] points = new Vector3[4];
			
			points[0] = center + ToXZ(rect.min);
			points[2] = center + ToXZ(rect.max);
			
			points[1] = points[0];
			points[1].x = points[2].x;

			points[3] = points[0];
			points[3].z = points[2].z;

			var matrixOriginal = matrix;
			matrix = matrix * Matrix4x4.Rotate(rotation);

			DrawLoop(points);

			matrix = matrixOriginal;			
		}
	}
}