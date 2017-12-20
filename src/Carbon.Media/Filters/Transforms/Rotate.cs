namespace Carbon.Media.Processors
{
    public sealed class RotateTransform : ITransform
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

        public static RotateTransform Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("rotate("))
            {
                key = key.Substring(7, key.Length - 8);
            }

            #endregion

            return new RotateTransform(angle: int.Parse(key.Replace("deg", "")));
        }
    }
}