using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class BackgroundFilter : IFilter, ICanonicalizable
    {
        public BackgroundFilter(string color)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Color { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("background(");
            sb.Append(Color);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static BackgroundFilter Create(in CallSyntax syntax)
        {
            return new BackgroundFilter(syntax.Arguments[0].Value.ToString());
        }
    }
}