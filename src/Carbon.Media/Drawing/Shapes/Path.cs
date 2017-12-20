using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class Path : Shape
    {
        public Path(
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

        internal override IEnumerable<(string, string)> Args()
        {
            if (Fill != null)
                yield return ("fill", Fill);

            if (Stroke != null)
                yield return ("stroke", Stroke);

            foreach (var arg in base.Args())
            {
                yield return arg;
            }
        }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("path(");

            sb.Append(Content);

            foreach (var (key, value) in Args())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static new Path Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            var args = ArgumentList.Parse(text.Substring(argStart, text.Length - argStart - 1));
            
            var mode  = BlendMode.Normal;
            string content = null;

            string stroke = null;
            string fill = null;

            var i = 0;
            var box = new UnboundBox();

            foreach (var (k, v) in args)
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

            return new Path(
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
