using UnityEngine;
using System;
using UnityEditor;

namespace PolygonArcana.Essentials
{
	public class MatrixOverrideHandles : IDisposable
	{
		private bool wasDisposed;
		private Matrix4x4 oldMatrix;

		public MatrixOverrideHandles(Matrix4x4 matrix)
		{
			oldMatrix = Handles.matrix;
			wasDisposed = false;

			Handles.matrix = matrix;
		}

		~MatrixOverrideHandles()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (wasDisposed) return;

			Handles.matrix = oldMatrix;

			wasDisposed = true;
		}
	}
}