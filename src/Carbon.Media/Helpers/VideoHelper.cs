namespace Carbon.Media
{
	using System;
	using System.Collections.Generic;

	using Carbon.Helpers;

	public static class VideoHelper
	{
		public static VideoFormat GetVideoFormatFromFormat(string format)
		{
			VideoFormat videoFormat;

			if(!Enum.TryParse<VideoFormat>(format, ignoreCase: true, result: out videoFormat))
			{
				throw new ArgumentException("Unsupported format: " + format, paramName: "format");
			}

			return videoFormat;
		}
	}
}