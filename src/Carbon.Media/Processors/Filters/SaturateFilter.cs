namespace Carbon.Media
{
    public class SaturateFilter : IFilter
    {
        public SaturateFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"saturate({Amount})";

        public override string ToString() => Canonicalize();

        public static SaturateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new SaturateFilter((float)Unit.Parse(segment).Value);
        }
    }
}