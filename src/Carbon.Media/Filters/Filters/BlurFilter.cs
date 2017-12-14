using System;

namespace Carbon.Media.Processors
{
    public class BlurFilter : IFilter
    {
        // Specified as a length

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

        public static BlurFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);
            
            // allows the px unit

            return new BlurFilter((float)Unit.Parse(segment).Value);
        }
    }
}

// blur(5px) CSS Syntax

// Sigma

// TODO: BoxBlur, GaussianBlur, MotionBlur, ...

// boxblur, gblur, avgblur, sab, smartblur