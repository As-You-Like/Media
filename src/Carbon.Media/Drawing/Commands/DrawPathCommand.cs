using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class DrawPathCommand : DrawCommand
    {
        public DrawPathCommand(
            string content,
            string stroke,
            string fill,
            UnboundBox box,
            BlendMode mode = BlendMode.Normal)
            : base(box, null, mode, ResizeFlags.None)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Stroke  = stroke;
            Fill    = fill;
        }

        // M150 0 L75 200 L225 200 Z

        public string Content { get; }

        public string Stroke { get;  }

        public string Fill { get; }

        internal override IEnumerable<Argument> GetArguments()
        {
            if (Fill != null)
                yield return new Argument("fill", Fill);

            if (Stroke != null)
                yield return new Argument("stroke", Stroke);

            foreach (var arg in base.GetArguments())
            {
                yield return arg;
            }
        }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("path(");

            sb.Append(Content);

            foreach (var (key, value) in GetArguments())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static DrawPathCommand Create(in CallSyntax syntax)
        {
            var mode  = BlendMode.Normal;
            string content = null;

            string stroke = null;
            string fill = null;

            var i = 0;
            var box = new UnboundBox();

            foreach (var (k, v) in syntax.Arguments)
            {
                if (i == 0)
                {
                    content = v;

                    continue;
                }

                switch (k)
                {
                    case "fill"   : fill        = v;                          break;
                    case "stroke" : stroke      = v;                          break;
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);    break;
                }

                i++;
            }

            return new DrawPathCommand(
                content : content, 
                stroke  : stroke,
                fill    : fill,
                box     : box, 
                mode    : mode
            );
        }
    }
}

/*
path(M150 0 L75 200 L225 200 Z, stroke: red, fill: black)
*/
