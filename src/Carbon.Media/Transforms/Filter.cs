namespace Carbon.Media
{
    public class ApplyFilter : ITransform
    {
        public ApplyFilter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString() => $"{Name}({Value})";

        public static ApplyFilter Parse(string key)
        {
            var name = key.Split('(')[0];
            var value = key.Split('(')[1].TrimEnd(')');

            return new ApplyFilter(name, value);
        }
    }
}