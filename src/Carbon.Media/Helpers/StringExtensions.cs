using System;

namespace Carbon.Media
{
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
        
        public static bool IsLower(this string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLower(input[i])) return false;
            }

            return true;
        }
    }
}
