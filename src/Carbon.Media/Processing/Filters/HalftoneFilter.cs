namespace Carbon.Media.Processing
{
    public class HalftoneFilter : IFilter
    {
        public HalftoneFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public static HalftoneFilter Create(in CallSyntax syntax)
        {
            return new HalftoneFilter(float.Parse(syntax.Arguments[0].Value));
        }

        public string Canonicalize() => $"halftone({Amount})";

        public override string ToString() => Canonicalize();
    }
}