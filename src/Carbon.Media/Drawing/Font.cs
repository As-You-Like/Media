using System;

namespace Carbon.Media.Drawing
{
    public class Font
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
            int spaceIndex = text.IndexOf(' ');
            
            if (spaceIndex == -1)
            {
                return new Font(text, "normal", new Unit(12, UnitType.Px));
            }

            string[] parts = text.Split(Seperators.Space);

            // 12px Name

            return new Font(
                name   : parts[1], 
                weight : "normal", 
                size   : Unit.Parse(parts[0])
            );
        }
    }
}