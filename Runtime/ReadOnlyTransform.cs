using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	public struct ReadOnlyTransform
	{
		public ReadOnlyTransform(Transform transform)
		{
			Assert.IsNotNull(transform);

			_transform = transform;
		}

		private Transform _transform;

		public string tag => _transform.tag;
		public string name => _transform.name;

		public Vector3 eulerAngles => _transform.eulerAngles;
		public Vector3 forward => _transform.forward;
		// public Vector3 localEulerAngles => _transform.localEulerAngles;
		// public Vector3 localPosition => _transform.localPosition;
		// public Quaternion localRotation => _transform.localRotation;
		// public Vector3 localScale => _transform.localScale;
		// public Matrix4x4 localToWorldMatrix => _transform.localToWorldMatrix;
		public Vector3 lossyScale => _transform.lossyScale;
		public Vector3 position => _transform.position;
		public Vector3 right => _transform.right;
		public Quaternion rotation => _transform.rotation;
		public Vector3 up => _transform.up;
		// public Matrix4x4 worldToLocalMatrix => _transform.worldToLocalMatrix;

		// public Vector3 InverseTransformDirection(Vector3 direction) => _transform.InverseTransformDirection(direction);
		// public Vector3 InverseTransformPoint(Vector3 point) => _transform.InverseTransformPoint(point);
		// public Vector3 InverseTransformVector(Vector3 vector) => _transform.InverseTransformVector(vector);
		public Vector3 TransformDirection(Vector3 direction) => _transform.TransformDirection(direction);
		public Vector3 TransformPoint(Vector3 point) => _transform.TransformPoint(point);
		public Vector3 TransformVector(Vector3 vector) => _transform.TransformVector(vector);

		public override string ToString() => _transform.ToString();
		public override bool Equals(object obj) => _transform.Equals(obj);
		public override int GetHashCode() => _transform.GetHashCode();

		public static implicit operator bool(ReadOnlyTransform transform) => (bool)transform._transform;
		public static implicit operator ReadOnlyTransform(Transform transform) => new ReadOnlyTransform(transform);

		public static bool operator ==(ReadOnlyTransform left, ReadOnlyTransform right) => left._transform == right._transform;
		public static bool operator !=(ReadOnlyTransform left, ReadOnlyTransform right) => left._transform != right._transform;
	}
}