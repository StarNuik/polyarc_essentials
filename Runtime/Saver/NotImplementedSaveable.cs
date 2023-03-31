using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
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