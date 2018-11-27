using System;

namespace Carbon.Media
{
    internal static class ExceptionHelper
    {
        public static ArgumentOutOfRangeException OutOfRange(string name, double min, double max, double actual)
        {
            return new ArgumentOutOfRangeException(name, actual, $"Must be between {min} and {max}.");
        }

        public static ArgumentOutOfRangeException MustBeGreaterThanOrEqualToZero(string name, double actual)
        {
            return new ArgumentOutOfRangeException(name, actual, "Must be >= 0");
        }
    }
}