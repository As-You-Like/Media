using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class CustomFilter : IFilter, ICanonicalizable
    {
        public CustomFilter(string name, Argument[] args)
        {
            Name      = name ?? throw new ArgumentNullException(nameof(name));
            Arguments = args;
        }

        public string Name { get; }

        public Argument[] Arguments { get; }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();
            
            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append(Name);
            sb.Append('(');

            var i = 0;

            foreach (var (key, value) in Arguments)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }

                if (key != null)
                {
                    sb.Append(key);
                    sb.Append(':');
                }

                sb.Append(value);

                i++;
            }
            sb.Append(')');
        }

        public override string ToString() =>  Canonicalize();

        // name(args)

        public static CustomFilter Create(CallSyntax syntax)
        {
            return new CustomFilter(syntax.Name, syntax.Arguments);
        }
    }
}