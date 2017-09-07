using System;

namespace Carbon.Media
{
    public struct BitRate : IEquatable<BitRate>
    {
        public long value;

        public BitRate(long value)
        {
            this.value = value;
        }

        public long Value => value;

        // Kb/s
        // Mb/s

        public bool Equals(BitRate other)
        {
            return Value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}