using System;

namespace Carbon.Media.Processors
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

        public static InvertFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new InvertFilter(float.Parse(segment));
        }
    }
}