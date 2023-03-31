using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logger = PolygonArcana.Utilities.Logger;
using Zenject;
using PolygonArcana.Utilities;
using UnityEngine.Assertions;

namespace PolygonArcana.Utilities
{
	public class CoroutineService
	{
		private MonoBehaviour driver => CoroutineServiceDriver.Driver;

		public Coroutine StartCoroutine(IEnumerator routine) => driver.StartCoroutine(routine);
		public void StopCoroutine(Coroutine routine) => driver.StopCoroutine(routine);
	}
}