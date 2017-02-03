using System.Collections.Generic;

namespace Carbon.Media
{
    public abstract class DrawBase : IProcessor
    {
        public DrawBase(
            Box box,
            Alignment? align,
            BlendMode blendMode,
            ScaleMode scaleMode)
        {
            Box = box;
            Align = align;
            BlendMode = blendMode;
            ScaleMode = ScaleMode;
        }

        public Box Box { get; }

        public Alignment? Align { get; } // Alignment within the box

        public BlendMode BlendMode { get; }

        public ScaleMode ScaleMode { get; set; } // Scale within the box

        // TODO: Use tuple w/ C# 7
        internal virtual IEnumerable<KeyValuePair<string, string>> Args()
        {
            // Mode

            if (Box.X != null)                     yield return new KeyValuePair<string, string>("x"       , Box.X.Value.ToString());
            if (Box.Y != null)                     yield return new KeyValuePair<string, string>("y"       , Box.Y.Value.ToString());
            if (Box.Width != null)                 yield return new KeyValuePair<string, string>("width"   , Box.Width.Value.ToString());
            if (Box.Height != null)                yield return new KeyValuePair<string, string>("height"  , Box.Width.Value.ToString());
            if (Align != null)                     yield return new KeyValuePair<string, string>("align"   , Align.Value.ToLower());
            if (!Box.Padding.Equals(Padding.Zero)) yield return new KeyValuePair<string, string>("padding" , Box.Padding.ToString());
        }
    }
}
