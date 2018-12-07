using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class ColorsFilter : IProcessor, ICanonicalizable
    {
        public ColorsFilter(int count)
        {
            Count = count;
        }

        public int Count { get; }
        
        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("colors(");
            sb.Append(Count);
            sb.Append(')');
        }

        #endregion

        public override string ToString() => Canonicalize();
        
        public static ColorsFilter Create(in CallSyntax syntax)
        {
            int count = int.Parse(syntax.Arguments[0].Value.ToString());

            return new ColorsFilter(count);
        }
    }
}