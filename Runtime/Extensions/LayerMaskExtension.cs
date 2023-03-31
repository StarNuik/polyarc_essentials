using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static class LayerMaskExtension
	{
		public static bool IsInside(this LayerMask mask, GameObject gameObject)
		{
			if (gameObject == null) return false;
			return IsInside(mask, gameObject.layer);
		}

		public static bool IsInside(this LayerMask mask, LayerMask other)
		{
			return ((1 << other.value) & mask.value) > 0;
		}
	}
}