using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	public abstract class ASaveable<T> : ISaveable<T>
	{
		public abstract T Value { get; set; }

		public void Set(T value) => Value = value;

		public static implicit operator T(ASaveable<T> from) => from.Value;
		
		public override string ToString() => Value.ToString();
	}
}