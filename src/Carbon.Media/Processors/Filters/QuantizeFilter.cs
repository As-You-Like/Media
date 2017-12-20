using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class QuantizeFilter : IFilter
    {
        public QuantizeFilter(int maxColors, string algorithm = null)
        {
            if (maxColors <= 0)
            {
                throw new ArgumentException("Must be > 0", nameof(maxColors));
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

        public static QuantizeFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new QuantizeFilter(int.Parse(segment));
        }
    }
}
