using System;

namespace Carbon.Media.Processors
{
    public sealed class Quality : ITransform
    {
        public Quality(int value)
        {
            #region Preconditions

            if (value < 0 && value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Must be between 0 & 100");

            #endregion

            Value = value;
        }

        public int Value { get; }

        // quality(100)
        // lossless

        public static Quality Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            var arg = segment.Substring(argStart, segment.Length - argStart - 1);
            
            return new Quality(int.Parse(arg));
        }

        #region ToString()

        public string Canonicalize()
        {
            return $"quality({Value})";
        }

        public override string ToString() => Canonicalize();

        #endregion
    }
}