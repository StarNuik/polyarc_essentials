using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
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