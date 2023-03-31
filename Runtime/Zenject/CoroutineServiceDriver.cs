using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	internal class CoroutineServiceDriver : MonoBehaviour
	{
		private static MonoBehaviour driver;

		public static MonoBehaviour Driver => GetLazy();

		private static MonoBehaviour GetLazy()
		{
			if (driver != null) return driver;

			var go = new GameObject(nameof(CoroutineServiceDriver));
			Object.DontDestroyOnLoad(go);

			var self = go.AddComponent<CoroutineServiceDriver>();
			driver = self;
			
			return driver;
		}

		private void OnDestroy()
		{
			driver = null;
		}
	}
}