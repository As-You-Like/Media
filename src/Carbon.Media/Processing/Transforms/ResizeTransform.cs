using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class ResizeTransform : IProcessor
    {
        private readonly Unit width;
        private readonly Unit height;

        public ResizeTransform(Size size)
            : this(new Unit(size.Width), new Unit(size.Height), null, ResizeFlags.None)
        { }

        public ResizeTransform(Size size, CropAnchor? anchor)
            : this(new Unit(size.Width), new Unit(size.Height), anchor, ResizeFlags.None)
        { }

        public ResizeTransform(Unit width, Unit height, ResizeFlags flags = default)
            : this(width, height, null, flags) { }

        public ResizeTransform(Unit width, Unit height, CropAnchor? anchor, ResizeFlags flags)
        {
            if (width < 0 || width > Constants.MaxWidth)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 16,383");

            if (height < 0 || height > Constants.MaxHeight)
                throw new ArgumentOutOfRangeException(nameof(height), height, message: "Must be between 0 and 16,383");

            this.width  = width;
            this.height = height;
            Anchor = anchor;
            Flags  = flags;
        }

        public Unit Width => width;

        public Unit Height => height;

        public ResizeFlags Flags { get; }

        public CropAnchor? Anchor { get; }

        public InterpolaterMode InterpolaterMode { get; } = InterpolaterMode.Lanczos3;

        public Size CalcuateSize(Size source)
        {
            int returnWidth  = source.Width;
            int returnHeight = source.Height;

            if (width == Unit.None) // auto
            {
                double scale = height.Value / source.Height;

                returnWidth = (int)(returnWidth * scale);
            }
            else if (width.Type == UnitType.Percentage)
            {
                returnWidth = (int)(source.Width * (Width.Value * width.Scale));
            }
            else // px
            {
                returnWidth = (int)Width;
            }

            if (height == Unit.None) // auto
            {
                double scale = width.Value / source.Width;

                returnHeight = (int)(returnHeight * scale);
            }
            else if (height.Type == UnitType.Percentage)
            {
                returnHeight = (int)(source.Height * (Height.Value * width.Scale));
            }
            else
            {
                returnHeight = (int)Height;
            }

            return new Size(returnWidth, returnHeight);
        }

        #region Flags

        public ResizeFlags Mode
        {
            get
            {
                var mode = Flags & ResizeFlags.Modes;

                if (mode == ResizeFlags.None && Anchor != null)
                {
                    return ResizeFlags.Crop;
                }

                return mode;
            }
        }

        public bool Carve => (Flags & ResizeFlags.Carve) != 0;

        public bool Upscale => (Flags & ResizeFlags.Upscale) != 0;

        #endregion

        #region ICanonicalizable

        // resize(100,100,anchor:center)
        // resize(100,100,flags:fit)

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("resize(");
            sb.Append(Width.Value);
            sb.Append(',');
            sb.Append(Height.Value);
            
            WriteOptions(sb);

            sb.Append(')');
        }

        #endregion

        public override string ToString()
        {
            // 100x100,stretch,anchor:center,background:red

            var sb = StringBuilderCache.Aquire();

            sb.Append(in width);
            sb.Append('x');
            sb.Append(in height);

            if (Flags != ResizeFlags.None)
            {
                WriteOptions(sb);
            }
            else if (Anchor != null)
            {
                sb.Append('-');
                sb.Append(Anchor.Value.ToCode());
            }

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        private void WriteOptions(StringBuilder sb)
        {
            if (Flags != ResizeFlags.None)
            {
                sb.Append(',');
                sb.Append(Flags.ToLower());
            }

            if (Anchor != null)
            {
                sb.Append(",anchor:");
                sb.Append(Anchor.Value.ToCode());
            }
        }

        // 100×100
        // 100x100
        // 100x100,contain
        // 100x100-c
        // resize(100,100,contain)
        public static ResizeTransform Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                segment = segment.Substring(argStart, segment.Length - argStart - 1);
            }

            int dashIndex = segment.IndexOf('-');
            
            // {width}x{height}-{anchor}
            // e.g. 100x100-c
            if (dashIndex > -1)
            {
                return new ResizeTransform(
                    size   : SizeHelper.Parse(segment.Substring(0, dashIndex)),
                    anchor : CropAnchorHelper.Parse(segment.Substring(dashIndex + 1))
                );
            }
            else if (segment.IndexOf(',') > -1)
            {
                var args = ArgumentList.Parse(segment);

                Unit width = default;
                Unit height = default;
                ResizeFlags flags = default;
                CropAnchor? anchor = null;

                for (int i = 0; i < args.Length; i++)
                {
                    ref Argument arg = ref args[i];

                    int xIndex = arg.Value.ToString().IndexOf('x');

                    if (i == 0 && xIndex > -1)
                    {
                        width  = Unit.Parse(arg.Value.ToString().Substring(0, xIndex));
                        height = Unit.Parse(arg.Value.ToString().Substring(xIndex + 1));

                        continue;
                    }

                    if (i == 0 && width == default)
                    {
                        width = Unit.Parse(arg.Value.ToString());
                    }
                    else if (i == 1 && height == default)
                    {
                        height = Unit.Parse(arg.Value.ToString());
                    }
                    else
                    {
                        switch (arg.Name)
                        {
                            case "anchor" : anchor = CropAnchorHelper.Parse(arg.Value.ToString()); break;
                            case null     : flags = ResizeFlagsHelper.Parse(arg.Value.ToString()); break;
                            default       : throw new Exception("Invalid resize argument:" + arg.Name);
                        }
                    }
                }

                return new ResizeTransform(width, height, anchor, flags);
            }
            else
            {
                int xIndex = segment.IndexOf('x');

                // 100x100
                return new ResizeTransform(
                    width  : Unit.Parse(segment.Substring(0, xIndex)),
                    height : Unit.Parse(segment.Substring(xIndex + 1))
                );
            }
        }

        public static ResizeTransform operator * (ResizeTransform left, double scale)
        {
            return new ResizeTransform(
                width  : (int)(left.Width * scale),
                height : (int)(left.Height * scale),
                anchor : left.Anchor,
                flags  : left.Flags
            );
        }
    }
}

/* 


100×100,contain;anchor:center

500×0
0×500

500x500;fit:crop;anchor:center
500x500(fit:crop;anchor:center)
500x500+x:100+y:200 

500x500(fit:crop anchor:center)
 
Image Magic : 
-resize 64x64
-crop 40x30+10+10  (width,height,top,left)

-crop <width>x<height>{+-}<x>{+-}<y>{%}

*/
