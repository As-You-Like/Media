using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class DrawCircleCommand : DrawCommand
    {
        public DrawCircleCommand(
            int radius,
            UnboundBox box,
            BlendMode mode = BlendMode.Normal)
            : base(box, null, mode, ResizeFlags.None)
        {
            Radius = radius;
        }

        public int Radius { get; }

        public string Stroke { get; set; }

        public string Fill { get; set; }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("circle(");

            sb.Append(Radius);

            foreach (var (key, value) in GetArguments())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static DrawCircleCommand Create(in CallSyntax syntax)
        {
            var radius = int.Parse(syntax.Arguments[0].Value);

            var mode = BlendMode.Normal;

            string stroke = null;
            string fill = null;

            var box = new UnboundBox();

            for (int i = 1; i < syntax.Arguments.Length; i++)
            {
                ref Argument arg = ref syntax.Arguments[i];

                switch (arg.Name)
                {
                    case "fill"     : fill = arg.Value; break;
                    case "stroke"   : stroke = arg.Value; break;
                    case "mode"     : mode = arg.Value.ToEnum<BlendMode>(true); break;
                    case "x"        : box.X = Unit.Parse(arg.Value); break;
                    case "y"        : box.Y = Unit.Parse(arg.Value); break;
                    case "width"    : box.Width = Unit.Parse(arg.Value); break;
                    case "height"   : box.Height = Unit.Parse(arg.Value); break;
                    case "padding"  : box.Padding = UnboundPadding.Parse(arg.Value); break;
                }
            }

            return new DrawCircleCommand(radius, box, mode);
        }
    }
}