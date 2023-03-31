using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGizmos = UnityEngine.Gizmos;

namespace PolygonArcana.Essentials
{
	public static partial class Gizmos
	{
		public static float probeSize { get => UGizmos.probeSize; }
		public static Matrix4x4 matrix { get => UGizmos.matrix; set => UGizmos.matrix = value; }
		public static Color color { get => UGizmos.color; set => UGizmos.color = value; }
		public static Texture exposure { get => UGizmos.exposure; set => UGizmos.exposure = value; }
		public static void DrawCube(Vector3 center, Vector3 size) => UGizmos.DrawCube(center, size);
		public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect) => UGizmos.DrawFrustum(center, fov, maxRange, minRange, aspect);
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder) => UGizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder);
		public static void DrawGUITexture(Rect screenRect, Texture texture, Material mat) => UGizmos.DrawGUITexture(screenRect, texture, mat);
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat) => UGizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat);
		public static void DrawGUITexture(Rect screenRect, Texture texture) => UGizmos.DrawGUITexture(screenRect, texture);
		public static void DrawIcon(Vector3 center, string name,  bool allowScaling) => DrawIcon(center, name, allowScaling);
		public static void DrawIcon(Vector3 center, string name,  bool allowScaling, Color tint) => UGizmos.DrawIcon(center, name, allowScaling, tint);
		public static void DrawIcon(Vector3 center, string name) => UGizmos.DrawIcon(center, name);
		public static void DrawLine(Vector3 from, Vector3 to) => UGizmos.DrawLine(from, to);
		public static void DrawMesh(Mesh mesh) => UGizmos.DrawMesh(mesh);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale) => UGizmos.DrawMesh(mesh, submeshIndex, position, rotation, scale);
		public static void DrawMesh(Mesh mesh, Vector3 position) => UGizmos.DrawMesh(mesh, position);
		public static void DrawMesh(Mesh mesh, int submeshIndex) => UGizmos.DrawMesh(mesh, submeshIndex);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation) => UGizmos.DrawMesh(mesh, submeshIndex, position, rotation);
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation) => UGizmos.DrawMesh(mesh, position, rotation);
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale) => UGizmos.DrawMesh(mesh, position, rotation, scale);
		public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position) => UGizmos.DrawMesh(mesh, submeshIndex, position);
		public static void DrawRay(Vector3 from, Vector3 direction) => UGizmos.DrawRay(from, direction);
		public static void DrawRay(Ray r) => UGizmos.DrawRay(r);
		public static void DrawSphere(Vector3 center, float radius) => UGizmos.DrawSphere(center, radius);
		public static void DrawWireCube(Vector3 center, Vector3 size) => UGizmos.DrawWireCube(center, size);
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation) => UGizmos.DrawWireMesh(mesh, position, rotation);
		public static void DrawWireMesh(Mesh mesh, Vector3 position) => UGizmos.DrawWireMesh(mesh, position);
		public static void DrawWireMesh(Mesh mesh) => UGizmos.DrawWireMesh(mesh);
		public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale) => UGizmos.DrawWireMesh(mesh, position, rotation, scale);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation) => UGizmos.DrawWireMesh(mesh, submeshIndex, position, rotation);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex) => UGizmos.DrawWireMesh(mesh, submeshIndex);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Vector3 scale) => UGizmos.DrawWireMesh(mesh, submeshIndex, position, rotation, scale);
		public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position) => UGizmos.DrawWireMesh(mesh, submeshIndex, position);
		public static void DrawWireSphere(Vector3 center, float radius) => UGizmos.DrawWireSphere(center, radius);
	}
}