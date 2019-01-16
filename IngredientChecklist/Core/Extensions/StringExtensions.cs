using System;

namespace Core.Extensions
{
	public static class StringExtensions
    {
		public static int? ToInteger(this string value)
		{
			int result;
			if (Int32.TryParse(value, out result))
				return result;

			return null;
		}
	}
}
