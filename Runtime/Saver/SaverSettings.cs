using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	[CreateAssetMenu(menuName = ("Settings/" + nameof(SaverSettings)), fileName = nameof(SaverSettings))]
	public class SaverSettings : ScriptableObject
	{
		[field: SerializeField]
		public bool LazyInitialization { get; private set; } = true;

		[field: SerializeField]
		public bool Autosave { get; private set; }

		[field: SerializeField]
		public AutosaveModeEnum AutosaveMode { get; private set; }

		[field: SerializeField, Min(1)]
		public int AutosaveCountTrigger { get; private set; } = 100;

		public enum AutosaveModeEnum
		{
			CountFrames,
			CountSeconds,
			CountWrites,
		}
	}
}