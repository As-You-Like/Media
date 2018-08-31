using System;

namespace Carbon.Media.Processing
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

        public static ColorSpaceFilter Create(in CallSyntax syntax)
        {
            if (Enum.TryParse<ColorSpace>(syntax.Arguments[0].Value, ignoreCase: true, out var colorSpace))
            {
                return new ColorSpaceFilter(colorSpace);
            }

            throw new Exception("Invalid ColorSpace:" + syntax.Arguments[0].Value);
        }
    }
}

// defaults to srgb