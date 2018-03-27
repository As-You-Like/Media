using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class ResizeTransform : IProcessor
    {
        const int maxDimension = 16384;

        // 8K = 7,680 x 4,320

        // The maximum pixel dimensions of a WebP image is 16384 x 16384.
        // 16384 * 16384 * 4 = 1GB bitmap

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
            #region Preconditions

            if (width < 0 || width > Constants.MaxWidth)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 16,383");

            if (height < 0 || height > Constants.MaxHeight)
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

            // 100x100-c
            if (segment.Contains("-"))
            {
                // {width}x{height}-{anchor}

                var parts = segment.Split(Seperators.Dash);

                return new ResizeTransform(
                    size   : SizeHelper.Parse(parts[0]),
                    anchor : CropAnchorHelper.Parse(parts[1])
                );
            }
            else if (segment.Contains(","))
            {
                var args = ArgumentList.Parse(segment);

                Unit width = default;
                Unit height = default;
                ResizeFlags flags = default;
                CropAnchor? anchor = null;

                for (var i = 0; i < args.Length; i++)
                {
                    var (key, value) = args[i];

                    if (i == 0 && value.IndexOfAny(x_x) > -1)
                    {
                        var size = value.Split(x_x);

                        width  = Unit.Parse(size[0]);
                        height = Unit.Parse(size[1]);

                        continue;
                    }

                    if (i == 0 && width == default)
                    {
                        width = Unit.Parse(value);
                    }
                    else if (i == 1 && height == default)
                    {
                        height = Unit.Parse(value);
                    }
                    else
                    {
                        switch (key)
                        {
                            case "anchor" : anchor = CropAnchorHelper.Parse(value); break;
                            case null     : flags = ResizeFlagsHelper.Parse(value); break;
                            default       : throw new Exception("Invalid resize argument:" + key);
                        }
                    }
                }

                return new ResizeTransform(width, height, anchor, flags);
            }
            else
            {
                var size = segment.Split(x_x);
                
                // 100x100
                return new ResizeTransform(
                    width  : Unit.Parse(size[0]), 
                    height : Unit.Parse(size[1])
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
