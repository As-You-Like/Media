namespace Carbon.Media
{
    public sealed class ApplyFilter : IProcessor
    {
        public ApplyFilter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString() 
            => $"{Name}({Value})";

        public static ApplyFilter Parse(string key)
        {
            var parts = key.Split('(');

            var name  = parts[0];
            var value = parts[1].TrimEnd(')');

            return new ApplyFilter(name, value);
        }
    }
}