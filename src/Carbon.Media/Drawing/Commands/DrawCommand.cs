using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public abstract class DrawCommand
    {
        public DrawCommand(
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

        public static DrawCommand Parse(string text)
        {
            var syntax = CallSyntax.Parse(text);
            
            switch (syntax.Name)
            {
                case "circle"    : return DrawCircleCommand.Create(syntax);
                case "gradient"  : return DrawGradientCommand.Create(syntax);
                case "image"     : return DrawImageCommand.Create(syntax);
                case "path"      : return DrawPathCommand.Create(syntax);
                case "rectangle" : return DrawRectangleCommand.Create(syntax);
                case "square"    : return DrawRectangleCommand.Create(syntax);
                case "text"      : return DrawTextCommand.Create(syntax);
            }

            throw new Exception("Invalid Command:" + syntax.Name);
        }
    }
}
