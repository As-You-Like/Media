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

        public static ColorSpaceFilter Parse(string text)
        {
            var syntax = CallSyntax.Parse(text);

            if (Enum.TryParse<ColorSpace>(syntax.Arguments[0].Value, ignoreCase: true, out var colorSpace))
            {
                return new ColorSpaceFilter(colorSpace);
            }

            throw new Exception("Invalid ColorSpace:" + syntax.Arguments[0].Value);
        }
    }
}

// defaults to srgb