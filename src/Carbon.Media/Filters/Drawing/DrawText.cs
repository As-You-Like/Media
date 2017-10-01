using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class DrawText : DrawBase
    {
        public DrawText(
            string text,
            UnboundBox box,
            Font? font = null,
            Alignment? align = null,
            BlendMode blendMode = BlendMode.Normal,
            string color = null)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Font = font;
            Color = color;
        }

        public string Text { get; }

        public string Color { get; }

        public Font? Font { get; }

        internal override IEnumerable<(string, string)> Args()
        {
            if (Color != null) yield return ("color", Color);

            foreach (var arg in base.Args())
            {
                yield return arg;
            }
        }

        // text(hello+world,font:12px Tacoma,align:center)

        public override string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("text(");

            sb.Append(Text);

            foreach (var (key, value) in Args())
            {
                sb.Append(",");

                sb.Append(key + ":" + value);
            }

            sb.Append(")");

            return sb.ToString();
        }

        public override string ToString() => Canonicalize();

        public static DrawText Parse(string key)
        {
            #region Normalization

            var argStart = key.IndexOf('(') + 1;

            key = key.Substring(argStart, key.Length - argStart - 1);
            
            #endregion

            var parts = key.Split(Seperators.Comma);

            // TODO: Base64 support
            var text = parts[0];

            var box = new UnboundBox();

            string color = null;
            Alignment? align = null;
            Font? font = null;
            BlendMode mode = BlendMode.Normal;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "align"    : align = v.ToEnum<Alignment>(true);    break;
                    case "mode"     : mode = v.ToEnum<BlendMode>(true);     break;
                    case "x"        : box.X       = Unit.Parse(v);          break;
                    case "y"        : box.Y       = Unit.Parse(v);          break;
                    case "width"    : box.Width   = Unit.Parse(v);          break;
                    case "height"   : box.Height  = Unit.Parse(v);          break;
                    case "padding"  : box.Padding = UnboundPadding.Parse(v);       break;
                    case "font"     : font = Processors.Font.Parse(v);      break;
                    case "color"    : color = v;                            break;
                }

            }

            return new DrawText(text, box, font, align, mode, color);
        }
    }
}

/* 
text(hello+world,font:Tacoma,size:12px)
*/