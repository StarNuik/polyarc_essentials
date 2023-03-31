using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;
using Logger = PolygonArcana.Utilities.Logger;
using Zenject;
using PolygonArcana.Utilities;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	public class CoroutineServiceDriver : MonoBehaviour
	{
		private static MonoBehaviour driver;

		public static MonoBehaviour Driver => GetLazy();

		private static MonoBehaviour GetLazy()
		{
			if (driver != null) return driver;

			var go = new GameObject(nameof(CoroutineServiceDriver));
			var self = go.AddComponent<CoroutineServiceDriver>();
			driver = self;
			return driver;
		}

		private void OnDestroy()
		{
			Assert.IsTrue(driver == this);

			driver = null;
		}
	}
}