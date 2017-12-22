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
        
        public int Radius { get; set; }

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

        public static DrawCircleCommand Create(CallSyntax syntax)
        {
            var radius = int.Parse(syntax.Arguments[0].Value);
            
            var mode  = BlendMode.Normal;

            string stroke = null;
            string fill = null;

            var box = new UnboundBox();

            for (var i = 1; i < syntax.Arguments.Length; i++)
            {
                var (k, v) = syntax.Arguments[i];
                
                switch (k)
                {
                    case "fill"   : fill = v;   break;
                    case "stroke" : stroke = v; break;
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);    break;
                }
            }

            return new DrawCircleCommand(radius, box, mode);
        }
    }
}