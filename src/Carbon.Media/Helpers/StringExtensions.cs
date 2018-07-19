using System;

namespace Carbon.Media
{
    internal static class StringExtensions
    {
        public static TEnum ToEnum<TEnum>(this string self, bool ignoreCase)
            where TEnum : struct, Enum
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            
            Enum.TryParse(self, ignoreCase, out TEnum result);

            return result;
        }
    }
}