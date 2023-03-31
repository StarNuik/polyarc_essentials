using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	public abstract class ASaveable<T> : ISaveable<T>
	{
		public abstract T Value { get; set; }

		public void Set(T value) => Value = value;

		public static implicit operator T(ASaveable<T> from) => from.Value;
		
		public override string ToString() => Value.ToString();
	}
}