using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static partial class GizmosExt
	{
		public static float probeSize { get => Gizmos.probeSize; }
		public static Matrix4x4 matrix { get => Gizmos.matrix; set => Gizmos.matrix = value; }
		public static Color color { get => Gizmos.color; set => Gizmos.color = value; }
		public static Texture exposure { get => Gizmos.exposure; set => Gizmos.exposure = value; }
		public static void DrawCube(Vector3 center, Vector3 size) => Gizmos.DrawCube(center, size);
		public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect) => Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect);
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder) => Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder);
		public static void DrawGUITexture(Rect screenRect, Texture texture, Material mat) => Gizmos.DrawGUITexture(screenRect, texture, mat);
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat) => Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat);
		public static void DrawGUITexture(Rect screenRect, Texture texture) => Gizmos.DrawGUITexture(screenRect, texture);
		public static void DrawIcon(Vector3 center, string name,  bool allowScaling) => DrawIcon(center, name, allowScaling);
		public static void DrawIcon(Vector3 center, string name,  bool allowScaling, Color tint) => Gizmos.DrawIcon(center, name, allowScaling, tint);
		public static void DrawIcon(Vector3 center, string name) => Gizmos.DrawIcon(center, name);
		public static void DrawLine(Vector3 from, Vector3 to) => Gizmos.DrawLine(from, to);
		public static void DrawMesh(Mesh mesh) => Gizmos.DrawMesh(mesh);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale) => Gizmos.DrawMesh(mesh, submeshIndex, position, rotation, scale);
		public static void DrawMesh(Mesh mesh, Vector3 position) => Gizmos.DrawMesh(mesh, position);
		public static void DrawMesh(Mesh mesh, int submeshIndex) => Gizmos.DrawMesh(mesh, submeshIndex);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation) => Gizmos.DrawMesh(mesh, submeshIndex, position, rotation);
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation) => Gizmos.DrawMesh(mesh, position, rotation);
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale) => Gizmos.DrawMesh(mesh, position, rotation, scale);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position) => Gizmos.DrawMesh(mesh, submeshIndex, position);
		public static void DrawRay(Vector3 from, Vector3 direction) => Gizmos.DrawRay(from, direction);
		public static void DrawRay(Ray r) => Gizmos.DrawRay(r);
		public static void DrawSphere(Vector3 center, float radius) => Gizmos.DrawSphere(center, radius);
		public static void DrawWireCube(Vector3 center, Vector3 size) => Gizmos.DrawWireCube(center, size);
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation) => Gizmos.DrawWireMesh(mesh, position, rotation);
		public static void DrawWireMesh(Mesh mesh, Vector3 position) => Gizmos.DrawWireMesh(mesh, position);
		public static void DrawWireMesh(Mesh mesh) => Gizmos.DrawWireMesh(mesh);
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale) => Gizmos.DrawWireMesh(mesh, position, rotation, scale);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation) => Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex) => Gizmos.DrawWireMesh(mesh, submeshIndex);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale) => Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation, scale);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position) => Gizmos.DrawWireMesh(mesh, submeshIndex, position);
		public static void DrawWireSphere(Vector3 center, float radius) => Gizmos.DrawWireSphere(center, radius);
	}
}