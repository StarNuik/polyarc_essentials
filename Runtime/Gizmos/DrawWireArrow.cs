using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Utilities
{
	using Debug = UnityEngine.Debug;
	public partial class Gizmos
	{
		const float arrowStemWidth = 0.6f;
		const float arrowHeadSize = 1.75f;
		static readonly Vector3 arrowUp = Vector3.up;

		public static void DrawArrow(Vector3 from, Vector3 to, float stemWidth = arrowStemWidth, float headSize = arrowHeadSize) => DrawArrow(from, to, arrowUp, stemWidth, headSize);
		public static void DrawArrow(Vector3 from, Vector3 to, Vector3 up, float stemWidth = arrowStemWidth, float headSize = arrowHeadSize)
		{
			var length = Vector3.Distance(from, to);
			if (headSize > length) Debug.LogWarning("A degenerate arrow is being drawn. Poke @StarNuik, so that he finishes this part of the code.");
			
			matrix = Matrix4x4.identity;

			var direction = (to - from).normalized;
			if (direction == Vector3.zero) return;
			var look = Quaternion.LookRotation(direction, up) * Quaternion.Euler(0f, -90f, 0f);
			var inverseLook = Quaternion.Inverse(look);
			direction = inverseLook * direction;
			from = inverseLook * from;
			to = inverseLook * to;

			var center = Vector3.Lerp(from, to, 0.5f);
			from -= center;
			to -= center;

			
			var headPoint = to - direction * headSize;
			var stemCenter = Vector3.Lerp(from, headPoint, 0.5f);
			var rect = new Rect(
				Vector3.zero,
				new Vector2(Vector3.Distance(from, headPoint), stemWidth)
			);

			center = look * center;
			var matrixOriginal = matrix;
			var trs = Matrix4x4.TRS(
				center,
				look,
				Vector3.one
			);
			matrix = matrix * trs;
		
			DrawRect(stemCenter, rect);

			var headOffset = Vector3.forward * headSize * 0.5f;
			Vector3[] headPoints = new Vector3[3];
			headPoints[0] = to;
			headPoints[1] = headPoint + headOffset;
			headPoints[2] = headPoint - headOffset;

			DrawLoop(headPoints);

			matrix = matrixOriginal;
		}

		
	}
}