using System;

namespace Carbon.Media.Processing
{
    public class BlurFilter : IFilter
    {
        public BlurFilter(float radius)
        {
            if (radius < 0 || radius > 2000)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "Must be between 0 and 2,000");
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