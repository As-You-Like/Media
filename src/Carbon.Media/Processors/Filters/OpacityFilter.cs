namespace Carbon.Media.Processors
{
    public class OpacityFilter : IFilter
    {
        public OpacityFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"opacity({Amount})";

        public override string ToString() => Canonicalize();

        public static OpacityFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new OpacityFilter((float)Unit.Parse(segment).Value);
        }
    }
}