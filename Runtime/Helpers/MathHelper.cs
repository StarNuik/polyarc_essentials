using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static class MathHelper
	{
		public static Vector3 RayYPlaneIntersection(Vector3 origin, Vector3 direction, float y = 0f) => RayYPlaneIntersection(new Ray(origin, direction), y);
		public static Vector3 RayYPlaneIntersection(Ray ray, float y = 0f)
		{
			var vY = (y - ray.origin.y) / ray.direction.y;
			var dX = ray.direction.x * vY;
			var dZ = ray.direction.z * vY;
			return new Vector3(ray.origin.x + dX, y, ray.origin.z + dZ);
		}
	}
}