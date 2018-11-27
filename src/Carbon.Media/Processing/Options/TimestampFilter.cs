using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class TimestampFilter : IProcessor, ICanonicalizable
    {
        public TimestampFilter(double value)
        {
            Value = value;
        }

        // in seconds
        public double Value { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        // timestamp(1.13s)

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("timestamp(");
            sb.Append(Value);
            sb.Append('s');
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static TimestampFilter Create(in CallSyntax syntax)
        {
            string arg = syntax.Arguments[0].Value.ToString();

            if (arg.EndsWith("s"))
            {
                arg = arg.Substring(0, arg.Length - 1);
            }

            return new TimestampFilter(double.Parse(arg));
        }
    }
}

// timestamp(1s)
