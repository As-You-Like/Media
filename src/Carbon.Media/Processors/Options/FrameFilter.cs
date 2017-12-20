using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class FrameFilter : IProcessor, ICanonicalizable
    {
        public FrameFilter(int number)
        {
            if (number < 0)
                throw new ArgumentException("Must be > 0", nameof(number));

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
            sb.Append("frame(");
            sb.Append(Number);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static FrameFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new FrameFilter(int.Parse(segment));
        }
    }
}