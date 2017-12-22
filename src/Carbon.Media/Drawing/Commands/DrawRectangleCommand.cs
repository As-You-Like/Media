using System;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class DrawRectangleCommand : DrawCommand
    {
        public DrawRectangleCommand(
            string color,
            UnboundBox box,
            BlendMode mode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, mode, ResizeFlags.None)
        {
            Fill = color ?? throw new ArgumentNullException(nameof(color));
        }
        
        public string Fill { get; set; }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("retangle(");

            var i = 0;

            foreach (var (key, value) in GetArguments())
            {
                if (i > 0)
                {
                    sb.Append(',');
                }

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);

                i++;
            }

            sb.Append(')');
        }

        public static DrawRectangleCommand Create(CallSyntax syntax)
        {
            string fill = null;
            var mode  = BlendMode.Normal;
            Alignment? align = null;

            var box = new UnboundBox();

            var i = 0;

            foreach(var (k, v) in syntax.Arguments)
            {
                if (k == null) // positional
                {
                    switch (i)
                    {
                        case 0: box.Width = Unit.Parse(v);  break;
                        case 1: box.Height = Unit.Parse(v); break;
                        case 2: fill = v;                   break;
                    }

                    i++;

                    continue;
                }

                switch (k)
                {
                    case "fill"   : fill        = v;                          break;
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "align"  : align       = v.ToEnum<Alignment>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);    break;
                }
            }

            return new DrawRectangleCommand(fill, box, mode, align);
        }
    }
}

/*
rectangle(100,100,red,mode:burn)
*/
