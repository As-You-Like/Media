namespace Carbon.Media.Processors
{
    public class HighlightFilter : IFilter
    {
        public HighlightFilter(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }

        public static HighlightFilter Create(in CallSyntax syntax)
        {
            return new HighlightFilter(double.Parse(syntax.Arguments[0].Value));
        }

        public string Canonicalize() => $"highlight({Amount})";

        public override string ToString() => Canonicalize();
    }
}