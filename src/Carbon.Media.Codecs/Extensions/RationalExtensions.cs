using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public static class RationalExtensions
    {
        public static bool IsUnknown(this AVRational rational)
        {
            // 0/1 for unknown

            return rational.num == 0 && rational.den == 1;
        }

        public static AVRational ToAVRational(this Rational? rational)
        {
            if (rational == null)
            {
                return new AVRational { num = 0, den = 1 };
            }

            return ToAVRational(rational.Value);
        }

        public static AVRational ToAVRational(this Rational rational)
        {
            return new AVRational {
                num = (int)rational.Numerator,
                den = (int)rational.Denominator
            };
        }

        public static Rational ToRational(this AVRational rational)
        {
            return new Rational(rational.num, rational.den);
        }
    }
}