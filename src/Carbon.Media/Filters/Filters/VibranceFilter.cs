namespace Carbon.Media.Processors
{
    public class VibranceFilter : IFilter
    {
        public VibranceFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public static VibranceFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new VibranceFilter(float.Parse(segment));
        }

        public string Canonicalize() => $"vibrance({Amount})";

        public override string ToString() => Canonicalize();
    }
}