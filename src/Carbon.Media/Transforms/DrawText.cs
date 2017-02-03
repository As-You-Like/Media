using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media
{
    public sealed class DrawText : ITransform
    {
        public DrawText(
            string text,
            Font? font = null,
            Alignment? align = null,
            Unit? x = null,
            Unit? y= null,
            Unit? width = null, 
            Unit? padding = null,
            string color = null)
        {
            #region Preconditions

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            #endregion

            Text = text;
            Font = font;
            Align = align;
            X = x;
            Y = y;
            Width = width;
            Padding = padding;
            Color = color;
        }

        public string Text { get; }

        public Unit? X { get; }

        public Unit? Y { get; }

        public Unit? Width { get; }

        public Unit? Padding { get; }

        public BlendMode BlendMode { get; set; }

        public string Color { get; }

        public Alignment? Align { get; }

        public Font? Font { get; }

        // TODO: Use tuple w/ C# 7
        private IEnumerable<KeyValuePair<string, string>> Args()
        {
            if (Color != null)   yield return new KeyValuePair<string, string>("color"   , Color);
            if (X != null)       yield return new KeyValuePair<string, string>("x"       , X.Value.ToString());
            if (Y != null)       yield return new KeyValuePair<string, string>("y"       , Y.Value.ToString());
            if (Width != null)   yield return new KeyValuePair<string, string>("width"   , Width.Value.ToString());
            if (Align != null)   yield return new KeyValuePair<string, string>("align"   , Align.Value.ToLower());
            if (Padding != null) yield return new KeyValuePair<string, string>("padding" , Padding.Value.ToString());
        }

        // text(hello+world,font:12px Tacoma,align:center)

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("text(");

            sb.Append(Text);
            
            foreach (var arg in Args())
            {
                sb.Append(",");

                sb.Append(arg.Key + ":" + arg.Value);
            }

            sb.Append(")");

            return sb.ToString();
        }

        public static DrawText Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("text("))
            {
                key = key.Remove(0, 5); // text(
                
                key = key.Substring(0, key.Length - 1); // )
            }

            #endregion

            var parts = key.Split(Seperators.Comma);

            // TODO: Base64 support
            var text = parts[0];

            Unit? x = null;
            Unit? y = null;
            Unit? width = null;
            Unit? padding = null;
            string color = null;
            Alignment? align = null;
            Font? font = null;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "align"    : align = v.ToEnum<Alignment>(true); break;
                    case "x"        : x = Unit.Parse(v);                 break;
                    case "y"        : y = Unit.Parse(v);                 break;
                    case "width"    : width = Unit.Parse(v);             break;
                    case "padding"  : padding = Unit.Parse(v);           break;
                    case "font"     : font = Media.Font.Parse(v);        break;
                    case "color"    : color = v;                         break;
                }

            }

            return new DrawText(text, font, align, x, y, width, padding, color);
        }
    }


    public struct Font
    {
        // bold 
        public Font(string name, string weight, Unit size)
        {
            Size = size;
            Weight = weight;
            Name = name;
        }

        public string Name { get; }

        public string Weight { get; }

        public Unit Size { get; }

        public override string ToString()
        {
            return Name;
        }

        public static Font Parse(string text)
        {
            var parts = text.Split(Seperators.Space);

            if (parts.Length == 1) return new Font(text, "normal", new Unit(12, UnitType.Px));
            
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