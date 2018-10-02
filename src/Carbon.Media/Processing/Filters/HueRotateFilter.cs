namespace Carbon.Media.Processing
{
    public class HueRotateFilter : IFilter
    {
        public HueRotateFilter(int degrees)
        {
            Degrees = degrees;
        }

        public int Degrees { get; }

        // hue-rotate(90deg)

        public static HueRotateFilter Create(in CallSyntax syntax)
        {
            return new HueRotateFilter((int)Unit.Parse(syntax.Arguments[0].Value.ToString()).Value);
        }

        #region ToString()

        public string Canonicalize() => $"hueRotate({Degrees}deg)";

        public override string ToString() => $"hueRotate({Degrees}deg)";

        #endregion
    }
}

// hue-rotate(328deg)