namespace Carbon.Media.Processing
{
    public class BlurFilter : IFilter
    {
        public BlurFilter(float radius)
        {
            if (radius < 0 || radius > 1_000)
            {
                throw ExceptionHelper.OutOfRange(nameof(radius), 0, 1_000, radius);
            }

            Amount = radius;
        }

        public float Amount { get; }

        // TODO: Algorithm?

        public string Canonicalize() => $"blur({Amount})";

        public override string ToString() => Canonicalize();

        public static BlurFilter Create(in CallSyntax syntax)
        {
            return new BlurFilter((float)Unit.Parse(syntax.Arguments[0].Value.ToString()).Value);
        }
    }
}

// blur(5px) CSS Syntax

// Sigma

// TODO: BoxBlur, GaussianBlur, MotionBlur, ...

// boxblur, gblur, avgblur, sab, smartblur