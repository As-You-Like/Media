using System;

namespace Carbon.Media.Processors
{
    public class VolumeFilter : IFilter
    {
        public VolumeFilter(float amount)
        {
            #region Preconditions

            if (amount < 0)
                throw new ArgumentException("Must be >= 0", nameof(amount));

            #endregion

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"volume({Amount})";

        public override string ToString() => Canonicalize();

        public static VolumeFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new VolumeFilter((float)Unit.Parse(segment).Value);
        }
    }
}