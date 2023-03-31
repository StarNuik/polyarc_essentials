using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;

namespace PolygonArcana.Utilities
{
	public interface ISaver
	{
		T Get<T>(string id);
		void Set<T>(string id, T value);

		//> receive a saveable
		ASaveable<T> GetLink<T>(string id);
		
		//> save changes to the disk
		void Flush();

		//> inject attributes to an object
		void Inject(object target);
	}
}