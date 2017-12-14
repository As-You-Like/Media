using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class CustomFilter : IFilter, ICanonicalizable
    {
        public CustomFilter(string name, string[] args)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Arguments = args;
        }

        public string Name { get; }

        public string[] Arguments { get; }

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

            foreach (var arg in Arguments)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }

                sb.Append(arg);

                i++;
            }
            sb.Append(')');
        }

        public override string ToString() =>  Canonicalize();

        // name(args)

        public static CustomFilter Parse(string key)
        {
            int argStart = key.IndexOf('(') + 1;

            if (argStart == -1)
            {
                return new CustomFilter(key, Array.Empty<string>());
            }

            var name = key.Substring(0, argStart - 1);

            var args = key.Substring(argStart, key.Length - argStart - 1);
            
            return new CustomFilter(name, args.Split(Seperators.Comma));
        }
    }
}