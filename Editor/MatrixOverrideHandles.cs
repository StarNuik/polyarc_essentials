using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PolygonArcana.Essentials
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