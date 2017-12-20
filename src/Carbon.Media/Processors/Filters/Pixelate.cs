using System;

namespace Carbon.Media.Processors
{
    public class PixelateFilter : IFilter
    {
        public PixelateFilter(int amount)
        {
            #region Preconditions

            if (amount < 0 || amount > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between 0 & 10,000");
            }

            #endregion

            Amount = amount;
        }

        public int Amount { get; }

        public string Canonicalize() => $"pixelate({Amount})";

        public override string ToString() => Canonicalize();

        public static PixelateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new PixelateFilter(int.Parse(segment));
        }
    }
}
