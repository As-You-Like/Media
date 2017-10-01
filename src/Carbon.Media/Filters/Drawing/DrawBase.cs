using System.Collections.Generic;

namespace Carbon.Media.Processors
{
    public abstract class DrawBase : ITransform
    {
        public DrawBase(
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

        public abstract string Canonicalize();

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
    }
}
