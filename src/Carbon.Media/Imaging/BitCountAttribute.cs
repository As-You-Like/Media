using System;

namespace Carbon.Media
{
    internal class BitsPerPixelAttribute : Attribute
    {
        public BitsPerPixelAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}