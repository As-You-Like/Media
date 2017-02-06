using System;

namespace Carbon.Media
{
    public struct Unit : IEquatable<Unit>
    {
        public static readonly Unit None = new Unit(0, UnitType.None);

        public Unit(double value, UnitType type = UnitType.Px)
        {
            Value = value;
            Type = type;
        }

        public double Value { get; }

        public UnitType Type { get; }

        public static implicit operator double(Unit unit) => unit.Value;

        public static implicit operator Unit(int quantity) => new Unit(quantity);

        // ％ = large unicode
        public override string ToString()
        {
            switch (Type)
            {
                case UnitType.Percent : return (Value * 100) + "％";
                default               : return Value.ToString();
            }
        }

        public static Unit Percent(double value)
            => new Unit(value, UnitType.Percent);

        public static Unit Px(int value)
            => new Unit(value);

        // 50％

        public static Unit Parse(string text)
        {
            if (text == "_")
            {
                return None;
            }

            if (text.EndsWith("px"))
            {
                text = text.Substring(0, text.Length - 2);

                return new Unit(double.Parse(text));
            }

            else if (text.EndsWith("％"))
            {
                text = text.Substring(0, text.Length - 1);

                return new Unit(double.Parse(text) / 100d, UnitType.Percent);
            }

            if (text.Contains("."))
            {
                return new Unit(double.Parse(text), UnitType.Percent);
            }

            return new Unit(double.Parse(text));
        }

        public bool Equals(Unit other) => 
            Type == other.Type && Value == other.Value;
    }

    public enum UnitType
    {
        None    = 0,
        Px      = 1,
        Percent = 2
    }
}
