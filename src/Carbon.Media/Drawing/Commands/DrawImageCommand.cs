using System;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class DrawImageCommand : DrawCommand
    {
        public DrawImageCommand(       
            string src,
            UnboundBox box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment align = Alignment.Left)
            : base(box, align, blendMode, ResizeFlags.None)
        {

            Src = src ?? throw new ArgumentNullException(nameof(src));
        }

        public string Src { get; set; }

        // image(src.jpeg,width:100,x:0,y:0,align:center)

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("image(");

            foreach (var (key, value) in GetArguments())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static DrawImageCommand Create(CallSyntax syntax)
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

            return new DrawImageCommand(name, box, mode, align);
        }
    }
}