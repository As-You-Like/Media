using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class ContrastFilter : IFilter, ICanonicalizable
    {
        public ContrastFilter(float amount)
        {
            if (amount < -10 || amount > 10)
            {
                throw ExceptionHelper.OutOfRange(nameof(amount), -10, 10, amount);
            }

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
            sb.Append("contrast(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static ContrastFilter Create(in CallSyntax syntax)
        {
            return new ContrastFilter(Unit.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}
