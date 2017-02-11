namespace Carbon.Media.Processors
{
    public class GrayscaleFilter : ColorMatrix, IFilter
    {
        public GrayscaleFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"grayscale({Amount})";

        public override string ToString() => Canonicalize();

        public static GrayscaleFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new GrayscaleFilter((float)Unit.Parse(segment).Value);
        }

        // https://www.w3.org/TR/filter-effects/#grayscaleEquivalent
        public override float[] GetMatrix()
        {
            var a = (1f - Amount);

            return new float[] {
                0.2126f + (0.7874f * a), 0.7152f - (0.7152f * a), 0.0722f - (0.0722f * a), 0f, 0f,
                0.2126f - (0.2126f * a), 0.7152f + (0.2848f * a), 0.0722f - (0.0722f * a), 0f, 0f,
                0.2126f - (0.2126f * a), 0.7152f - (0.7152f * a), 0.0722f + (0.9278f * a), 0f, 0f,
                0f, 0f, 0f, 1f, 0f
            };
        }
    }
}