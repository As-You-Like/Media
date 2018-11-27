using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class ScaleTransform : IProcessor, ICanonicalizable
    {
        public ScaleTransform(Size size, InterpolaterMode mode)
            : this(size.Width, size.Height, mode) { }

        public ScaleTransform(int width, int height, InterpolaterMode mode)
        {
            if (width < 0 || width > Constants.MaxWidth)
            {
                ExceptionHelper.OutOfRange(nameof(width), 0, Constants.MaxWidth, width);
            }

            if (height < 0 || height > Constants.MaxHeight)
            {
                ExceptionHelper.OutOfRange(nameof(height), 0, Constants.MaxHeight, height);
            }

            Width = width;
            Height = height;
            Mode   = mode;
        }

        public int Width { get; }

        public int Height { get; }

        public InterpolaterMode Mode { get; }

        [IgnoreDataMember]
        public Size Size => new Size(Width, Height);

        #region ICanonicalizable

        // scale(100,100,lanczos3)
        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("scale(");

            sb.Append(Width);
            sb.Append(',');
            sb.Append(Height);

            if (Mode != default)
            {
                sb.Append(',');
                sb.Append(Mode.ToLower());
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static ScaleTransform Create(in CallSyntax syntax)
        {
            int width = 0;
            int height = 0;
            var mode = InterpolaterMode.Box;

            var i = 0;

            foreach (var (key, value) in syntax.Arguments)
            {
                switch (i)
                {
                    case 0: width  = int.Parse(value); break;
                    case 1: height = int.Parse(value); break;
                    case 2: mode   = InterpolaterHelper.Parse(value); break;
                }

                i++;
            }

            return new ScaleTransform(width, height, mode);
        }
    }
}