namespace Carbon.Media
{
	using System;

	[Flags]
	public enum MediaFeatures
	{
		Unknown			= 0,
		None			= 1 << 0,	// 1
		AlphaChannel	= 1 << 1,	// 2
		Animated		= 1 << 2,	// 4
		ColorProfile	= 1 << 3	// 8
	}
}
