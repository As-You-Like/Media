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

        public static CustomFilter Parse(string key)
        {
            int argStart = key.IndexOf('(') + 1;

            if (argStart == 0)
            {
                return new CustomFilter(key, Array.Empty<Argument>());
            }

            var name = key.Substring(0, argStart - 1);

            var args = ArgumentList.Parse(key.Substring(argStart, key.Length - argStart - 1));
            
            return new CustomFilter(name, args);
        }
    }
}