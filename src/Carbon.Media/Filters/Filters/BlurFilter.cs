namespace Carbon.Media.Processors
{
    public class BlurFilter : IFilter
    {
        public BlurFilter(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"blur({Amount})";

        public override string ToString() => Canonicalize();

        public static BlurFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            // allow px unit

            if (segment.EndsWith("px"))
            {
                segment = segment.Replace("px", "");
            }

            return new BlurFilter(float.Parse(segment));
        }
    }
}

// blur(5px) CSS Syntax

// Sigma

// TODO: BoxBlur, GaussianBlur, MotionBlur, ...

// boxblur, gblur, avgblur, sab, smartblur