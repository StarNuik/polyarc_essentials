using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace PolygonArcana.Essentials
{
	public class Request : ARequestBase
	{
		public Request() : base() {}

		public Request(System.Action onEnabled, System.Action onDisabled) : base(onEnabled, onDisabled) {}

		public Handle Enable() => GetHandle();
	}

	// public class Request<T> : ARequestBase
	// {
	// 	public event System.Action OnChanged;


	// }

	public abstract class ARequestBase
	{
		private int _handles = 0;

		public event System.Action OnEnabled;
		public event System.Action OnDisabled;

		private bool isOn => handleCount > 0;

		public bool IsRequested => isOn;

		protected int handleCount
		{
			get => _handles;
			set
			{
				Assert.IsTrue(value >= 0);
				
				var old = _handles;
				_handles = value;

				if (old == 0 && value > 0) OnEnabled?.Invoke();
				if (old > 0 && value == 0) OnDisabled?.Invoke();
			}
		}

		protected virtual void OnHandleCreated(Handle handle) => handleCount++;

		protected virtual void OnHandleDestroyed(Handle handle) => handleCount--;

		protected Handle GetHandle() => new(this);

		internal ARequestBase() {}

		internal ARequestBase(System.Action onEnabled, System.Action onDisabled)
		{
			OnEnabled += onEnabled;
			OnDisabled += onDisabled;
		}

		public class Handle : IDisposable
		{
			private ARequestBase owner;

			internal Handle(ARequestBase owner)
			{
				this.owner = owner;
				owner.OnHandleCreated(this);
			}

			~Handle()
			{
				Dispose();
			}

			public void Dispose()
			{
				if (owner == null) return;

				owner.OnHandleDestroyed(this);				
				owner = null;
			}
		}
	}
}