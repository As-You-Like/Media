namespace Carbon.Media.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class VideoFormatTests
	{
		[Test]
		public void ParseFromFormat()
		{
			Assert.AreEqual(VideoFormat.Avi, VideoHelper.GetVideoFormatFromFormat("AVI"));
			Assert.AreEqual(VideoFormat.Flv, VideoHelper.GetVideoFormatFromFormat("Flv"));
			Assert.AreEqual(VideoFormat.Mov, VideoHelper.GetVideoFormatFromFormat("MoV"));
			Assert.AreEqual(VideoFormat.Mp4, VideoHelper.GetVideoFormatFromFormat("Mp4"));
			Assert.AreEqual(VideoFormat.Mpeg, VideoHelper.GetVideoFormatFromFormat("MpeG"));
			Assert.AreEqual(VideoFormat.Wmv, VideoHelper.GetVideoFormatFromFormat("wmv"));

			Assert.Throws<ArgumentException>(() => VideoHelper.GetVideoFormatFromFormat("Unknown"));
		}
	}
}