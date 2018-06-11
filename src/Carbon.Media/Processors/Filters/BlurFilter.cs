using System;

namespace Carbon.Media.Processors
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

        public string Canonicalize() => $"blur({Amount})";

        public override string ToString() => Canonicalize();

        public static BlurFilter Create(in CallSyntax syntax)
        {
            return new BlurFilter((float)Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}

// blur(5px) CSS Syntax

// Sigma

// TODO: BoxBlur, GaussianBlur, MotionBlur, ...

// boxblur, gblur, avgblur, sab, smartblur