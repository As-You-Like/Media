using System;

namespace Carbon.Media.Processing
{
    public class VolumeFilter : IFilter
    {
        public VolumeFilter(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be >= 0");
            }

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"volume({Amount})";

        public override string ToString() => Canonicalize();

        public static VolumeFilter Create(in CallSyntax syntax)
        {
            return new VolumeFilter(Unit.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}

// adjust(volume:50%) ???