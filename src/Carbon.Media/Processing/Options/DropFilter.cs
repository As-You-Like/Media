using System.Text;

namespace Carbon.Media.Processing
{
    public class DropFilter : IProcessor
    {
        public DropFilter(string type)
        {
            Type = type;
        }

        public string Type { get; set; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("drop(");
            sb.Append(Type);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static DropFilter Create(in CallSyntax syntax)
        {
            var value = syntax.Arguments[0].Value;
          
            return new DropFilter(value);
        }
    }
}
