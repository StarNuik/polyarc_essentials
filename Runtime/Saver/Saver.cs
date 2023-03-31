using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PolygonArcana.Essentials
{
	public partial class Saver : ISaver
	{
		private readonly string dirPath = Application.persistentDataPath;

		private Dictionary<System.Type, ITable> database = new();

		public Saver(SaverSettings settings)
		{}

		#region Public API
		public T Get<T>(string id)
		{
			var table = TableOf<T>();
			return table[id];
		}
		
		public void Set<T>(string id, T value)
		{
			var table = TableOf<T>();
			table[id] = value;
		}

		public ASaveable<T> GetLink<T>(string id)
		{
			var table = TableOf<T>();
			return table.GetLink(id);
		}

		public void Flush()
		{
			foreach ((_, var table) in database)
			{
				table.Flush();
			}
		}

		public void Inject(object target)
		{
			Assert.IsNotNull(target);

			SaverInjectionHelper.Inject(this, target);
		}
		#endregion

		private ITable<T> TableOf<T>()
		{
			var type = typeof(T);

			if (!database.ContainsKey(type))
			{
				var table = new NotImplementedTable<T>(dirPath);
				database.Add(type, table);
				return table;
			}

			var result = database[type] as ITable<T>;
			
			Assert.IsNotNull(result);
			return result;
		}
	}
}