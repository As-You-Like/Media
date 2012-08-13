namespace Carbon.Math
{
	using System;

	public struct Fraction
	{
		private long numerator;
		private long denominator;

		public Fraction(long value)
		{
			this.numerator = value;
			this.denominator = 1;
		}

		public Fraction(long numerator, long denominator)
		{
			#region Preconditions

			if (denominator == 0)
				throw new DivideByZeroException("Denominator may not be 0");

			#endregion

			this.numerator = numerator;
			this.denominator = denominator;

			this.Reduce();
		}

		public long Denominator {
			get { return denominator; }
		}

		public long Numerator {
			get { return numerator; }
		}

		public double ToDouble() {
			return ((double)this.numerator / (double)this.denominator);
		}

		/// <summary>
		/// The function reduces(simplifies) a Fraction object by dividing both its numerator 
		/// and denominator by their GCD
		/// </summary>
		private void Reduce()
		{
			if (this.numerator == 0) {
				this.denominator = 1;

				return;
			}

			long gcd = CalculateGcd(this.numerator, this.denominator);

			this.numerator /= gcd;
			this.denominator /= gcd;

			if (this.denominator < 0)
			{
				this.numerator *= -1;
				this.denominator *= -1;
			}
		}

		public override string ToString()
		{
			if (denominator == 1) {
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

			while (b != 0) {
				remainder = a % b;
				a = b;
				b = remainder;
			}

			return a;
		} 
	}
}

