using System;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public partial class GizmosExt
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ColorOverrideGizmos WithColor(Color color)
		{
			return new ColorOverrideGizmos(color);
		}
	}

	public class ColorOverrideGizmos : IDisposable
	{
		private bool wasDisposed;
		private Color oldColor;

		public ColorOverrideGizmos(Color color)
		{
			oldColor = GizmosExt.color;
			wasDisposed = false;

			GizmosExt.color = color;
		}

		~ColorOverrideGizmos()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (wasDisposed) return;

			GizmosExt.color = oldColor;

			wasDisposed = true;
		}
	}
}
