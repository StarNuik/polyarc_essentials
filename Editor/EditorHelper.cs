using UnityEngine;
using System.Diagnostics;
using UnityEditor;

namespace PolygonArcana.Essentials
{
	public static class EditorHelper
	{
		[Conditional("UNITY_EDITOR")]
		public static void SaveAsset(Object obj)
		{
			EditorUtility.SetDirty(obj);
			AssetDatabase.SaveAssetIfDirty(obj);
		}

		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(Object obj)
		{
			EditorUtility.SetDirty(obj);
		}
	}
}