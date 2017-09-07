using System;

namespace Carbon.Media
{
    internal class BitCountAttribute : Attribute
    {
        public BitCountAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}