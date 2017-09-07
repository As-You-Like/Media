using System;

namespace Carbon.Media.Processors
{
    public sealed class CustomFilter : IFilter
    {
        public CustomFilter(string name, string value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public string Canonicalize() =>
            $"{Name}({Value})";

        public override string ToString() =>
            Canonicalize();

        public static CustomFilter Parse(string key)
        {
            var parts = key.Split('(');

            if (parts.Length < 2)
                throw new Exception("No args provider to filter:" + key);

            var name  = parts[0];
            var value = parts[1].TrimEnd(')');

            return new CustomFilter(name, value);
        }
    }
}