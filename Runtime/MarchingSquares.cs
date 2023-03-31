using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using Zenject;
using PolygonArcana.Utilities;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	using TilePosition = Vector2Int;
	using SquarePosition = Vector2Int;

	public class MarchingSquares
	{
		private Transform rootTransform;
		private Material material;
		private HashSet<TilePosition> tiles = new();
		private Dictionary<SquarePosition, MeshRenderer> meshMap = new();

		public MarchingSquares(
			Transform root,
			Material material
		)
		{
			rootTransform = root;
			this.material = material;
		}

		public void OnDrawGizmos()
		{
			foreach (var pair in meshMap)
			{
				for (int x = 0; x < 2; x++)
					for (int y = 0; y < 2; y++)
					{
						var offset = new Vector2Int(x, y);
						bool sample = SampleFunction(pair.Key + offset);
						var color = sample ? Color.white : Color.black;
						Gizmos.color = color;
						Gizmos.DrawSphere(rootTransform.TransformPoint(ToLocal(pair.Key + offset)), 0.15f);
					}
			}

		}

		public void Set(IEnumerable<Vector2Int> collection)
		{
			tiles = new(collection);
		}

		public void Add(Vector2Int position)
		{
			tiles.Add(position);
		}

		public void Remove(Vector2Int position)
		{
			tiles.Remove(position);
		}

		private Vector3 ToLocal(Vector2Int square) => new Vector3(square.x, 0f, square.y);

		public void Refresh(bool preferConnections = false)
		{
			HashSet<SquarePosition> roots = new();

			foreach (var tile in tiles)
			{
				for (int x = -1; x <= 0; x++)
					for (int y = -1; y <= 0; y++)
					{
						var offset = new Vector2Int(x, y);
						var rootPosition = tile + offset;

						roots.Add(rootPosition);
					}
			}

			ResizeMeshMap(roots.Count);

			var eRoots = roots.GetEnumerator();
			var meshList = new List<KeyValuePair<Vector2Int, MeshRenderer>>(meshMap);
			meshMap = new();
			for (int i = 0; i < roots.Count; i++)
			{
				eRoots.MoveNext();

				var square = eRoots.Current;
				var originalPair = meshList[i];
				var info = SampleTiles(square, preferConnections);
				if (info.x05y05 == true) Debug.Log(info);
				var mesh = MarchingSquaresMeshes.Get(info);
				var renderer = originalPair.Value;
				
				var filter = renderer.GetComponent<MeshFilter>();
				filter.mesh = mesh;
				meshMap.Add(square, renderer);
			}

			foreach (var pair in meshMap)
			{
				var t = pair.Value.transform;
				t.localPosition = ToLocal(pair.Key);
			}
		}

		private void ResizeMeshMap(int toSize)
		{
			var fromSize = meshMap.Count;

			if (fromSize == toSize) return;

			if (fromSize > toSize)
			{
				var diff = fromSize - toSize;
				var e = meshMap.GetEnumerator();
				var remove = new List<Vector2Int>();
				for (int i = 0; i < diff; i++)
				{
					e.MoveNext();
					remove.Add(e.Current.Key);
				}

				foreach (var square in remove)
				{
					Object.Destroy(meshMap[square].gameObject);
					meshMap.Remove(square);
				}
			}

			if (fromSize < toSize)
			{
				var diff = toSize - fromSize;
				for (int i = 0; i < diff; i++)
				{
					var gameobject = new GameObject("[SQUARE]");
					gameobject.transform.SetParent(rootTransform);
					gameobject.AddComponent<MeshFilter>();
					MeshRenderer renderer = gameobject.AddComponent<MeshRenderer>();
					renderer.material = material;
					meshMap.Add(GetRandomKey(), renderer);
				}
			}
		}

		private Vector2Int _buffer = Vector2Int.one * int.MaxValue;
		private Vector2Int GetRandomKey()
		{
			//> this is complete garbage
			//> however, this garbage is sized 2 ^ 32, so its okay, I guess
			while (meshMap.ContainsKey(_buffer))
			{
				_buffer = _buffer - Vector2Int.right;
			}
			return _buffer;
		}

		private MarchingInfo SampleTiles(SquarePosition root, bool preferConnections)
		{
			var info = new MarchingInfo
			{
				x0y0 = SampleFunction(root),
				x1y0 = SampleFunction(root + Vector2Int.right),
				x1y1 = SampleFunction(root + Vector2Int.one),
				x0y1 = SampleFunction(root + Vector2Int.up),
			};

			if (info.x0y0 && info.x1y1 && !info.x1y0 && !info.x0y1
				|| info.x0y1 && info.x1y0 && !info.x0y0 && !info.x1y1)
			{
				info.x05y05 = preferConnections;
			}

			return info;
		}

		private bool SampleFunction(SquarePosition position) => tiles.Contains(position);
	}

	#region Marching info struct
	internal struct MarchingInfo
	{
		public bool x0y0;
		public bool x1y0;
		public bool x1y1;
		public bool x0y1;
		public bool x05y05;

		public MarchingInfo(bool x0y0, bool x1y0, bool x1y1, bool x0y1, bool x05y05 = false)
		{
			this.x0y0 = x0y0;
			this.x1y0 = x1y0;
			this.x1y1 = x1y1;
			this.x0y1 = x0y1;
			this.x05y05 = x05y05;
		}

		// public override string ToString()
		// {
		// 	return "{x0y0: " + x0y0 + ", x1y0: " + x1y0 + ", x1y1: " + x1y1 + ", x0y1: " + x0y1 + ", x05y05: " + x05y05 + "}";
		// }
	}
	#endregion
	
	#region Meshes
	//? https://en.wikipedia.org/wiki/File:Marching_squares_isolines.svg
	internal static class MarchingSquaresMeshes
	{
		public static Mesh Get(MarchingInfo info) => meshes[info];

		private static Dictionary<MarchingInfo, Mesh> _meshes;
		private static Dictionary<MarchingInfo, Mesh> meshes
		{
			get
			{
				if (_meshes == null)
				{
					_meshes = MakeSquares();
				}

				return _meshes;
			}
		}

		private static Dictionary<MarchingInfo, Mesh> MakeSquares()
		{
			var result = new Dictionary<MarchingInfo, Mesh>();

			var indices = MakeIndices();
			var keys = MakeKeys();

			var vertices = MakeVertices().ToArray();
			var normals = MakeNormals().ToArray();

			for (int i = 0; i < 18; i++)
			{
				if (indices[i] == null)
				{
					result.Add(keys[i], null);
					continue;
				}

				var mesh = new Mesh();
				mesh.vertices = vertices;
				mesh.normals = normals;
				var list = new List<int>(indices[i]);
				list.Reverse();
				mesh.triangles = list.ToArray();

				result.Add(keys[i], mesh);
			}
			return result;
		}

		private static List<int[]> MakeIndices()
		{
			return new()
			{
				//> row 1
				null,
				new int[] {0, 2, 6, 2, 4, 6},

				//> row 2
				new int[] {0, 1, 7},
				new int[] {1, 2, 3},
				new int[] {1, 4, 7, 1, 2, 4, 4, 6, 7},
				new int[] {1, 3, 6, 0, 1, 6, 3, 4, 6},
				
				//> row 3
				new int[] {5, 6, 7},
				new int[] {3, 4, 5},
				new int[] {2, 5, 7, 0, 2, 7, 2, 4, 5},
				new int[] {0, 3, 5, 0, 2, 3, 0, 5, 6},
				
				//> row 4
				new int[] {1, 2, 4, 1, 4, 5},
				new int[] {3, 4, 7, 4, 6, 7},
				new int[] {1, 2, 3, 5, 6, 7},
				new int[] {0, 1, 7, 3, 4, 5},
				
				//> row 5
				new int[] {0, 2, 3, 0, 3, 7},
				new int[] {0, 1, 5, 0, 5, 6},
				new int[] {1, 2, 3, 5, 6, 7, 1, 3, 7, 3, 5, 7},
				new int[] {0, 1, 7, 3, 4, 5, 1, 3, 5, 1, 5, 7},

			};
		}

		private static List<MarchingInfo> MakeKeys()
		{
			return new()
			{
				//> row 1
				new(false, false, false, false),
				new(true, true, true, true),
				
				//> row 2
				new(true, false, false, false),
				new(false, true, false, false),
				new(false, true, true, true),
				new(true, false, true, true),

				//> row 3
				new(false, false, false, true),
				new(false, false, true, false),
				new(true, true, true, false),
				new(true, true, false, true),

				//> row 4
				new(false, true, true, false),
				new(false, false, true, true),
				new(false, true, false, true, false),
				new(true, false, true, false, false),

				//> row 5
				new(true, true, false, false),
				new(true, false, false, true),
				new(false, true, false, true, true),
				new(true, false, true, false, true),
			};
		}

		private static List<Vector3> MakeVertices()
		{
			return new()
			{
				new(0f, 0f, 0f),	//? 0 Top Left
				new(.5f, 0f, 0f),	//? 1	Top Middle
				new(1f, 0f, 0f),	//? 2 Top Right
				new(1f, 0f, .5f),	//? 3	Middle Right
				new(1f, 0f, 1f),	//? 4 Bottom Right
				new(.5f, 0f, 1f),	//? 5	Bottom Middle
				new(0f, 0f, 1f),	//? 6 Bottom Left
				new(0f, 0f, .5f),	//? 7	Middle Left
			};
		}

		private static List<Vector3> MakeNormals()
		{
			return new()
			{
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
			};
		}
	}
	#endregion
}