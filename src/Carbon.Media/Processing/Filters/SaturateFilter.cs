using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public class SaturateFilter : IFilter, ICanonicalizable
    {
        public SaturateFilter(float amount)
        {
            if (amount < -2 || amount > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -2 and 2");
            }

            Amount = amount;
        }

        public float Amount { get; }

        public static SaturateFilter Create(in CallSyntax syntax)
        {
            return new SaturateFilter((float)Unit.Parse(syntax.Arguments[0].Value.ToString()).Value);
        }

        #region ToString()

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("saturate(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion
    }
}