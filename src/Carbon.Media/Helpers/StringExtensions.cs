namespace Carbon.Media
{
	using System;

	internal static class StringExtensions
	{
		public static TEnum ToEnum<TEnum>(this string self, bool ignoreCase)
			where TEnum : struct
		{
			#region Preconditions

			if (self == null)
				throw new ArgumentNullException("self");

			#endregion

			TEnum result;

			Enum.TryParse(self, ignoreCase, out result);

			return result;
		}
	}
}
