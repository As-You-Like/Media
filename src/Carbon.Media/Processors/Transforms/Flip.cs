using System;

namespace Carbon.Media.Processors
{
    public sealed class Flip : IProcessor
    {
        public static readonly Flip Horizontally = new Flip(FlipAxis.X);
        public static readonly Flip Vertically   = new Flip(FlipAxis.Y);

        public Flip(FlipAxis axis)
        {
            Axis = axis;
        }

        public FlipAxis Axis { get; }

        // flip(x | y)
        public string Canonicalize() =>
            "flip(" + Axis.ToLower() + ")";
     
        public override string ToString() =>
            Canonicalize();

        public static Flip Parse(string key)
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

    public enum FlipAxis
    {
        X,  // Horizontally
        Y   // Veritical
    }
}