using System;
using System.Text;

namespace Carbon.Media.Processors
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

        public static SaturateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new SaturateFilter((float)Unit.Parse(segment).Value);
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