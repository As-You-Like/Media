using System;

namespace Carbon.Media.Processors
{
    public sealed class Quality : IProcessor
    {
        public Quality(int value)
        {
            if (value < 0 && value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Must be between 0 & 100");

            Value = value;
        }

        public int Value { get; }

        #region ToString()

        public string Canonicalize()
        {
            return $"quality({Value})";
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static Quality Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            var arg = segment.Substring(argStart, segment.Length - argStart - 1);

            return new Quality(int.Parse(arg));
        }
    }
}