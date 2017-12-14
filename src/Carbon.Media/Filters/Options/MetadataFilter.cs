using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class MetadataFilter : ITransform, ICanonicalizable
    {
        public MetadataFilter(string[] properties) // graphql?
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public string[] Properties { get; }

        #region ToString()

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();
            
            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("metadata");

            if (Properties.Length > 0)
            {
                sb.Append('(');

                var i = 0;

                foreach (var property in Properties)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }

                    sb.Append(property);

                    i++;
                }

                sb.Append(')');
            }
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static MetadataFilter Parse(string key)
        {
            if (key == "metadata")
            {
                return new MetadataFilter(Array.Empty<string>());
            }

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

            return new MetadataFilter(properties);
        }
    }
}

// metadata({width,height})