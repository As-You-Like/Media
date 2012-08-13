namespace Carbon.Media
{
	using System;

	public static class AlignmentExtensions
	{
		public static string ToAbbreviation(this Alignment alignment)
		{
			switch (alignment) {
				case Alignment.Bottom:		return "b";
				case Alignment.BottomLeft:	return "bl";
				case Alignment.BottomRight:	return "br";
				case Alignment.Center:		return "c";
				case Alignment.Left:		return "l";
				case Alignment.Right:		return "r";
				case Alignment.Top:			return "t";
				case Alignment.TopLeft:		return "tl";
				case Alignment.TopRight:	return "tr";

				default: throw new ArgumentException(string.Format("Invalid alignment. Was '{0}'", alignment));
			}
		}
	}
}