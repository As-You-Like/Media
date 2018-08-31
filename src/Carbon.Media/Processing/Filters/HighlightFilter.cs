namespace Carbon.Media.Processing
{
    public class HighlightFilter : IFilter
    {
        public HighlightFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public static HighlightFilter Create(in CallSyntax syntax)
        {
            return new HighlightFilter(float.Parse(syntax.Arguments[0].Value));
        }

        public string Canonicalize() => $"highlight({Amount})";

        public override string ToString() => Canonicalize();
    }
}