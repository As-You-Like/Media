using System.Text;

namespace Carbon.Media.Processing
{
    public class SharpenFilter : IFilter, ICanonicalizable
    {
        public SharpenFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

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
            return new SharpenFilter((float)Unit.Parse(syntax.Arguments[0].Value.ToString()).Value);
        }
    }
}