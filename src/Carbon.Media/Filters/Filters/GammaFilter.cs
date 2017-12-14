using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class GammaFilter : IFilter
    {
        // public static readonly GammaFilter Default = new GammaFilter(2.2);

        public GammaFilter(float amount)
        {
            if (amount < 0 || amount > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between 0 and 5");
            }

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"gamma({Amount})";

        public override string ToString() => Canonicalize();

        public static GammaFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new GammaFilter((float)Unit.Parse(segment).Value);
        }
    }
}

// 1 - 3 (default = 2.2)

//gamma(1.1, 3.6, 0)
