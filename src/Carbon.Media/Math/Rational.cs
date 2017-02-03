﻿using System;

using static System.Math;

namespace Carbon.Media
{
    public struct Rational : IFormattable
    {
        private long numerator;
        private long denominator;

        public Rational(long value)
        {
            this.numerator = value;
            this.denominator = 1;
        }

        public Rational(long numerator, long denominator)
        {
            #region Preconditions

            if (denominator == 0)
                throw new DivideByZeroException("Denominator may not be 0");

            #endregion

            this.numerator = numerator;
            this.denominator = denominator;

            this.Reduce();
        }

        public long Denominator => denominator;

        public long Numerator => numerator;

        public Rational Invert() => new Rational(denominator, numerator);

        private void Reduce()
        {
            if (numerator == 0)
            {
                denominator = 1;

                return;
            }

            var gcd = CalculateGcd(numerator, denominator);

            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
        }

        public double ToDouble()
            => numerator / (double)denominator;

        public override string ToString()
        {
            if (denominator == 1)
            {
                return numerator.ToString();
            }

            return numerator + "∶" + denominator;
        }

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


        public static implicit operator double(Rational rational)
            => rational.ToDouble();

        public string ToString(string format, IFormatProvider formatProvider)
            => ToDouble().ToString(format);
    }
}