using UnityEngine;
using UnityEngine.Assertions;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class LayerMaskExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Contains(this LayerMask layerMask, GameObject gameObject)
		{
			Assert.IsNotNull(gameObject);
			return (gameObject.layer & layerMask.value) > 0;
		}
	}
}