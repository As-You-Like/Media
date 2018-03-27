using System;
using System.Runtime.Serialization;

using static System.Math;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct Rational : IEquatable<Rational>, IFormattable
    {
        public Rational(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("denominator may not be 0");

            Numerator = numerator;
            Denominator = denominator;
        }

        [DataMember(Name = "numerator", Order = 1)]
        public readonly long Numerator;

        [DataMember(Name = "denominator", Order = 2)]
        public readonly long Denominator;

        public Rational Invert() => new Rational(Denominator, Numerator);

        public Rational Reduce()
        {
            if (Numerator == 0) return this;

            long gcd = CalculateGcd(Numerator, Denominator);
            long num = Numerator / gcd;
            long den = Denominator / gcd;

            if (den < 0)
            {
                num *= -1;
                den *= -1;
            }

            return new Rational(num, den);
        }

        public static bool operator > (Rational lhs, Rational rhs) => lhs.ToDouble() > rhs.ToDouble();

        public static bool operator < (Rational lhs, Rational rhs) => lhs.ToDouble() < rhs.ToDouble();

        public double ToDouble() => Numerator / (double)Denominator;

        private static long CalculateGcd(long a, long b)
        {
            a = Abs(a);
            b = Abs(b);

            long remainder;

            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        public static implicit operator double(Rational rational) => rational.ToDouble();

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }

            return Numerator + "/" + Denominator;
        }

        private static readonly char[] forwardSlash = { '/' };

        public static Rational Parse(string text)
        {
            var parts = text.Split(forwardSlash); // '/'

            if (parts.Length == 1)
            {
                return new Rational(long.Parse(parts[0]), 1);
            }

            return new Rational(long.Parse(parts[0]), long.Parse(parts[1]));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToDouble().ToString(format);
        }

        #region IEquatable

        public bool Equals(Rational other) =>
            Numerator == other.Numerator && 
            Denominator == other.Denominator;

        public override int GetHashCode()
        {
            return (Numerator, Denominator).GetHashCode();
        }

        #endregion
    }
}