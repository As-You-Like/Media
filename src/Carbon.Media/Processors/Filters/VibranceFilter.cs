using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class VibranceFilter : IFilter, ICanonicalizable
    {
        public VibranceFilter(double amount)
        {
            if (amount < -10 || amount > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -10 and 10");
            }

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
            sb.Append("vibrance(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static VibranceFilter Create(in CallSyntax syntax)
        {
            return new VibranceFilter(double.Parse(syntax.Arguments[0].Value));
        }
    }
}