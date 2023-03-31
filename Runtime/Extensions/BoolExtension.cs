using System.Runtime.CompilerServices;

namespace PolygonArcana.Essentials
{
	public static class BoolExtension
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool OrDefault(this bool? obj, bool defaultTo)
		{
			return (obj.HasValue ? obj.Value : defaultTo);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool OrFalse(this bool? obj)
		{
			return (obj.HasValue && obj.Value);
		}
	}
}