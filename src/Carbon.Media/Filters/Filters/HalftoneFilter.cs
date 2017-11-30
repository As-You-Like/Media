namespace Carbon.Media.Processors
{
    public class HalftoneFilter : IFilter
    {
        public HalftoneFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public static HalftoneFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new HalftoneFilter(float.Parse(segment));
        }

        public string Canonicalize() => $"halftone({Amount})";
        
        public override string ToString() => Canonicalize();
    }
}