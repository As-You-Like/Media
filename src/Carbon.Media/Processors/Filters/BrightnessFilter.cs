using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class BrightnessFilter : IFilter
    {
        public BrightnessFilter(float amount)
        {
            if (amount < -10 || amount > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -10 and 10");
            }

            Amount = amount;
        }

        public float Amount { get; }

        public static BrightnessFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new BrightnessFilter(float.Parse(segment));
        }

        public string Canonicalize() => $"brightness({Amount})";

        public override string ToString() => Canonicalize();
    }
}