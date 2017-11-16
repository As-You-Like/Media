using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class Metadata : ITransform
    {
        public Metadata(string[] properties) // graphql?
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public string[] Properties { get; }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();
            
            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("metadata(");

            var i = 0;

            foreach (var property in Properties)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }

                sb.Append(property);

                i++;
            }

            sb.Append(")");
        }

        public static Metadata Parse(string key)
        {
            if (!key.StartsWith("metadata("))
            {
                throw new Exception("must start with metadata(");
            }

            // get text inside parathesis
            key = key.Substring(9, key.Length - 10);


            if (key.StartsWith("{"))
            {
                // trim { } 
                key = key.Substring(1, key.Length - 2);
            }

            var properties = key.Split(Seperators.Comma);

            return new Metadata(properties);
        }
    }
}

// metadata({width,height})