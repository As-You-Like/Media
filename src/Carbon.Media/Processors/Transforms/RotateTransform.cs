namespace Carbon.Media.Processors
{
    public sealed class RotateTransform : IProcessor
    {
        public RotateTransform(int angle)
        {
            #region Preconditions

            /*
			if (!angle.InRange(0, 360))
				throw new ArgumentOutOfRangeException($"Angle must be between 0 and 360. Was {angle}");
			*/

            #endregion

            Angle = angle;
        }

        public int Angle { get; }

        public string Canonicalize() => $"rotate({Angle}deg)";

        public override string ToString() => $"rotate({Angle})";

        public static RotateTransform Create(CallSyntax syntax)
        {
            return new RotateTransform(angle: int.Parse(syntax.Arguments[0].Value.Replace("deg", "")));
        }
    }
}