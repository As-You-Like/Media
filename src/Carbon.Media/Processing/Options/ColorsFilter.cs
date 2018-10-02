namespace Carbon.Media.Processing
{
    public sealed class ColorsFilter : IProcessor
    {
        public ColorsFilter(int count)
        {
            Count = count;
        }

        public int Count { get; }

        public string Canonicalize() => $"colors({Count})";

        public override string ToString() => Canonicalize();

        public static ColorsFilter Create(in CallSyntax syntax)
        {
            return new ColorsFilter(int.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}