using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class CustomFilter : IFilter, ICanonicalizable
    {
        public CustomFilter(string name, Argument[] args)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
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

            for (int i = 0; i < Arguments.Length; i++)
            {
                ref Argument arg = ref Arguments[i];

                if (i > 0)
                {
                    sb.Append(',');
                }

                if (arg.Name != null)
                {
                    sb.Append(arg.Name);
                    sb.Append(':');
                }

                sb.Append(arg.Value);
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        public static CustomFilter Create(in CallSyntax syntax)
        {
            return new CustomFilter(syntax.Name, syntax.Arguments);
        }
    }
}

// name(args)