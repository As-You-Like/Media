namespace Carbon.Media.Processors
{
    public class PixelateFilter : IFilter
    {
        public PixelateFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"pixelate({Amount})";

        public override string ToString() => Canonicalize();

        public static PixelateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new PixelateFilter(float.Parse(segment));
        }
    }
}
