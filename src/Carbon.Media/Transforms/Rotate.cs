namespace Carbon.Media
{
    public class Rotate : ITransform
    {
        private readonly int angle;

        public Rotate(int angle)
        {
            #region Preconditions

            /*
			if (!angle.InRange(0, 360))
				throw new ArgumentOutOfRangeException("Angle must be between 0 and 360. Was {0}".FormatWith(angle));
			*/

            #endregion

            this.angle = angle;
        }

        public int Angle => angle;

        public override string ToString() => "rotate(" + angle + ")";

        public static Rotate Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("rotate("))
            {
                key = key.Remove(0, 7).TrimEnd(')');
            }

            #endregion

            var angle = int.Parse(key);

            return new Rotate(angle);
        }
    }
}