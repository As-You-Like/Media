using System;

namespace Carbon.Media.Processors
{
    public class Background : IFilter
    {
        public Background(string color)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Color { get; }

        public static Background Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new Background(segment);
        }

        public string Canonicalize() => $"background({Color})";

        public override string ToString() => Canonicalize();
    }
}