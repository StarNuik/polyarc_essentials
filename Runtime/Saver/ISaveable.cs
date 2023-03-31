using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;

namespace PolygonArcana.Utilities
{
	public interface ISaveable<T>
	{
		T Value { get; set; }
		
		void Set(T value);
	}
}