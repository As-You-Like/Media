using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct BitRate : IEquatable<BitRate>
    {
        public static readonly BitRate Zero = new BitRate(0);

        public BitRate(long value)
        {
            Value = value;
        }

        [DataMember(Name = "value", Order = 1)]
        public long Value { get; }

        [IgnoreDataMember]
        public double Kbps => Value / 1000d;

        [IgnoreDataMember]
        public double Mbps => Value / (1000d * 1000d);

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

        public bool Equals(BitRate other) => Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        #endregion 

        public override string ToString() => Value.ToString();

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