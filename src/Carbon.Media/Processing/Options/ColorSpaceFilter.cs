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
            return new ColorSpaceFilter(ColorSpaceHelper.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}

// defaults to srgb