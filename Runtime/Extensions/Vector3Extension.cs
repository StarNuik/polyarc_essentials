using UnityEngine;

namespace PolygonArcana.Essentials
{

    public static class Vector3Extensions
    {
        public static Vector3 RandomVector(this Vector3 vector, float offset)
        {
            float x = Random.Range(vector.x - offset, vector.x + offset);
            float y = Random.Range(vector.y - offset, vector.y + offset);
            float z = Random.Range(vector.z - offset, vector.z + offset);

            return new Vector3(x, y, z);
        }

		public static Vector3 Horizontal(this Vector3 vector)
		{
			return new Vector3(vector.x, 0f, vector.z);
		}
    }
}