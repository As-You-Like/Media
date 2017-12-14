using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class Clip : ITransform, ICanonicalizable
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

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        // clip(0s,30s)

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("clip(");

            sb.Append(Start.TotalSeconds);
            sb.Append('s');

            sb.Append(End.TotalSeconds);
            sb.Append('s');
            
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion
    }
}