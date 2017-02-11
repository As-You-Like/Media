using System;

namespace Carbon.Media.Processors
{
    public sealed class UnknownFilter : IFilter
    {
        public UnknownFilter(string name, string value)
        {
            #region Preconditions

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            #endregion

            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public string Canonicalize() =>
            $"{Name}({Value})";

        public override string ToString() =>
            Canonicalize();

        public static UnknownFilter Parse(string key)
        {
            var parts = key.Split('(');

            var name  = parts[0];
            var value = parts[1].TrimEnd(')');

            return new UnknownFilter(name, value);
        }
    }
}