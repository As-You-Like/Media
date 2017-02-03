using System;

namespace Carbon.Media
{
    public struct Unit : IEquatable<Unit>
    {
        public static readonly Unit Zero = new Unit(0, UnitType.Px);

        public Unit(double value, UnitType type = UnitType.Px)
        {
            Value = value;
            Type = type;
        }

        public double Value { get; }

        public UnitType Type { get; }

        public static implicit operator double(Unit unit)
            => unit.Value;

        public override string ToString()
        {
            return Value.ToString();

            // TODO: If it's a percent, ensure we add a decimal point
        }

        public static Unit Parse(string text)
        {
            if (text.EndsWith("px"))
            {
                text = text.Substring(0, text.Length - 2);

                return new Unit(double.Parse(text));
            }

            if (text.Contains("."))
            {
                return new Unit(double.Parse(text), UnitType.Percent);
            }

            return new Unit(double.Parse(text));
        }

        public bool Equals(Unit other)
        {
            return Type == other.Type && Value == other.Value;
        }
    }

    public enum UnitType
    {
        Px,
        Percent
    }
}
