using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	public class NotImplementedTable<T> : ITable<T>
	{
		private Dictionary<string, T> table = new();

		public NotImplementedTable(string dirPath)
		{
			//> open & read the file
		}

		public virtual T this[string id]
		{
			get => table[id];
			set => table[id] = value;
		}

		public ASaveable<T> GetLink(string id)
		{
			//> i would prefer if Saveable-s didn't go through the get-set api
			Debug.Log("Using NotImplementedTable!");
			return new NotImplementedSaveable<T>(this, id);
		}

		public void Flush()
		{
			//> save to a file
			Debug.Log("Using NotImplementedTable!");
		}
	}
}