using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	public class NotImplementedSaveable<T> : ASaveable<T>
	{
		private T value;

		private ITable<T> table;
		private string id;

		public NotImplementedSaveable(ITable<T> table, string id)
		{
			Assert.IsNotNull(table);
			Assert.IsNotNull(id);
			
			Debug.Log("Using NotImplementedSaveable!");
			
			this.table = table;
			this.id = id;
		}

		public override T Value
		{
			get => value;
			set => this.value = value;
		}
	}
}