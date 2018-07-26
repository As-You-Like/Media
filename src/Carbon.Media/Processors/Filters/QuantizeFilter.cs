using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class QuantizeFilter : IFilter
    {
        public QuantizeFilter(int maxColors, string algorithm = null, bool? dither = null)
        {
            if (maxColors <= 0 || maxColors > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(maxColors), maxColors, "Must be between 1 and 256");
            }

            MaxColors = maxColors;
            Algorithm = algorithm;
            Dither = dither;
        }

        public int MaxColors { get; }

        public string Algorithm { get; } // wu....

        public bool? Dither { get; }

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

            if (Dither != null)
            {
                sb.Append(",dither:");
                sb.Append(Dither.Value ? "true" : "false");
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static QuantizeFilter Create(in CallSyntax syntax)
        {
            bool? dither = null;

            syntax.TryGetValue("algorithm", out string algorithm);

            if (algorithm == null && syntax.Arguments.Length > 1 && syntax.Arguments[1].Name == null)
            {
                algorithm = syntax.Arguments[1].Value;
            }

            if (syntax.TryGetValue("dither", out string ditherValue))
            {
                dither = (ditherValue == "true" || ditherValue == "1");
            }

            return new QuantizeFilter(int.Parse(syntax.Arguments[0].Value), algorithm, dither);
        }
    }
}