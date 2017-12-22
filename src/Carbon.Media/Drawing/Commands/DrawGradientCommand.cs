using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class DrawGradientCommand : DrawCommand
    {
        public DrawGradientCommand(
            string content,
            UnboundBox box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            Content = content;
        }
        
        public string Content { get; }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("gradient(");

            foreach (var (key, value) in GetArguments())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static DrawGradientCommand Create(CallSyntax syntax)
        {
            (_, var name) = syntax.Arguments[0];

            var mode  = BlendMode.Normal;
            var align = Alignment.Left;

            var box = new UnboundBox();

            for (var i = 1; i < syntax.Arguments.Length; i++)
            {
                var (k, v) = syntax.Arguments[i];
                
                switch (k)
                {
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true); break;
                    case "align"  : align       = v.ToEnum<Alignment>(true); break;
                    case "x"      : box.X       = Unit.Parse(v);             break;
                    case "y"      : box.Y       = Unit.Parse(v);             break;
                    case "width"  : box.Width   = Unit.Parse(v);             break;
                    case "height" : box.Height  = Unit.Parse(v);             break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);   break;
                }
            }

            return new DrawGradientCommand(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
