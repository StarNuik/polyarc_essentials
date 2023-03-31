using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;

namespace PolygonArcana.Utilities
{
	public interface IHave<T>
	{
		void Get(out T value);
	}
}