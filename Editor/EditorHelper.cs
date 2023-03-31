using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

#if UNITY_EDITOR
using UnityEditor;
#endif

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