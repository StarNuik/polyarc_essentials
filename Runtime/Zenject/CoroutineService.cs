using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolygonArcana.Essentials
{
	public class CoroutineService
	{
		private MonoBehaviour driver => CoroutineServiceDriver.Driver;

		public Coroutine StartCoroutine(IEnumerator routine) => driver.StartCoroutine(routine);
		public void StopCoroutine(Coroutine routine) => driver.StopCoroutine(routine);
	}
}