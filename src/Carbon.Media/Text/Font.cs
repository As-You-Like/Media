using System;

namespace Carbon.Media.Processors
{
    public struct Font
    {
        public Font(string name, string weight, Unit size)
        {
            Name   = name ?? throw new ArgumentNullException(nameof(name));
            Weight = weight;
            Size   = size;
        }

        public string Name { get; }

        public string Weight { get; }

        public Unit Size { get; }

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

/* 
text(hello+world,font:Tacoma,size:12px)
*/