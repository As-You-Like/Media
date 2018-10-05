using System;
using System.Collections.Generic;
using System.Text;
using Carbon.Media.Processing;

namespace Carbon.Media.Drawing
{
    public class DrawCommand : IProcessor, ICanonicalizable
    {
        public DrawCommand(
            Alignment align,
            Unit? x,
            Unit? y,
            BlendMode blendMode,
            string fill,
            string stroke,
            Shape[] objects)
        {
            Align = align;
            X = x;
            Y = y;
            BlendMode = blendMode;
            Fill = fill;
            Stroke = stroke;
            Objects = objects;

        }

        public Alignment Align { get; }

        public Unit? X { get; }

        public Unit? Y { get; }
        
        public BlendMode BlendMode { get; }

        public string Fill { get; }

        public string Stroke { get; }

        public Shape[] Objects { get; }

        internal IEnumerable<Argument> GetArguments()
        {
            // Mode

            if (Align != default) yield return new Argument("align", Align);
            if (X != null)            yield return new Argument("x", X.Value);
            if (Y != null)            yield return new Argument("y", Y.Value);
            if (Fill != null)         yield return new Argument("fill", Fill);
            if (Stroke != null)       yield return new Argument("stroke", Stroke);

            if (BlendMode != BlendMode.Normal)
            {
                yield return new Argument("blendMode", BlendMode);
            }
        }

        public static DrawCommand Parse(ReadOnlySpan<char> text)
        {
            if (text.StartsWith("draw(".AsSpan()))
            {
                text = text.Slice(5, text.Length - 6);
            }

            var parser = new DrawArgumentReader(text);

            Alignment align = default;
            BlendMode blendMode = BlendMode.Normal;
            Unit? x = null;
            Unit? y = null;
            string fill = null;
            string stroke = null;

            var objects = new List<Shape>();

            while (parser.TryRead(out var arg))
            {
                // circle
                // 

                if (arg.Name == null)
                {
                    objects.Add(Shape.Parse(arg.Value.ToString()));
                }
                else
                {
                    string value = arg.Value.ToString();

                    switch (arg.Name)
                    {
                        case "align"     : align = AlignmentHelper.Parse(value); break;
                        case "blendMode" : blendMode = BlendModeHelper.Parse(value); break;
                        case "x"         : x = Unit.Parse(value); break;
                        case "y"         : y = Unit.Parse(value); break;
                        case "fill"      : fill = value; break;
                        case "stroke"    : stroke = value; break;
                    }
                }
            }

            return new DrawCommand(align, x, y, blendMode, fill, stroke, objects.ToArray());
        }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("draw(");

            var i = 0;
            
            foreach (var shape in Objects)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }

                sb.Append(shape.ToString());

                i++;
            }

            foreach (var arg in GetArguments())
            {
                sb.Append(',');
                sb.Append(arg.Name);
                sb.Append(':');
                sb.Append(arg.Value);
            }


            sb.Append(")");
        }

        public override string ToString() => Canonicalize();


    }

}

// draw(circle(100), fill: red, stroke: black, mode: burn)
