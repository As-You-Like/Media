namespace Carbon.Media.Processors
{
    public sealed class OrientTransform : IProcessor
    {
        public OrientTransform(ExifOrientation orientation)
        {
            Orientation = orientation;
        }

        public ExifOrientation Orientation { get; }

        public string Canonicalize() => $"orient({(int)Orientation})";

        public override string ToString() => Canonicalize();

        public static OrientTransform Create(in CallSyntax syntax)
        {
            return new OrientTransform(OrientationHelper.Parse(syntax.Arguments[0].Value));
        }
    }
}

// used to override the orientation...
