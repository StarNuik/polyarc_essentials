using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	public class Indifferential<TTarget, TField>
	{
		private System.Func<TTarget, TField> getter;
		private System.Func<TTarget, TField, TTarget> setter;
		private System.Func<TField, TField, TField> addOperator;

		protected void Setup(
			System.Func<TTarget, TField> getter,
			System.Func<TTarget, TField, TTarget> setter,
			System.Func<TField, TField, TField> addOperator
		)
		{
			this.getter = getter;
			this.setter = setter;
			this.addOperator = addOperator;
		}

		protected Indifferential() {}

		public Indifferential(
			TField currentValue,
			System.Func<TTarget, TField, TTarget> setter,
			System.Func<TField, TField, TField> addOperator
		)
		{
			Setup(target => currentValue, setter, addOperator);
		}

		public Indifferential(
			System.Func<TTarget, TField> getter,
			System.Func<TTarget, TField, TTarget> setter,
			System.Func<TField, TField, TField> addOperator
		)
		{
			Setup(getter, setter, addOperator);
		}

		public TField GetField(TTarget target) => getter(target);
		public TTarget Assign(TTarget target, TField value) => setter(target, value);
		public TTarget Add(TTarget target, TField value) => setter(target, addOperator(getter(target), value));
	}

	public class Indifferential<TTarget> : Indifferential<TTarget, int>
	{
		private static System.Func<int, int, int> addOperator = (lhs, rhs) => lhs + rhs;

		public Indifferential(
			int currentValue,
			System.Func<TTarget, int, TTarget> setter
		) : this(target => currentValue, setter)
		{
			Setup(target => currentValue, setter, addOperator);
		}

		public Indifferential(
			System.Func<TTarget, int> getter,
			System.Func<TTarget, int, TTarget> setter
		)
		{
			Setup(getter, setter, addOperator);
		}

		public Indifferential(string nameOfField)
		{
			var field = typeof(TTarget).GetField(nameOfField);

			Setup(
				target => (int)field.GetValue(target),
				(target, value) => { object box = target; field.SetValue(box, value); return (TTarget)box; },
				addOperator
			);
		}
	}
}