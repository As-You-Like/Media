namespace Carbon.Media
{
    public sealed class Rotate : IProcessor
    {
        public Rotate(int angle)
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

        public static Rotate Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("rotate("))
            {
                key = key.Remove(0, 7).TrimEnd(')');
            }

            #endregion

            return new Rotate(angle: int.Parse(key));
        }
    }
}