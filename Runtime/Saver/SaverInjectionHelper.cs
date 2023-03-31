using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Reflection;
using System.Linq;
using System;

namespace PolygonArcana.Essentials
{
	public partial class Saver
	{
		private static class SaverInjectionHelper
		{
			public static void Inject(ISaver saver, object target)
			{
				var baseType = target.GetType();

				var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
				var allFields = baseType.GetFields(flags);
				
				var fields = allFields.Where(
					f => f.FieldType.IsGenericType && f.FieldType.GetGenericTypeDefinition() == typeof(ISaveable<>)
				);

				foreach (var field in fields)
				{
					var fType = field.FieldType;
					var gType = fType.GenericTypeArguments[0];
					var link = GetLink(saver, gType, ToId(field));
					
					field.SetValue(target, link);
				}
			}

			private static object GetLink(ISaver saver, Type type, string id)
			{
				var method = typeof(ISaver).GetMethod(nameof(ISaver.GetLink));
				method = method.MakeGenericMethod(type);
				
				var args = new object[] { id };
				
				var result = method.Invoke(saver, args);
				return result;
			}

			private static string ToId(FieldInfo field)
			{
				var parentType = field.DeclaringType;
				var staticAttribute = field.GetCustomAttribute<StaticSaveAttribute>();
				var isStatic = staticAttribute != null;
				

				if (isStatic)
				{
					var parentName = parentType.FullName;
					return parentName;
				}

				string id = null;
				if (typeof(IIdProvider).IsAssignableFrom(parentType))
				{
					var provider = parentType as IIdProvider;
					id = provider.Id;
				}
				if (typeof(IHave<IIdProvider>).IsAssignableFrom(parentType))
				{
					var owner = parentType as IHave<IIdProvider>;
					owner.Get(out var provider);
					id = provider.Id;
				}

				Assert.IsNotNull(id);
				return id;
			}
		}
	}
}