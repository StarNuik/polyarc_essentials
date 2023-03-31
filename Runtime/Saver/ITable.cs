using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;

namespace PolygonArcana.Utilities
{
	public interface ITable
	{
		void Flush();
	}

	public interface ITable<T> : ITable
	{
		T this[string id] { get; set; }

		ASaveable<T> GetLink(string id);
	}
}