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

        [DataMember(Name = "value", Order = 1)]
        public readonly UnitType Type;

        [DataMember(Name = "value", Order = 2)]
        public readonly double Value;

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
                default               : return Value.ToString();
            }
        }

        public static Unit Percent(double value) => new Unit(value, UnitType.Percent);

        public static Unit Px(int value) => new Unit(value);

        public static Unit Meters(double value) => new Unit(value, UnitType.Meter);


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

                return new Unit(double.Parse(text), UnitType.Px);
            }

            else if (text.EndsWith("％") || text.EndsWith("%"))
            {
                text = text.Substring(0, text.Length - 1);

                return new Unit(double.Parse(text) / 100d, UnitType.Percent);
            }

            else if (text.EndsWith(" m"))
            {
                text = text.Substring(0, text.Length - 2);

                return new Unit(double.Parse(text), UnitType.Meter);
            }

            if (text.Contains("."))
            {
                return new Unit(double.Parse(text), UnitType.Percent);
            }

            return new Unit(double.Parse(text));
        }

        #region Comparisions

        public static bool operator >(Unit lhs, Unit rhs) =>
            lhs.Value > rhs.Value;

        public static bool operator <(Unit lhs, Unit rhs) =>
            lhs.Value < rhs.Value;

        #endregion

        #region Equality

        public override bool Equals(object obj) => obj is Unit other && Equals(other);
         
        public bool Equals(Unit other) => 
            Type == other.Type && 
            Value == other.Value;

        public static bool operator ==(Unit lhs, Unit rhs) =>
            lhs.Equals(rhs);

        public static bool operator !=(Unit lhs, Unit rhs) =>
            !lhs.Equals(rhs);

        public override int GetHashCode() => (Type, Value).GetHashCode();
        
        #endregion
    }

    public enum UnitType
    {
        None    = 0,
        Px      = 1,
        Percent = 2,
        Meter   = 10
    }
}
