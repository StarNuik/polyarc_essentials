using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public interface IHave<T>
	{
		void Get(out T value);
	}
}