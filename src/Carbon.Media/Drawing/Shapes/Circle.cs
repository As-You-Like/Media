using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class Circle : Shape
    {
        public Circle(
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

            foreach (var (key, value) in Args())
            {
                sb.Append(",");

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(")");
        }

        public static new Circle Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            var args = ArgumentList.Parse(text.Substring(argStart, text.Length - argStart - 1));
            
            var radius = int.Parse(args[0].Value);
            
            var mode  = BlendMode.Normal;

            string stroke = null;
            string fill = null;

            var box = new UnboundBox();

            for (var i = 1; i < args.Length; i++)
            {
                var (k, v) = args[i];
                
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

            return new Circle(radius, box, mode);
        }
    }
}