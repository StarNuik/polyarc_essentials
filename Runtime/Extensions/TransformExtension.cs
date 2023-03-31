using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static class TransformExtension
	{
		public static ReadOnlyTransform AsReadOnly(this Transform transform) => new ReadOnlyTransform(transform);
	}
}