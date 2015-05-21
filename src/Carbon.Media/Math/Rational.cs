namespace Carbon.Math
{
	using System;

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
			if (this.numerator == 0) 
			{
				this.denominator = 1;

				return;
			}

			var gcd = CalculateGcd(this.numerator, this.denominator);

			this.numerator /= gcd;
			this.denominator /= gcd;

			if (this.denominator < 0)
			{
				this.numerator *= -1;
				this.denominator *= -1;
			}
		}

		public double ToDouble()
		{
			return ((double)this.numerator / (double)this.denominator);
		}

		public override string ToString()
		{
			if (denominator == 1) 
			{
				return numerator.ToString();
			}

			return numerator + "∶" + denominator;
		}

		/// <summary>
		/// The function returns GCD of two numbers (used for reducing a Fraction)
		/// </summary>
		private static long CalculateGcd(long a, long b)
		{
			// Normalize the values
			a = Math.Abs(a);
			b = Math.Abs(b);

			long remainder;

			while (b != 0) 
			{
				remainder = a % b;
				a = b;
				b = remainder;
			}

			return a;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return ToDouble().ToString(format);
		}
	}
}

