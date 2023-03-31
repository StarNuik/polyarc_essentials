using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
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