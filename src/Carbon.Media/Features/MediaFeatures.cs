namespace Carbon.Media
{
	using System;

	[Flags]
	public enum MediaFeatures : byte
	{
		Unknown = 0,
		None = 1,
		AlphaChannel = 2,
		Animated = 4,				// Motion? [Audio]
		ColorProfile = 8,
		EightBit = 16
	}
}