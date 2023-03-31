using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class GameObjectExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool MaskOverlaps(this GameObject gameObject, LayerMask layerMask)
		{
			return (gameObject.layer & layerMask.value) > 0;
		}
	}
}