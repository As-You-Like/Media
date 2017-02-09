namespace Carbon.Media
{
    public class SepiaFilter : ColorMatrix, IProcessor
    {
        public SepiaFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"sepia({Amount})";

        public override string ToString() => Canonicalize();

        public static SepiaFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);
            
            return new SepiaFilter((float)Unit.Parse(segment).Value);
        }

        public override float[] GetMatrix()
        {
            var a = (1f - Amount);

            return new float[] {
                0.393f + (0.607f * a), 0.769f - (0.769f * a), 0.189f - (0.189f * a), 0f, 0f,
                0.349f - (0.349f * a), 0.686f + (0.314f * a), 0.168f - (0.168f * a), 0f, 0f,
                0.272f - (0.272f * a), 0.534f - (0.534f * a), 0.131f + (0.869f * a), 0f, 0f,
                0f, 0f, 0f, 1f, 0f
            };
        }
    }
}
