using System;

namespace Carbon.Media.Processors
{
    public class InvertFilter : IFilter
    {
        public InvertFilter(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            if (amount > 1)  // clamped to 1
            {
                amount = 1;
            }

            Amount = amount;
        }

        public double Amount { get; }

        public string Canonicalize() => $"invert({Amount})";

        public override string ToString() => Canonicalize();

        public static InvertFilter Create(in CallSyntax syntax)
        {
            return new InvertFilter(double.Parse(syntax.Arguments[0].Value));
        }
    }
}