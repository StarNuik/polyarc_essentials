using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class TransformExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyTransform AsReadOnly(this Transform transform)
		{
			return new ReadOnlyTransform(transform);
		}
	}
}