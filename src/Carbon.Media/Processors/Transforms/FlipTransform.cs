using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class FlipTransform : IProcessor, ICanonicalizable
    {
        public static readonly FlipTransform Horizontally = new FlipTransform(FlipAxis.X);
        public static readonly FlipTransform Vertically   = new FlipTransform(FlipAxis.Y);

        public FlipTransform(FlipAxis axis)
        {
            Axis = axis;
        }

        public FlipAxis Axis { get; }

        #region ICanonicalizable

        // flip(x | y)
        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("flip(");
            sb.Append(Axis.ToLower());
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static FlipTransform Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("flip("))
            {
                key = key.Remove(0, 5).TrimEnd(')');
            }

            #endregion

            switch (key)
            {
                case "x" : return Horizontally;
                case "y" : return Vertically;
                default  : throw new ArgumentException("Unexpected axis:" + key);
            }
        }
    }

    internal static class FlipAxisExtensions
    {
        public static string ToLower(this FlipAxis axis)
        {
            switch (axis)
            {
                case FlipAxis.X : return "x";
                case FlipAxis.Y : return "y";
                default         : return "unknown";
            }
        }
    }

    public enum FlipAxis : byte
    {
        X = 1, // Horizontally
        Y = 2  // Veritical
    }
}