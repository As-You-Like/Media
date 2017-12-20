using System;

namespace Carbon.Media.Drawing
{
    public readonly struct Font
    {
        public Font(string name, string weight, Unit size)
        {
            Name   = name ?? throw new ArgumentNullException(nameof(name));
            Weight = weight;
            Size   = size;
        }

        public readonly string Name;

        public readonly string Weight;

        public readonly Unit Size;

        public override string ToString() => Name;

        public static Font Parse(string text)
        {
            var parts = text.Split(Seperators.Space);

            if (parts.Length == 1)
            {
                return new Font(text, "normal", new Unit(12, UnitType.Px));
            }

            // 12px Name

            return new Font(
                name   : parts[1], 
                weight : "normal", 
                size   : Unit.Parse(parts[0])
            );
        }
    }
}