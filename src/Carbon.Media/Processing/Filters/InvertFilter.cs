using System;

namespace Carbon.Media.Processing
{
    public class InvertFilter : IFilter
    {
        public InvertFilter(float amount)
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

        public float Amount { get; }

        public string Canonicalize() => $"invert({Amount})";

        public override string ToString() => Canonicalize();

        public static InvertFilter Create(in CallSyntax syntax)
        {
            return new InvertFilter(float.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}