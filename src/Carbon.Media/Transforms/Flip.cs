namespace Carbon.Media
{
    public sealed class Flip : ITransform
    {
        public static readonly Flip Horizontally = new Flip(FlipAxis.X);
        public static readonly Flip Vertically   = new Flip(FlipAxis.Y);

        public Flip(FlipAxis axis)
        {
            Axis = axis;
        }

        public FlipAxis Axis { get; }

        public override string ToString() 
            => "flip(" + Axis.Lowercased() + ")";

        public static Flip Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("flip("))
            {
                key = key.Remove(0, 5).TrimEnd(')');
            }

            #endregion

            return new Flip(key.ToEnum<FlipAxis>(true));
        }
    }

    internal static class FlipAxisExtensions
    {
        public static string Lowercased(this FlipAxis axis)
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