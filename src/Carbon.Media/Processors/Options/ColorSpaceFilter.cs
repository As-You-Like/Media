using System;

namespace Carbon.Media.Processors
{
    public class ColorSpaceFilter : IProcessor
    {
        public ColorSpaceFilter(ColorSpace type)
        {
            Type = type;
        }

        public ColorSpace Type { get; }

        public string Canonicalize() => $"colorspace({Type.Canonicalize()})";

        public override string ToString() => Canonicalize();

        public static ColorSpaceFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            if (Enum.TryParse<ColorSpace>(segment, ignoreCase: true, out var colorSpace))
            {
                return new ColorSpaceFilter(colorSpace);
            }

            throw new Exception("Invalid ColorSpace:" + segment);
        }
    }
}

// defaults to srgb