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

        public static OrientTransform Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new OrientTransform(ExifOrientationHelper.Parse(segment));
        }
    }
}