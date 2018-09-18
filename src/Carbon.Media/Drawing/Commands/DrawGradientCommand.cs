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

        public static DrawGradientCommand Create(in CallSyntax syntax)
        {
            (_, var name) = syntax.Arguments[0];

            var mode  = BlendMode.Normal;
            var align = Alignment.Left;

            var box = new UnboundBox();

            for (int i = 1; i < syntax.Arguments.Length; i++)
            {
                ref Argument arg = ref syntax.Arguments[i];
                
                switch (arg.Name)
                {
                    case "mode"   : mode        = BlendModeHelper.Parse(arg.Value); break;
                    case "align"  : align       = AlignmentHelper.Parse(arg.Value); break;
                    case "x"      : box.X       = Unit.Parse(arg.Value);            break;
                    case "y"      : box.Y       = Unit.Parse(arg.Value);            break;
                    case "width"  : box.Width   = Unit.Parse(arg.Value);            break;
                    case "height" : box.Height  = Unit.Parse(arg.Value);            break;
                    case "padding": box.Padding = UnboundPadding.Parse(arg.Value);  break;
                }
            }

            return new DrawGradientCommand(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
