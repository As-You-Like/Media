namespace Carbon.Media.Processors
{
    public class HighlightFilter : IFilter
    {
        public HighlightFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public static HighlightFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new HighlightFilter(float.Parse(segment));
        }

        public string Canonicalize() => $"highlight({Amount})";

        public override string ToString() => Canonicalize();
    }
}