using System;

namespace Carbon.Media
{
    public struct BitRate : IEquatable<BitRate>
    {
        public static readonly BitRate Zero = new BitRate(0);

        private readonly long value;

        public BitRate(long value)
        {
            this.value = value;
        }

        public long Value => value;

        public static BitRate FromKbs(long kbs)
        {
            return new BitRate(kbs * 1000);
        }
        
        public static BitRate FromMbs(long kbs)
        {
            return new BitRate(kbs * 1000 * 1000);
        }

        // Kb/s
        // Mb/s

        #region Equality

        public bool Equals(BitRate other) => Value == other.value;

        public override int GetHashCode() => value.GetHashCode();

        #endregion 

        public override string ToString()
        {
            return value.ToString();
        }

        public static BitRate Parse(string text)
        {
            return new BitRate(long.Parse(text));
        }
    }
}