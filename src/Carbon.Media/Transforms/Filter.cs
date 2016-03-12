namespace Carbon.Media
{
    public class ApplyFilter : ITransform
    {
        private readonly string name;
        private readonly string value;

        public ApplyFilter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name => name;

        public string Value => value;

        public override string ToString() => $"{name}({value})";

        public static ApplyFilter Parse(string key)
        {
            var name = key.Split('(')[0];
            var value = key.Split('(')[1].TrimEnd(')');

            return new ApplyFilter(name, value);
        }
    }
}