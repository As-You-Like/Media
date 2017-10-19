﻿namespace Carbon.Media.Processors
{
    public class GammaFilter : IFilter
    {
        public GammaFilter(float amount)
        {
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

//gamma(1.1, 3.6, 0)
 