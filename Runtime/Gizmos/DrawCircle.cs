using UnityEngine;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		//TODO .matrix usage

		const int circleResolution = 16;

		public static void DrawCircle(Vector3 center, float radius) => DrawCircle(center, radius, Quaternion.identity);
		public static void DrawCircle(Vector3 center, float radius, Vector3 up) => DrawCircle(center, radius, Quaternion.LookRotation(Vector3.up, up));
		public static void DrawCircle(Vector3 center, float radius, Quaternion rotation)
		{
			Vector3[] points = new Vector3[circleResolution];

			var step = 2f * Mathf.PI / circleResolution;
			for (int i = 0; i < circleResolution; i++)
			{
				var angle = step * i;
				points[i].x = Mathf.Cos(angle) * radius;
				points[i].z = Mathf.Sin(angle) * radius;
			}

			var lastMatrix = matrix;
			matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
			
			DrawLoop(points);

			matrix = lastMatrix;
		}
	}
}