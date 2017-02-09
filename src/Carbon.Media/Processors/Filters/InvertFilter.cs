namespace Carbon.Media
{
    public class InvertFilter : IFilter
    {
        public InvertFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"invert({Amount})";

        public override string ToString() => Canonicalize();

        public static InvertFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new InvertFilter(float.Parse(segment));
        }
    }
}