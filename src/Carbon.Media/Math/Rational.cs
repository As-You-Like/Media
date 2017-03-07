using System;
using System.Runtime.Serialization;

using static System.Math;

namespace Carbon.Media
{
    [DataContract]
    public struct Rational : IFormattable
    {
        public Rational(long value)
        {
            Numerator = value;
            Denominator = 1;
        }

        public Rational(long numerator, long denominator)
        {
            #region Preconditions

            if (denominator == 0)
                throw new DivideByZeroException("Denominator may not be 0");

            #endregion

            Numerator = numerator;
            Denominator = denominator;

            Reduce();
        }

        [DataMember(Order = 1)]
        public long Denominator { get; set; }

        [DataMember(Order = 2)]
        public long Numerator { get; set; }

        public Rational Invert() => new Rational(Denominator, Numerator);

        private void Reduce()
        {
            if (Numerator == 0)
            {
                Denominator = 1;

                return;
            }

            var gcd = CalculateGcd(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }


        public static bool operator >(Rational left, Rational right) =>
            left.ToDouble() > right.ToDouble();

        public static bool operator <(Rational left, Rational right) =>
            left.ToDouble() < right.ToDouble();

        public double ToDouble() =>  Numerator / (double)Denominator;

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

        public string ToString(string format, IFormatProvider formatProvider) => 
            ToDouble().ToString(format);


    }
}