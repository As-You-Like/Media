using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public struct BitRate : IEquatable<BitRate>
    {
        public static readonly BitRate Zero = new BitRate(0);

        private readonly long value;

        public BitRate(long value)
        {
            this.value = value;
        }

        [DataMember(Name = "value", Order = 1)]
        public long Value => value;

        public double Kbps => value / 1000d;

        public double Mbps => value / (1000d * 1000d);

        // Kb/s
        public static BitRate FromKbps(double kbs)
        {
            return new BitRate((long)(kbs * 1000));
        }

        // Mb/s
        public static BitRate FromMbps(double kbs)
        {
            return new BitRate((long)(kbs * 1000 * 1000));
        }

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
            if (text.EndsWith("Kb/s"))
            {
                return FromKbps(double.Parse(text.Substring(0, text.Length - 4)));
            }
            else if (text.EndsWith("Mb/s"))
            {
                return FromMbps(double.Parse(text.Substring(0, text.Length - 4)));
            }

            return new BitRate(long.Parse(text));
        }
    }
}