namespace Carbon.Media
{
    public class BlurEffect : IFilter
    {
        public BlurEffect(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"blur({Amount})";

        public override string ToString() => Canonicalize();

        public static BlurEffect Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new BlurEffect(float.Parse(segment));
        }
    }
}