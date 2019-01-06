using System.Runtime.Serialization;

namespace Carbon.Media
{
    public readonly struct Argument
    {
        public Argument(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public Argument(string value)
        {
            Name = null;
            Value = value;
        }

        [DataMember(Name = "name", Order = 1, EmitDefaultValue = false)]
        public string Name { get; }

        [DataMember(Name = "value", Order = 2)]
        public object Value { get; }

        public void Deconstruct(out string name, out string value)
        {
            name = Name;
            value = Value.ToString();
        }

        public override string ToString()
        {
            if (Name is null) return Value.ToString();

            return Name + ":" + Value.ToString();
        }
    }
}