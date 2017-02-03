using System;

namespace Carbon.Media
{
    public sealed class Overlay : ITransform
    {
        public Overlay(string o,
            Unit? x = null,
            Unit? y = null,
            Unit? width = null,
            Unit? height = null,
            BlendMode mode = BlendMode.Normal,
            Alignment align = Alignment.Left)
        {
            Key = o;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            BlendMode = mode;
            Align = align;
        }

        // color:
        // gradient:
        // image:
        // text:

        // Color, Gradient, Text, Image

        public string Key { get; set; }

        public BlendMode BlendMode { get; }

        public Alignment Align { get; } // Alignment within the box

        public ScaleMode ScaleMode { get; set; } // Scale within the box

        public Unit? X { get; set; }

        public Unit? Y { get; set; }

        public Unit? Width { get; set; }

        public Unit? Height { get; set; }

        // overlay(hello,width:100,x:0,y:0,align:center)
        
        public static Overlay Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("overlay("))
            {
                key = key.Remove(0, 8); // text(

                key = key.Substring(0, key.Length - 1); // )
            }

            #endregion

            var parts = key.Split(Seperators.Comma);

            var name = parts[0];

            var mode = BlendMode.Normal;
            var align = Alignment.Left;

            Unit? x = null;
            Unit? y = null;
            Unit? width = null;
            Unit? height = null;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "mode"   : mode   = (BlendMode)Enum.Parse(typeof(BlendMode), v, true); break;
                    case "align"  : align = (Alignment)Enum.Parse(typeof(Alignment), v, true); break;
                    case "x"      : x = Unit.Parse(v); break;
                    case "y"      : y = Unit.Parse(v); break;
                    case "width"  : width = Unit.Parse(v); break;
                    case "height" : height = Unit.Parse(v); break;
                }
            }

            return new Overlay(name, x, y, width, height, mode, align);
        }
    }


    public struct Unit
    {
        public Unit(double value, UnitType type = UnitType.Px)
        {
            Value = value;
            Type = type;
        }

        public double Value { get; }

        public UnitType Type { get; }

        public static implicit operator double(Unit unit)
            => unit.Value;
        
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
        
    }

    public enum UnitType
    {
        Px,
        Percent
    }
}

/*
overlay(red,mode:burn)
*/
