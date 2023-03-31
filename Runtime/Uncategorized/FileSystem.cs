using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PolygonArcana.Essentials
{
	public static class FileSystem
	{
		private static BinaryFormatter formatter = new BinaryFormatter();

		public static void WriteObject(object data, string path)
		{
			Stream file = File.Open(path, FileMode.OpenOrCreate);
			formatter.Serialize(file, data);
			file.Close();
		}

		public static T ReadObject<T>(string path)
		{
			T result;

			Stream file = File.Open(path, FileMode.OpenOrCreate);
			if (!CanSerialize<T>(file))
			{
				result = default(T);
			}
			else
			{
				result = (T)formatter.Deserialize(file);
			}
			file.Close();

			return result;
		}

		public static object ReadObject(string path)
		{
			object result;

			Stream file = File.Open(path, FileMode.OpenOrCreate);
			if (!CanSerializeBasic(file))
			{
				result = null;
			}
			else
			{
				result = formatter.Deserialize(file);
			}
			file.Close();

			return result;
		}

		private static bool CanSerialize<T>(Stream file)
		{
			int errors = 0;

			if (!CanSerializeBasic(file)) errors++;

			return errors == 0;
		}

		private static bool CanSerializeBasic(Stream file)
		{
			int errors = 0;

			if (file.Length == 0) errors++;

			return errors == 0;
		}
	}
}