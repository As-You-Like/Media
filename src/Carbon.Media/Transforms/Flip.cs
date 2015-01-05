namespace Carbon.Media
{
	using System;

	public class Flip : ITransform
	{
		public static readonly Flip Horizontally = new Flip(FlipAxis.X);
		public static readonly Flip Vertically	 = new Flip(FlipAxis.Y);

		private readonly FlipAxis axis;

		public Flip(FlipAxis axis)
		{
			this.axis = axis;
		}

		public FlipAxis Angle 
		{
			get { return axis; }
		}

		public override string ToString()
		{
			return "flip(" + axis.ToString().ToLower() + ")";
		}

		public static Flip Parse(string key)
		{
			#region Normalization

			if (key.StartsWith("flip(")) {
				key = key.Remove(0, 5).TrimEnd(')');
			}

			#endregion

			var axis = key;

			return new Flip(axis.ToEnum<FlipAxis>(true));
		}
	}

	public enum FlipAxis
	{
		X,	// Horizontally
		Y	// Veritical
	}
}