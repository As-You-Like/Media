namespace Carbon.Media.Processors
{
    // used to override the orientation...

    public sealed class OrientTransform : IProcessor
    {
        public OrientTransform(ExifOrientation orientation)
        {
            Orientation = orientation;
        }

        public ExifOrientation Orientation { get; }

        public string Canonicalize() => $"orient({(int)Orientation})";

        public override string ToString() => Canonicalize();

        public static OrientTransform Create(CallSyntax syntax)
        {
            return new OrientTransform(OrientationHelper.Parse(syntax.Arguments[0].Value));
        }
    }
}