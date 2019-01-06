using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct BitSize : IEquatable<BitSize>
    {
        public static readonly BitSize Zero = new BitSize(0);

        public BitSize(long value)
        {
            Value = value;
        }

        [DataMember(Name = "value", Order = 1)]
        public long Value { get; }

        [IgnoreDataMember]
        public double TotalKilobits => Value / 1000d;

        [IgnoreDataMember]
        public double Megabits => Value / (1000d * 1000d);

        public static BitSize FromKilobits(double value)
        {
            return new BitSize((long)(value * 1000));
        }

        public static BitSize FromMegabits(double value)
        {
            return new BitSize((long)(value * 1000 * 1000));
        }

        #region Operators

        public static BitSize operator +(BitSize lhs, BitSize rhs)
        {
            return new BitSize(lhs.Value + rhs.Value);
        }

        public static BitSize operator -(BitSize lhs, BitSize rhs)
        {
            return new BitSize(lhs.Value - rhs.Value);
        }

        public static BitSize operator *(BitSize lhs, double value)
        {
            return new BitSize((long)(lhs.Value * value));
        }

        #endregion

        #region Equality

        public bool Equals(BitSize other) => Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        #endregion 

        public override string ToString() => Value.ToString();

        public static BitSize Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

            switch (text[text.Length - 1]) // last char
            {
                case 'k': return FromKilobits(double.Parse(text.Substring(0, text.Length - 1)));
                case 'm': return FromMegabits(double.Parse(text.Substring(0, text.Length - 1)));
            }
        
            return new BitSize(long.Parse(text));
        }
    }
}