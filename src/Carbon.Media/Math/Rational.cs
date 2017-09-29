using System;
using System.Runtime.Serialization;

using static System.Math;

namespace Carbon.Media
{
    [DataContract]
    public struct Rational : IEquatable<Rational>, IFormattable
    {
        public Rational(long value)
        {
            Numerator   = value;
            Denominator = 1;
        }

        public Rational(long numerator, long denominator)
        {
            #region Preconditions

            if (denominator == 0) throw new DivideByZeroException("denominator may not be 0");

            #endregion

            Numerator = numerator;
            Denominator = denominator;
        }

        [DataMember(Order = 1)]
        public long Denominator { get; }

        [DataMember(Order = 2)]
        public long Numerator { get; }

        public Rational Invert() => new Rational(Denominator, Numerator);

        public Rational Reduce()
        {
            if (Numerator == 0) return this;

            var gcd = CalculateGcd(Numerator, Denominator);

            var num = Numerator / gcd;
            var den = Denominator / gcd;

            if (den < 0)
            {
                num *= -1;
                den *= -1;
            }

            return new Rational(num, den);
        }

        public static bool operator >(Rational left, Rational right) =>
            left.ToDouble() > right.ToDouble();

        public static bool operator <(Rational left, Rational right) =>
            left.ToDouble() < right.ToDouble();

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

        public static implicit operator double(Rational rational) => 
            rational.ToDouble();

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }

            return Numerator + "/" + Denominator;
        }
        
        public static Rational Parse(string text)
        {
            var parts = text.Split('/');

            if (parts.Length == 1)
            {
                return new Rational(long.Parse(parts[0]));
            }

            return new Rational(long.Parse(parts[0]), long.Parse(parts[1]));
        }

        public string ToString(string format, IFormatProvider formatProvider) => 
            ToDouble().ToString(format);


        #region IEquatable

        public bool Equals(Rational other)
        {
            return Numerator   == other.Numerator
                && Denominator == other.Denominator;
        }

        #endregion

    }
}