using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PolygonArcana.Utilities
{
	#if UNITY_EDITOR
	public class MatrixOverrideHandles : IDisposable
	{
		private Matrix4x4 oldMatrix;

		public MatrixOverrideHandles(Matrix4x4 matrix)
		{
			oldMatrix = Handles.matrix;
			Handles.matrix = matrix;
		}

		public void Dispose()
		{
			Handles.matrix = oldMatrix;
		}
	}
	#endif
}