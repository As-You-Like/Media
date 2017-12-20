using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class PageFilter : ITransform, ICanonicalizable
    {
        public PageFilter(int number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException(nameof(number), number, "Must be >= 0");

            Number = number;
        }

        public int Number { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("page(");
            sb.Append(Number);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static PageFilter Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            text = text.Substring(argStart, text.Length - argStart - 1);

            return new PageFilter(int.Parse(text));
        }
    }
}