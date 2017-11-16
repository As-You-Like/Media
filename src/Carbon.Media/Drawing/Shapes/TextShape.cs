using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class TextShape : Shape
    {
        public TextShape(
            string text,
            UnboundBox box,
            Font? font = null,
            Alignment? align = null,
            BlendMode blendMode = BlendMode.Normal,
            string color = null)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            Content = text ?? throw new ArgumentNullException(nameof(text));
            Font    = font;
            Color   = color;
        }

        public string Content { get; }

        public string Color { get; }

        public Font? Font { get; }

        internal override IEnumerable<(string, string)> Args()
        {
            if (Color != null) yield return ("color", Color);

            if (Font != null) yield return ("font", Font.ToString());

            foreach (var arg in base.Args())
            {
                yield return arg;
            }
        }

        // text(hello+world,font:12px Tacoma,align:center)
        
        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("text(");

            sb.Append(Content);

            foreach (var (key, value) in Args())
            {
                sb.Append(",");

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(")");
        }

        public static new TextShape Parse(string key)
        {
            var argStart = key.IndexOf('(') + 1;

            var args = ArgumentList.Parse(key.Substring(argStart, key.Length - argStart - 1));
            
            (_, var content) = args[0]; // TODO: Base64 support

            var box = new UnboundBox();

            string color = null;
            Alignment? align = null;
            Font? font = null;
            BlendMode mode = BlendMode.Normal;

            for (var i = 1; i < args.Length; i++)
            {
                var (k, v) = args[i];
                
                switch (k)
                {
                    case "align"    : align       = v.ToEnum<Alignment>(true); break;
                    case "mode"     : mode        = v.ToEnum<BlendMode>(true); break;
                    case "x"        : box.X       = Unit.Parse(v);             break;
                    case "y"        : box.Y       = Unit.Parse(v);             break;
                    case "width"    : box.Width   = Unit.Parse(v);             break;
                    case "height"   : box.Height  = Unit.Parse(v);             break;
                    case "padding"  : box.Padding = UnboundPadding.Parse(v);   break;
                    case "font"     : font        = Drawing.Font.Parse(v);     break;
                    case "color"    : color = v;                               break;
                }
            }

            return new TextShape(content, box, font, align, mode, color);
        }
    }
}

/* 
text(hello+world,font:Tacoma,size:12px)
*/