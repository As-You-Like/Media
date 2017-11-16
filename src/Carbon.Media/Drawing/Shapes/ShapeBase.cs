using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public abstract class Shape
    {
        public Shape(
            UnboundBox box,
            Alignment? align,
            BlendMode blendMode,
            ResizeFlags scaleMode)
        {
            Box = box;
            Align = align;
            BlendMode = blendMode;
            ScaleMode = ScaleMode;
        }

        public UnboundBox Box { get; }

        public Alignment? Align { get; } // Alignment within the box

        public BlendMode BlendMode { get; }

        public ResizeFlags ScaleMode { get; set; } // Scale within the box

        internal virtual IEnumerable<(string, string)> Args()
        {
            // Mode

            if (Box.X != null)                            yield return ("x"       , Box.X.Value.ToString());
            if (Box.Y != null)                            yield return ("y"       , Box.Y.Value.ToString());
            if (Box.Width != null)                        yield return ("width"   , Box.Width.Value.ToString());
            if (Box.Height != null)                       yield return ("height"  , Box.Width.Value.ToString());
            if (Align != null)                            yield return ("align"   , Align.Value.ToLower());
            if (!Box.Padding.Equals(UnboundPadding.Zero)) yield return ("padding" , Box.Padding.ToString());
        }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public abstract void WriteTo(StringBuilder sb);

        public override string ToString() => Canonicalize();

        public static Shape Parse(string text)
        {
            int argStart = text.IndexOf('(');

            if (argStart == -1) return null;

            var name = text.Substring(0, argStart);

            switch (name)
            {
                case "circle"    : return Circle.Parse(text);
                case "gradient"  : return Gradient.Parse(text);
                case "image"     : return DrawImage.Parse(text);
                case "path"      : return Path.Parse(text);
                case "rectangle" : return Rect.Parse(text);
                case "square"    : return Rect.Parse(text);
                case "text"      : return TextShape.Parse(text);

                default: throw new System.Exception("Unreconized shape:" + name);
            }
        }
    }
}
