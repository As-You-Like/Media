using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct Unit : IEquatable<Unit>
    {
        public static readonly Unit None = default;

        public Unit(double value, UnitType type = UnitType.Px)
        {
            Value = value;
            Type = type;
        }

        [DataMember(Name = "type", Order = 1)]
        public UnitType Type { get; }

        [DataMember(Name = "value", Order = 2)]
        public double Value { get; }

        public static implicit operator double(Unit unit) => unit.Value;

        public static implicit operator Unit(int quantity) => new Unit(quantity);

        public static Unit operator *(Unit left, double right) =>
            new Unit(left.Value * right, left.Type);

        // ％ = large unicode
        public override string ToString()
        {
            switch (Type)
            {
                case UnitType.Percent : return (Value * 100) + "％";
                case UnitType.Meter   : return Value + " m";
                case UnitType.Second  : return Value + " s";
                default               : return Value.ToString();
            }
        }

        public static Unit Percent(double value) => new Unit(value, UnitType.Percent);

        public static Unit Px(int value) => new Unit(value);

        public static Unit Meters(double value) => new Unit(value, UnitType.Meter);

        // 50％
        // 50m
        // 50 m

        public static Unit Parse(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (text.Length == 1 && text[0] == '_')
            {
                return None;
            }

            if (text.EndsWith("px"))
            {
                text = text.Substring(0, text.Length - 2);

                return new Unit(double.Parse(text), UnitType.Px);
            }

            else if (text[text.Length - 1] == '％' || text[text.Length - 1] =='%')
            {
                text = text.Substring(0, text.Length - 1);

                return new Unit(double.Parse(text) / 100d, UnitType.Percent);
            }

            else if (text.EndsWith(" m"))
            {
                text = text.Substring(0, text.Length - 2);

                return new Unit(double.Parse(text), UnitType.Meter);
            }

            if (text.IndexOf('.') > -1)
            {
                return new Unit(double.Parse(text), UnitType.Percent);
            }

            return new Unit(double.Parse(text));
        }

        #region Comparisions

        public static bool operator >(Unit lhs, Unit rhs) => lhs.Value > rhs.Value;

        public static bool operator <(Unit lhs, Unit rhs) => lhs.Value < rhs.Value;

        #endregion

        #region Equality

        public override bool Equals(object obj) => obj is Unit other && Equals(other);

        public bool Equals(Unit other) =>
            Type == other.Type &&
            Value == other.Value;

        public static bool operator ==(Unit lhs, Unit rhs) => lhs.Equals(rhs);

        public static bool operator !=(Unit lhs, Unit rhs) => !lhs.Equals(rhs);

        public override int GetHashCode() => (Type, Value).GetHashCode();

        #endregion
    }
}
