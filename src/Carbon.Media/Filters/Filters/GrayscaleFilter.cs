using System;

namespace Carbon.Media.Processors
{
    public sealed class GrayscaleFilter : IFilter
    {
        public GrayscaleFilter(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            if (amount > 0)  // clamped to 1
            {
                amount = 1;
            }

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"grayscale({Amount})";

        public override string ToString() => Canonicalize();

        public static GrayscaleFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new GrayscaleFilter((float)Unit.Parse(segment).Value);
        }
    }
}

// grayscale(1)
