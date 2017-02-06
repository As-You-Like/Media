using System;

namespace Carbon.Media
{
    public sealed class Clip : IProcessor
    {
        public Clip(TimeSpan start, TimeSpan end)
        {
            #region Preconditions

            if (end > start)
                throw new ArgumentException("end may not be after the start");

            #endregion

            Start = start;
            End = end;
        }

        public TimeSpan Start { get; }

        public TimeSpan End { get; }

        public override string ToString() =>
            $"clip({Start.TotalSeconds},{End.TotalSeconds})";

        // clip(0,30)

    }
}