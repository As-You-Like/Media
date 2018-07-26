namespace Carbon.Media.Processors
{
    public class HalftoneFilter : IFilter
    {
        public HalftoneFilter(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }

        public static HalftoneFilter Create(in CallSyntax syntax)
        {
            return new HalftoneFilter(double.Parse(syntax.Arguments[0].Value));
        }

        public string Canonicalize() => $"halftone({Amount})";

        public override string ToString() => Canonicalize();
    }
}