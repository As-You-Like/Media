using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public struct Timestamp
    {
        public Timestamp(long value, Rational timeBase)
        {
            Value    = value;
            TimeBase = timeBase;
        }

        public long Value { get; }

        public Rational TimeBase { get; set; }

        public TimeSpan TimeSpan => TimeSpan.FromTicks(GetTimestamp(Timebases.DotNetTicks));

        public long GetTimestamp(Rational targetTimeBase)
        {
            return ffmpeg.av_rescale_q(
                Value,
                TimeBase.ToAVRational(), 
                targetTimeBase.ToAVRational()
            );
        }
        
        public Timestamp Transform(Rational targetTimeBase)
        {
            return new Timestamp(GetTimestamp(targetTimeBase), targetTimeBase);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}