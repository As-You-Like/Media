using System;

namespace Carbon.Media.Processors
{
    public class ColorSpaceFilter : ITransform
    {
        public ColorSpaceFilter(ColorSpace type)
        {
            Type = type;
        }

        public ColorSpace Type { get; }

        public string Canonicalize() => $"colorspace({Type.ToString().ToLower()})";

        public override string ToString() => Canonicalize();

        public static ColorSpaceFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            var space = (ColorSpace)Enum.Parse(typeof(ColorSpace), segment, true);

            return new ColorSpaceFilter(space);
        }
    }
}

// defaults to srgb