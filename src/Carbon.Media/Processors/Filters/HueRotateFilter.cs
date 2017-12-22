namespace Carbon.Media.Processors
{
    public class HueRotateFilter : IFilter
    {
        public HueRotateFilter(int degrees)
        {
            Degrees = degrees;
        }

        public int Degrees { get; }

        // hue-rotate(90deg)
      
        public static HueRotateFilter Create(CallSyntax syntax)
        {            
            return new HueRotateFilter(int.Parse(syntax.Arguments[0].Value.Replace("deg", "")));
        }

        #region ToString()

        public string Canonicalize() => $"hueRotate({Degrees}deg)";

        public override string ToString() => $"hueRotate({Degrees}deg)";

        #endregion
    }
}

// hue-rotate(328deg)