using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class FrameFilter : IProcessor, ICanonicalizable
    {
        public static readonly FrameFilter Poster = new FrameFilter(0);

        public FrameFilter(int number)
        {
            if (number < 0)
            {
                ExceptionHelper.MustBeGreaterThanOrEqualToZero(nameof(number), number);
            }

            Number = number;
        }

        public int Number { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            if (Number == 0)
            {
                sb.Append("poster");
            }
            else
            {
                sb.Append("frame(");

                if (Number == 0)
                {
                    sb.Append("poster");
                }
                else
                {
                    sb.Append(Number);
                }

                sb.Append(')');
            }
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static FrameFilter Create(in CallSyntax syntax)
        {
            return new FrameFilter(int.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}

// frame(1)
// 00:00
