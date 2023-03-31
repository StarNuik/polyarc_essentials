using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public static class BoolExtension
	{
		public static bool SafeValue(this bool? meow)
		{
			return (meow.HasValue && meow.Value);
		}
	}
}