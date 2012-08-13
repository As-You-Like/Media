namespace Carbon.Media.Tests
{
	using System;
	using System.Drawing.Imaging;

	using NUnit.Framework;

	[TestFixture]
	public class ImageRendentionTests
	{
		[Test]
		public void ResizedJpegUriIsCorrect()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg") { 
				BaseMediaPath = "http://m.cmcdn.net",
				Transforms = { new Resize(85, 20) }
			};

			Assert.AreEqual("http://m.cmcdn.net/1045645/85x20.jpeg", rendition.Url);
			Assert.AreEqual(rendition.Url, rendition.Url.ToString());
		}

		[Test]
		public void ResizeJpeg()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { new Resize(85, 20) }
			};

			Assert.AreEqual("85x20.jpeg", rendition.GetFullName());
			Assert.AreEqual("1045645/85x20.jpeg", rendition.GetUrlPath());

			var rendition2 = MediaTransformation.ParseUrlPath(rendition.GetUrlPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("jpeg", rendition2.Format);
			Assert.AreEqual(1, rendition2.Transforms.Count);
			Assert.AreEqual("85x20", rendition2.Transforms[0].ToKey());
		}

		[Test]
		public void CropPng()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "png") {
				Transforms = { new Resize(100, 100), new Crop(0, 0, 85, 20) }	
			};

			Assert.AreEqual("100x100/crop:0-0_85x20.png", rendition.GetFullName());
			Assert.AreEqual("1045645/100x100/crop:0-0_85x20.png", rendition.GetUrlPath());

			var rendition2 = MediaTransformation.ParseUrlPath(rendition.GetUrlPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("png", rendition2.Format);
			Assert.AreEqual(2, rendition2.Transforms.Count);
			Assert.AreEqual("100x100", rendition2.Transforms[0].ToKey());
			Assert.AreEqual("crop:0-0_85x20", rendition2.Transforms[1].ToKey());
		}

		[Test]
		public void CenterAnchoredResizePng()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "png") {
				Transforms = { new AnchoredResize(100, 50, Alignment.Center) }
			};

			Assert.AreEqual("100x50-c.png", rendition.GetFullName());
		}

		[Test]
		public void ResizeAndRotated90()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { 
					new Resize(50, 50), 
					new Crop(0, 0, 85, 20),
					new Rotate(90)
				}
			};

			Assert.AreEqual("50x50/crop:0-0_85x20/rotate:90.jpeg", rendition.GetFullName());
		}

		[Test]
		public void LeftAnchoredResizeAndRotate90()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { 
					new AnchoredResize(150, 50, Alignment.Left),
					new Rotate(90)
				}
			};

			Assert.AreEqual("150x50-l/rotate:90.jpeg", rendition.GetFullName());
		}

		[Test]
		public void LeftAnchoredResizeAndRotatationTiff()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "tiff") {
				Transforms = {
					new AnchoredResize(50, 50, Alignment.Left),
					new Rotate(180)
				}
			};

			Assert.AreEqual("50x50-l/rotate:180.tiff", rendition.GetFullName());
		}

		[Test]
		public void AnchoredResizeHasValidFileName()
		{
			var rendition = new MediaTransformation(new MediaInfo(100), "jpeg") {
				Transforms = { new AnchoredResize(100, 100, Alignment.Center) }
			};

			Assert.AreEqual(@"100x100-c.jpeg", rendition.GetFullName());

			rendition = new MediaTransformation(new MediaInfo(254565), "jpeg") {
				Transforms = { new AnchoredResize(500, 100, Alignment.Center) }
			};

			Assert.AreEqual(@"500x100-c.jpeg", rendition.GetFullName());
		}
	}

	public class MediaInfo : IMediaInfo
	{
		public MediaInfo(int id)
		{
			this.Id = id;
		}

		public int Id { get; set; }

		public int Height { get; set; }

		public int Width { get; set; }

		public Mime Type { get; set; }

		public Uri Url { get; set; }
	}
}