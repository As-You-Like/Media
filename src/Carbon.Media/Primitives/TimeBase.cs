using System;

namespace Carbon.Media
{
    public readonly struct TimeBase : IEquatable<TimeBase>
    {
        private readonly long numerator;
        private readonly long denominator;

        public TimeBase(long numerator, long denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("denominator may not be 0");

            this.numerator = numerator;
            this.denominator = denominator;
        }


        public long Numerator => numerator;

        public long Denominator => denominator;

        public static TimeBase Parse(string text)
        {
            var rational = Rational.Parse(text);

            return new TimeBase(rational.Numerator, rational.Denominator);
        }

        public override string ToString() => numerator + "/" + denominator;

        // https://en.wikipedia.org/wiki/Flick_(time)
        // A flick is a unit of time equivalent to exactly 1/705,600,000 of a second.

        public static readonly TimeBase Flick = new TimeBase(1, 705600000);

        public static readonly TimeBase Ffmpeg = new TimeBase(1, 1_000_000); // AV_TIME_BASE

        public static readonly TimeBase DotNetTick = new TimeBase(1, TimeSpan.TicksPerSecond); // AV_TIME_BASE


        // timebase: 1/30

        public TimeSpan ToTime(long timestamp)
        {
            var ticks = RescaleTimestamp(DotNetTick, timestamp);

            return TimeSpan.FromTicks(ticks);

            /*
            var value = (double)timestamp / (numerator * denominator);

            return TimeSpan.FromSeconds(value);
            */
        }

        public long ToTimeStamp(TimeSpan time)
        {
            double value = ((denominator / (double)TimeSpan.TicksPerSecond) * time.Ticks) / numerator;

            return (long)Math.Round(value);
        }

        public long RescaleTimestamp(TimeBase targetTimeBase, long timestamp)
        {
            double value = (((targetTimeBase.Denominator * numerator) / (double)denominator) * timestamp) / (double)targetTimeBase.Numerator;

            return (long)Math.Round(value);
        }

        public long ToFlicks(long timestamp)
        {
            return ((705600000 * numerator) / denominator) * timestamp;
        }

        public bool Equals(TimeBase other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public static explicit operator TimeBase(Rational v)
        {
            return new TimeBase(v.Numerator, v.Denominator);
        }
    }
}

// The unit of time (in seconds) in which frame timestamps are represented