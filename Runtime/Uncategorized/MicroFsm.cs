using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public class MicroFsm
	{
		public System.Action CurrentState { get; private set; }
		
		public MicroFsm(System.Action defaultState)
		{
			CurrentState = defaultState;
		}

		public void TransitionTo(System.Action state)
		{
			CurrentState = state;
		}

		public void Update()
		{
			CurrentState?.Invoke();
		}
	}
}