using System;

namespace Carbon.Media.Processors
{
    public sealed class Clip : IProcessor
    {
        public Clip(TimeSpan start, TimeSpan end)
        {
            #region Preconditions

            if (start < TimeSpan.Zero)
                throw new ArgumentException("Must be Zero or greater", nameof(start));

            if (end <= TimeSpan.Zero)
                throw new ArgumentException("Must be greater than Zero", nameof(start));

            if (end > start)
                throw new ArgumentException("end may not be after the start");


            #endregion

            Start = start;
            End = end;
        }

        public TimeSpan Start { get; }

        public TimeSpan End { get; }

        // clip(0s,30s)

        public string Canonicalize() =>
            $"clip({Start.TotalSeconds}s,{End.TotalSeconds}s)";

        public override string ToString() => Canonicalize();
    }
}