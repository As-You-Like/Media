using System;

namespace Carbon.Media.Processors
{
    public class Colorspace : ITransform
    {
        public Colorspace(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public string Canonicalize() => $"colorspace({Name})";

        public override string ToString() => Canonicalize();

        public static Colorspace Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new Colorspace(segment);
        }
    }
}

// defaults to srgb