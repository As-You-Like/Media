using System;

using static System.Math;

namespace Carbon.Media
{
    public struct Rational : IEquatable<Rational>, IFormattable
    {
        private readonly long numerator;
        private readonly long denominator;

        public Rational(long numerator, long denominator)
        {
            #region Preconditions

            if (denominator == 0) throw new DivideByZeroException("denominator may not be 0");

            #endregion

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator => numerator;

        public long Denominator => denominator;

        public Rational Invert() => new Rational(denominator, numerator);

        public Rational Reduce()
        {
            if (numerator == 0) return this;

            var gcd = CalculateGcd(numerator, denominator);

            var num = numerator / gcd;
            var den = denominator / gcd;

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
            if (denominator == 1)
            {
                return numerator.ToString();
            }

            return numerator + "/" + denominator;
        }
        
        public static Rational Parse(string text)
        {
            var parts = text.Split('/');

            if (parts.Length == 1)
            {
                return new Rational(long.Parse(parts[0]), 1);
            }

            return new Rational(long.Parse(parts[0]), long.Parse(parts[1]));
        }

        public string ToString(string format, IFormatProvider formatProvider) => 
            ToDouble().ToString(format);


        #region IEquatable

        public bool Equals(Rational other)
        {
            return numerator   == other.Numerator
                && denominator == other.Denominator;
        }

        #endregion

    }
}