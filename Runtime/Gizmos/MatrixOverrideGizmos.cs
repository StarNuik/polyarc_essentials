using System;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MatrixOverrideGizmos WithMatrix(Matrix4x4 matrix)
		{
			return new MatrixOverrideGizmos(matrix);
		}
	}

	public class MatrixOverrideGizmos : IDisposable
	{
		private bool wasDisposed;
		private Matrix4x4 oldMatrix;

		public MatrixOverrideGizmos(Matrix4x4 matrix)
		{
			oldMatrix = GizmosExt.matrix;
			wasDisposed = false;

			GizmosExt.matrix = matrix;
		}

		~MatrixOverrideGizmos()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (wasDisposed) return;

			GizmosExt.matrix = oldMatrix;

			wasDisposed = true;
		}
	}
}