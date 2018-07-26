using System.Text;

namespace Carbon.Media.Processors
{
    public class SharpenFilter : IFilter, ICanonicalizable
    {
        public SharpenFilter(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("sharpen(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static SharpenFilter Create(in CallSyntax syntax)
        {
            return new SharpenFilter(Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}