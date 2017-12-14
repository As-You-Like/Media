using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class ContrastFilter : IFilter, ICanonicalizable
    {
        public ContrastFilter(float amount)
        {
            if (amount < -10 || amount > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -10 and 10");
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

        public static ContrastFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new ContrastFilter((float)Unit.Parse(segment).Value);
        }
    }
}
