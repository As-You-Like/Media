namespace Carbon.Media
{
	using System;

	[Flags]
	public enum MediaFeatures
	{
		Unknown			= 0,
		None			= 1,
		AlphaChannel	= 2,
		Animated		= 4,
		ColorProfile	= 8
	}
}