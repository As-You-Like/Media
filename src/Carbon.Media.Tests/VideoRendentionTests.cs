namespace Carbon.Media.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	// [TestFixture]
	public class VideoendentionTests
	{
		// 600x400.mp4	[h264, mp4]

		/*
		[Test]
		public void ResizeMp4()
		{
			var video = new VideoInfo { 
				Id = 1, 
				Width = 1920, 
				Height = 1080,
				Duration = 1.Minute() 
			};

			var rendention = new VideoRendition(video) {
				Transforms = { new Resize(1280, 720) }
			};

			Assert.AreEqual("1280x720.mp4", rendention.GetFileName());
		}

		[Test]
		public void ResizeAndRotateMp4()
		{
			var video = new VideoInfo {
				Id = 1,
				Mime = "video/mp4",
				Width = 1920,
				Height = 1080,
				Duration = 1.Minute()
			};

			var rendention = new VideoRendition(video) {
				Transforms = { new Resize(1280, 720), new Rotate(90) }
			};

			Assert.AreEqual(VideoFormat.Mp4, video.Format);
			Assert.AreEqual("1280x720-r90.mp4", rendention.GetFileName());
		}
		*/
	}
}