namespace Carbon.Media
{
    internal static class ArgumentList
    {
        public static Argument[] Parse(string text)
        {
            var parts = text.Split(Seperators.Comma);

            var args = new Argument[parts.Length];

            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];

                var colonIndex = part.IndexOf(':');
                
                args[i] = colonIndex > -1
                     ? new Argument(
                        name: part.Substring(0, colonIndex),
                        value: part.Substring(colonIndex + 1)
                     ) : new Argument(null, part);
            }

            return args;
        }
    }

    public readonly struct Argument
    {
        public Argument(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public readonly string Name;

        public readonly string Value;

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