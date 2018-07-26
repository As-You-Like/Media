using System;

namespace Carbon.Media.Processors
{
    public class GammaFilter : IFilter
    {
        // public static readonly GammaFilter Default = new GammaFilter(2.2);

        public GammaFilter(double amount)
        {
            if (amount < 0 || amount > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between 0 and 5");
            }

            Amount = amount;
        }

        public double Amount { get; }

        public string Canonicalize() => $"gamma({Amount})";

        public override string ToString() => Canonicalize();

        public static GammaFilter Create(in CallSyntax syntax)
        {
            return new GammaFilter(Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}

// 1 - 3 (default = 2.2)

// gamma(1.1, 3.6, 0)
