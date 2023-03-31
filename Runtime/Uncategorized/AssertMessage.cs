using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public class AssertMessage
	{
		private string value;

		public AssertMessage(
			string message = null,
			Object _target = null,
			[CallerMemberName]
			string _member = null,
			[CallerFilePath]
			string _file = null,
			[CallerLineNumber]
			int _line = -1
		)
		{
			value = "AssertMessage error";

			if (string.IsNullOrEmpty(_member) || string.IsNullOrEmpty(_file) || _line < 0) return;

			var pathSplit = _file.Split("Assets", 2);
			var path = "Assets" + pathSplit[1];

			var caller = "";
			if (_target != null)
			{
				caller = _target.GetType().FullName + "." + _member + "()";
			}
			else
			{
				caller = _member + "()";
			}

			value = "\n";
			value += "Caller: " + caller + "\n";
			value += "Source: " + path + ", line: " + _line;

			if (!string.IsNullOrEmpty(message))
			{
				value += "\nMessage: " + message;
			}
		}

		public override string ToString() => value;
		public static implicit operator string(AssertMessage m) => m.ToString();
	}

	public static class ObjectExtension
	{
		public static AssertMessage AssertMessage(
			this Object _target,
			string message = null,
			[CallerMemberName]
			string _member = null,
			[CallerFilePath]
			string _file = null,
			[CallerLineNumber]
			int _line = -1
		) => new AssertMessage(message, _target, _member, _file, _line);
	}
}