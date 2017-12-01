using System;

namespace Carbon.Media.Processors
{
    public class SepiaFilter : IFilter
    {
        public SepiaFilter(float amount)
        {
            #region Preconditions

            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            #endregion

            if (amount > 1)  // clamped to 1
            {
                amount = 1;
            }

            Amount = amount;            
        }

        // range: 0 (unchanged) - 1 (full effect)
        public float Amount { get; }

        public string Canonicalize() => $"sepia({Amount})";

        public override string ToString() => Canonicalize();

        public static SepiaFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);
            
            return new SepiaFilter((float)Unit.Parse(segment).Value);
        }
    }
}

// CSS: sepia(0.5)