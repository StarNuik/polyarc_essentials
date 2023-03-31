using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public interface ISaveable<T>
	{
		T Value { get; set; }
		
		void Set(T value);
	}
}