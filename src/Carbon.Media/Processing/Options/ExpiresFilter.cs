using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public class ExpiresFilter : IProcessor
    {
        public ExpiresFilter(DateTime timestamp)
        {
            Timestamp = timestamp;
        }

        public DateTime Timestamp { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("expires(");
            sb.Append(new DateTimeOffset(Timestamp).ToUnixTimeSeconds());
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static ExpiresFilter Create(in CallSyntax syntax)
        {
            var value = syntax.Arguments[0].Value.ToString();

            DateTime timestamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value)).UtcDateTime;
          
            return new ExpiresFilter(timestamp);
        }
    }
}
