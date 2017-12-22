using System;

namespace Carbon.Media.Processors
{
    public sealed class GrayscaleFilter : IFilter
    {
        public GrayscaleFilter(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be >= 0");
            }

            if (amount > 1)  // clamped to 1
            {
                amount = 1;
            }

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"grayscale({Amount})";

        public override string ToString() => Canonicalize();

        public static GrayscaleFilter Create(CallSyntax syntax)
        {
            return new GrayscaleFilter((float)Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}

// grayscale(1)
