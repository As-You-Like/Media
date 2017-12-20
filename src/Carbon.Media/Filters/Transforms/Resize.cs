using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class ResizeProcessor : ITransform
    {
        const int maxDimension = 16383; 
        
        // The maximum pixel dimensions of a WebP image is 16383 x 16383.
        // 16384 * 16384 * 4 = 1GB bitmap

        public ResizeProcessor(Size size)
            : this(new Unit(size.Width), new Unit(size.Height), null, ResizeFlags.None)
        { }

        public ResizeProcessor(Size size, CropAnchor? anchor)
            : this(new Unit(size.Width), new Unit(size.Height), anchor, ResizeFlags.None)
        { }

        public ResizeProcessor(Unit width, Unit height, ResizeFlags flags = default)
            : this(width, height, null, flags) { }

        public ResizeProcessor(Unit width, Unit height, CropAnchor? anchor, ResizeFlags flags)
        {
            #region Preconditions

            if (width < 0 || width > maxDimension)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 16,383");

            if (height < 0 || height > maxDimension)
                throw new ArgumentOutOfRangeException(nameof(height), height, message: "Must be between 0 and 16,383");

            #endregion

            Width  = width;
            Height = height;
            Anchor = anchor;
            Flags  = flags;
        }

        public Unit Height { get; }

        public Unit Width { get; }

        public ResizeFlags Flags { get; }

        public CropAnchor? Anchor { get; }

        public InterpolaterMode InterpolaterMode { get; } = InterpolaterMode.Lanczos3;

        public Size CalcuateSize(Size source)
        {
            int returnWidth  = source.Width;
            int returnHeight = source.Height;

            if (Width == Unit.None) // auto
            {
                double scale = Height.Value / source.Height;

                returnWidth = (int)(returnWidth * scale);
            }
            else if (Width.Type == UnitType.Percent)
            {
                returnWidth = (int)(source.Width * Width.Value);
            }
            else // px
            {
                returnWidth = (int)Width;
            }

            if (Height == Unit.None) // auto
            {
                double scale = Width.Value / source.Width;

                returnHeight = (int)(returnHeight * scale);
            }
            else if (Height.Type == UnitType.Percent)
            {
                returnHeight = (int)(source.Height * Height.Value);
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

        public bool Carve => Flags.HasFlag(ResizeFlags.Carve);

        public bool Upscale => Flags.HasFlag(ResizeFlags.Upscale);

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

            // Options
            WriteOptions(sb);

            sb.Append(')');
        }

        #endregion

        public override string ToString()
        {
            // 100x100,stretch,anchor:center,background:red

            var sb = StringBuilderCache.Aquire();

            sb.Append(Width);
            sb.Append('x');
            sb.Append(Height);

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

        private static readonly char[] x_x = new[] { 'x', '×' };

        public static ResizeProcessor Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                segment = segment.Substring(argStart, segment.Length - argStart - 1);
            }

            #endregion

            if (segment.Contains(",") || segment.Contains("×") || segment.Contains("％"))
            {
                var parts = segment.Split(Seperators.Comma);

                var size = parts[0].Split(x_x);

                var width  = Unit.Parse(size[0]);
                var height = Unit.Parse(size[1]);

                ResizeFlags flags = default;
                string background = null;
                CropAnchor? anchor = null;

                for (var i = 1; i < parts.Length; i++)
                {
                    var part = parts[i];

                    if (part.Contains(":"))
                    {
                        var arg = part.Split(Seperators.Colon);

                        var k = arg[0];
                        var v = arg[1];

                        switch (k)
                        {
                            case "anchor"     : anchor = CropAnchorHelper.Parse(v); break;
                            default           : throw new Exception("Unknown resize argument:" + k);
                        }
                    }
                    else
                    {
                        flags = ResizeFlagsHelper.Parse(part);
                    }
                }

                return new ResizeProcessor(width, height, anchor, flags);
            }

            else if (segment.Contains("-"))
            {
                // {width}x{height}-{anchor}

                var parts = segment.Split(Seperators.Dash);

                return new ResizeProcessor(
                    size   : SizeHelper.Parse(parts[0]),
                    anchor : CropAnchorHelper.Parse(parts[1])
                );
            }

            // 100x100
            return new ResizeProcessor(SizeHelper.Parse(segment));
        }

        public static ResizeProcessor operator * (ResizeProcessor left, double scale)
        {
            return new ResizeProcessor(
                width       : (int)(left.Width * scale),
                height      : (int)(left.Height * scale),
                anchor      : left.Anchor,
                flags       : left.Flags
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
