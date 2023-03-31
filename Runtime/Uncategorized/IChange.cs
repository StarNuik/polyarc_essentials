using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public class IChange<T>
	{
		private T value;

		public event System.Action OnChanged;

		public bool IsNull
		{
			get => object.Equals(value, null);
		}

		public T Value
		{
			get => value;
			set => Set(value);
		}

		public IChange()
		{
			value = default(T);
		}

		public IChange(T first)
		{
			value = first;
		}

		public void Set(T value)
		{
			var old = this.value;
			this.value = value;

			if (!object.Equals(value, old))
				OnChanged?.Invoke();
		}

		public void InvokeChanged()
		{
			OnChanged?.Invoke();
		}

		public static implicit operator T(IChange<T> obj) => obj.value;
	}
}