using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct Unit : IEquatable<Unit>
    {
        public static readonly Unit None = default;

        public Unit(double value, UnitType type = default)
        {
            Value = value;
            Type = type;
        }

        [DataMember(Name = "type", Order = 1)]
        public UnitType Type { get; }

        [DataMember(Name = "value", Order = 2)]
        public double Value { get; }
        
        public double Scale => Type == UnitType.Percentage ? 0.01: 1;

        public static implicit operator double(Unit unit) => unit.Value;

        public static implicit operator Unit(int quantity) => new Unit(quantity);

        public static implicit operator float(Unit value) => (float)(value.Value * value.Scale);

        public static Unit operator *(Unit left, double right) =>
            new Unit(left.Value * right, left.Type);

        public override string ToString()
        {
            if (Type != UnitType.None)
            {
                return Value + UnitTypeHelper.GetSymbol(Type);
            }

            return Value.ToString();         
        }

        public static Unit Percent(double value) => new Unit(value, UnitType.Percentage);

        public static Unit Px(double value) => new Unit(value, UnitType.Px);

        public static Unit Pt(double value) => new Unit(value, UnitType.Pt);

        public static Unit Meters(double value) => new Unit(value, UnitType.M);

        // 50%
        // 50m
        // 50 m

        public static Unit Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

            if (text == "_")
            {
                return None;
            }

            int unitIndex = 0;

            foreach (var c in text)
            {
                if (unitIndex == 0 && c == '-')
                {
                    unitIndex++;
                }
                else if (char.IsDigit(c) || c == '.')
                {
                    unitIndex++;
                }
                else
                {
                    break;
                }
            }

            if (unitIndex == text.Length)
            {
                return new Unit(double.Parse(text), UnitType.None);
            }
            else
            {
                string number = text.Substring(0, unitIndex);

                // skip optional space
                if (text[unitIndex] == ' ')
                {
                    unitIndex++;
                }

                UnitType unitType = UnitTypeHelper.Parse(text.Substring(unitIndex));
   
                return new Unit(double.Parse(number), unitType);
            }
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