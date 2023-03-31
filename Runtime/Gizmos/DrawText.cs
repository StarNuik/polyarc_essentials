using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PolygonArcana.Utilities
{
	public partial class Gizmos
	{
		static readonly GUIStyle textStyle = GUI.skin.label;

		private static GUIStyle TextRestyle(GUIStyle original, Color color, FontStyle? fontStyle = null, int? fontSize = null)
		{
			var style = new GUIStyle(textStyle);
			style.normal.textColor = color;
			if (fontStyle.HasValue) style.fontStyle = fontStyle.Value;
			if (fontSize.HasValue) style.fontSize = fontSize.Value;
			return style;
		}

		public static void DrawText(Vector3 position, string text) => DrawText(position, text, TextRestyle(textStyle, color));
		public static void DrawText(Vector3 position, string text, FontStyle? fontStyle = null, int? fontSize = null) => DrawText(position, text, TextRestyle(textStyle, color, fontStyle, fontSize));
		public static void DrawText(Vector3 position, string text, GUIStyle style)
		{
			#if UNITY_EDITOR
			Handles.Label(position, text, style);
			#endif
		}
	}
}