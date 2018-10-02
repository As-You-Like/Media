using System.Text;

namespace Carbon.Media.Processing
{
    public class DetectFilter : IFilter
    {
        public DetectFilter(string name, string algorithm)
        {
            Name = name;
            Algorithm = algorithm;
        }

        public string Name { get; }

        public string Algorithm { get; }

        #region ToString()

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("detect(");

            sb.Append(Name);

            if (Algorithm != null)
            {
                sb.Append(",algorithm:");
                sb.Append(Algorithm);
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static DetectFilter Create(in CallSyntax syntax)
        {
            syntax.TryGetValue("algorithm", out string algorithm);

            if (algorithm is null && syntax.Arguments.Length > 1 && syntax.Arguments[1].Name is null)
            {
                algorithm = (string)syntax.Arguments[1].Value;
            }   

            return new DetectFilter((string)syntax.Arguments[0].Value, algorithm);
        }
    }
}
