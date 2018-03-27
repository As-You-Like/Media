namespace Carbon.Media
{
    public readonly struct Argument
    {
        public Argument(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public void Deconstruct(out string name, out string value)
        {
            name = Name;
            value = Value;
        }

        public override string ToString()
        {
            if (Name == null) return Value;

            return Name + ":" + Value;
        }
    }
}