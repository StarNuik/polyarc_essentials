using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using UnityEngine.Assertions;

namespace PolygonArcana.Common
{
	public abstract class AModelState
	{
		public bool Is<TState>()
			where TState : AModelState
		{
			return this is TState;
		}

		public bool Is<TState>(out TState state)
			where TState : AModelState
		{
			state = this as TState;
			return Is<TState>();
		}

		public bool IsHard<TState>()
			where TState : AModelState
		{
			return this.GetType() == typeof(TState);
		}

		public bool IsHard<TState>(out TState state)
			where TState : AModelState
		{
			state = this as TState;
			return IsHard<TState>();
		}
	}
}