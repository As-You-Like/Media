using System;

namespace Carbon.Media
{
    public class AnchoredResize : ITransform
    {
        private readonly int width;
        private readonly int height;
        private readonly Alignment anchor;

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

            this.width = width;
            this.height = height;
            this.anchor = anchor;
        }

        public int Width => width;

        public int Height => height;

        public Size Size => new Size(width, height);

        public Alignment Anchor => anchor;

        public override string ToString()
        {
            // {width}x{height}-{anchorAbbreviation}

            // 100x100;fit=contain;anchor=center/

            // fit: cover,contain,crop,pad

            return string.Format("{0}x{1}-{2}",
                /*0*/ width,
                /*1*/ height,
                /*2*/ anchor.ToAbbreviation()
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