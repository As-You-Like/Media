using System;
using System.Text;

namespace Carbon.Media
{
    public sealed class Scale : IProcessor
    {
        public Scale(int width, int height, InterpolaterMode mode)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "Must be greater than 0");

            #endregion

            Width = width;
            Height = height;
            Mode = mode;
        }

        public int Width { get; }

        public int Height { get; }

        public InterpolaterMode Mode { get; }

        public Size Size => new Size(Width, Height);

        // scale(100,100,lanczos3)
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("scale(");

            sb.Append(Width);
            sb.Append(",");
            sb.Append(Height);

            if (Mode != default(InterpolaterMode))
            {
                sb.Append(",");
                sb.Append(Mode.ToLower());
            }

            sb.Append(")");

            return sb.ToString();
        }

        public override string ToString() =>
            Canonicalize();

        public static Scale Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;
            
            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            #endregion
  
            var parts = segment.Split(Seperators.Comma);


            int width = 0;
            int height = 0;
            var mode = InterpolaterMode.Box;

            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];

                switch (i)
                {
                    case 0: width = int.Parse(part); break;
                    case 1: height = int.Parse(part); break;
                    case 2: mode = InterpolaterHelper.Parse(part); break;
                }
            }

            return new Scale(width, height, mode);
        }
    }
}