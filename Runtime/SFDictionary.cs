// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using PolygonArcana.Utilities;
// using SF = UnityEngine.SerializeField;
// using Logger = PolygonArcana.Utilities.Logger;
// using System.Linq;

// namespace PolygonArcana.Utilities
// {

// 	[System.Serializable]
// 	public sealed class SFDictionary<SFPair, TKey, TValue> : IDictionary<TKey, TValue>
// 		where SFPair : Into<KeyValuePair<TKey, TValue>>, From<KeyValuePair<TKey, TValue>, SFPair>
// 	{
// 		[SerializeField]
// 		private List<Pair> list = new();

// 		private Dictionary<TKey, TValue> _dict = null;
// 		private Dictionary<TKey, TValue> dict
// 		{
// 			get
// 			{
// 				if (_dict == null)
// 				{
// 					var listCasted = list.Select(pair => (KeyValuePair<TKey, TValue>)pair);
// 					_dict = new(listCasted);
// 				}
// 				return _dict;
// 			}
// 		}

// 		private IDictionary<TKey, TValue> iDictionary => dict;
// 		private ICollection<KeyValuePair<TKey, TValue>> iCollection => dict;

// 		private void Save()
// 		{
// 			for (int i = list.Count - 1; i >= 0; i--)
// 			{
// 				var old = list[i];
// 				if (!iDictionary.Contains(old)) list.RemoveAt(i);
// 			}

// 			foreach (var pair in dict)
// 			{
// 				if (!list.Contains(pair)) list.Add(pair);
// 			}
			
// 			var s = "";
// 			foreach (var pair in list)
// 			{
// 				s += pair.Key + ": " + pair.Value;
// 			}
// 		}

// 		private void SaveWith(System.Action<Dictionary<TKey, TValue>> action)
// 		{
// 			action(dict);
// 			Save();
// 		}

// 		private TReturn SaveWith<TReturn>(System.Func<Dictionary<TKey, TValue>, TReturn> func)
// 		{
// 			var result = func(dict);
// 			Save();
// 			return result;
// 		}

// 		public SFDictionary()
// 		{
// 			_dict = new();
// 		}


// 		public TValue this[TKey key]
// 		{
// 			get => dict[key];
// 			set => SaveWith(d => d[key] = value);
// 		}

// 		public IReadOnlyDictionary<TKey, TValue> AsReadOnly() => dict;

// 		//> IDictionary<TKey, TValue>
// 		public void Add(TKey key, TValue value) => SaveWith(d => d.Add(key, value));
// 		public bool ContainsKey(TKey key) => dict.ContainsKey(key);
// 		public bool Remove(TKey key) => SaveWith(d => d.Remove(key));
// 		public bool TryGetValue(TKey key, out TValue value) => dict.TryGetValue(key, out value);

// 		public ICollection<TKey> Keys => dict.Keys;
// 		public ICollection<TValue> Values => dict.Values;

// 		//> ICollection<KeyValuePair<TKey, TValue>>
// 		public void Add(KeyValuePair<TKey, TValue> pair) => SaveWith(d => (d as ICollection<KeyValuePair<TKey, TValue>>).Add(pair));
// 		public void Clear() => SaveWith(d => d.Clear());
// 		public bool Contains(KeyValuePair<TKey, TValue> pair) => iCollection.Contains(pair);
// 		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => iCollection.CopyTo(array, arrayIndex);
// 		public bool Remove(KeyValuePair<TKey, TValue> pair) => SaveWith(d => (d as ICollection<KeyValuePair<TKey, TValue>>).Remove(pair));
// 		public int Count => iCollection.Count;
// 		public bool IsReadOnly => iCollection.IsReadOnly;

// 		//> IEnumerable<KeyValuePair<TKey, TValue>>
// 		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => iCollection.GetEnumerator();

// 		IEnumerator System.Collections.IEnumerable.GetEnumerator() => iCollection.GetEnumerator();
	
// 		[System.Serializable]
// 		private struct Pair
// 		{
// 			[SerializeField]
// 			public readonly TKey Key;
// 			[SerializeField]
// 			public readonly TValue Value;

// 			public Pair(TKey key, TValue value)
// 			{
// 				Key = key;
// 				Value = value;
// 			}

// 			public static implicit operator KeyValuePair<TKey, TValue>(Pair from) => new(from.Key, from.Value);
// 			public static implicit operator Pair(KeyValuePair<TKey, TValue> from) => new(from.Key, from.Value);
// 		}
// 	}
// }