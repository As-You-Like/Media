using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class BackgroundFilter : IFilter, ICanonicalizable
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

        public static BackgroundFilter Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            text = text.Substring(argStart, text.Length - argStart - 1);

            return new BackgroundFilter(text);
        }

     
    }
}