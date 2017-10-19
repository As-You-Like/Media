namespace Carbon.Media.Processors
{
    public class SharpenFilter : IFilter
    {
        public SharpenFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"sharpen({Amount})";

        public override string ToString() => Canonicalize();

        public static SharpenFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new SharpenFilter((float)Unit.Parse(segment).Value);
        }
    }
}