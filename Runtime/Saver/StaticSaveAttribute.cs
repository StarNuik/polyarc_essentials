using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using UnityEngine.Assertions;
using System;

namespace PolygonArcana.Utilities
{
	public class StaticSaveAttribute : Attribute
	{
		public StaticSaveAttribute()
		{}
	}
}