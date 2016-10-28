using System;

namespace Carbon.Media
{
    public class AnchoredResize : ITransform
    {
        public AnchoredResize(Size size, Alignment anchor)
            : this(size.Width, size.Height, anchor)
        { }

        public AnchoredResize(int width, int height, Alignment anchor)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Must be greater than 0");

            #endregion

            Width = width;
            Height = height;
            Anchor = anchor;
        }

        public int Width { get; }

        public int Height { get; }

        public Size Size => new Size(Width, Height);

        public Alignment Anchor { get; }

        public override string ToString()
        {
            // {width}x{height}-{anchorAbbreviation}

            // 100x100;fit=contain;anchor=center/

            // fit: cover,contain,crop,pad

            return string.Format("{0}x{1}-{2}",
                /*0*/ Width,
                /*1*/ Height,
                /*2*/ Anchor.ToAbbreviation()
            );
        }

        public static AnchoredResize Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("resize:"))
            {
                key = key.Remove(0, 7);
            }

            #endregion

            return new AnchoredResize(
                size   : Size.Parse(key.Split('-')[0]),
                anchor : AlignmentHelper.ParseAlignment(key.Split('-')[1])
            );
        }
    }
}