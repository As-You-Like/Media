namespace Carbon.Media
{
    public class ContrastFilter : IFilter
    {
        public ContrastFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"contrast({Amount})";

        public override string ToString() => Canonicalize();

        public static ContrastFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new ContrastFilter((float)Unit.Parse(segment).Value);
        }
    }
}
