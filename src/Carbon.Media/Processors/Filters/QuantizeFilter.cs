using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class QuantizeFilter : IFilter
    {
        public QuantizeFilter(int maxColors, string algorithm = null)
        {
            if (maxColors <= 0 || maxColors > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(maxColors), maxColors, "Must be between 1 and 256");
            }

            MaxColors = maxColors;
            Algorithm = algorithm;
        }

        public int MaxColors { get; }

        public string Algorithm { get; } // wu....

        #region ToString()

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("quantize(");

            sb.Append(MaxColors);

            if (Algorithm != null)
            {
                sb.Append(",algorithm:");
                sb.Append(Algorithm);
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static QuantizeFilter Create(CallSyntax syntax)
        {
            return new QuantizeFilter(int.Parse(syntax.Arguments[0].Value));
        }
    }
}
