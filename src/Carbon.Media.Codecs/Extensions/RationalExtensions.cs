using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public static class RationalExtensions
    {
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