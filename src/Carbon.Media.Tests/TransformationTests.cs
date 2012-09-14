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
			var transformation = new MediaTransformation(new MediaInfo(1045645), "jpeg") { 
				BaseUri = new Uri("http://m.cmcdn.net/"),
				Transforms = { new Resize(85, 20) }
			};

			Assert.AreEqual(new Uri("http://m.cmcdn.net/1045645/85x20.jpeg"), transformation.Url);
			Assert.AreEqual(transformation.Url, transformation.Url.ToString());
		}

		[Test]
		public void ResizeJpeg()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { new Resize(85, 20) }
			};

			Assert.AreEqual("85x20.jpeg", rendition.GetFullName());
			Assert.AreEqual("1045645/85x20.jpeg", rendition.GetPath());

			var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("jpeg", rendition2.Format);
			Assert.AreEqual(1, rendition2.Transforms.Count);
			Assert.AreEqual("85x20", rendition2.Transforms[0].ToString());
		}

		[Test]
		public void CropPng()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645), "png") {
				Transforms = { new Resize(100, 100), new Crop(0, 0, 85, 20) }	
			};

			Assert.AreEqual("100x100/crop:0-0_85x20.png", transformation.GetFullName());
			Assert.AreEqual("1045645/100x100/crop:0-0_85x20.png", transformation.GetPath());

			var rendition2 = MediaTransformation.ParsePath(transformation.GetPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("png", rendition2.Format);
			Assert.AreEqual(2, rendition2.Transforms.Count);
			Assert.AreEqual("100x100", rendition2.Transforms[0].ToString());
			Assert.AreEqual("crop:0-0_85x20", rendition2.Transforms[1].ToString());
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

			Assert.AreEqual("50x50/crop:0-0_85x20/rotate(90).jpeg", rendition.GetFullName());

			var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

			Assert.AreEqual(3, rendition2.Transforms.Count);

			Assert.AreEqual(90, ((Rotate)rendition2.Transforms[2]).Angle);
		}

		[Test]
		public void LeftAnchoredResizeAndRotate90()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { 
					new AnchoredResize(150, 50, Alignment.Left),
					new Rotate(90)
				}
			};

			Assert.AreEqual("150x50-l/rotate(90).jpeg", transformation.GetFullName());
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

			Assert.AreEqual("50x50-l/rotate(180).tiff", rendition.GetFullName());
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

		[Test]
		public void Filters()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645), "jpeg") {
				Transforms = { 
					new ApplyFilter("contrast", "2"), 
					new ApplyFilter("grayscale", "1"),
					new ApplyFilter("sepia", "1")
				}
			};

			Assert.AreEqual("contrast(2)/grayscale(1)/sepia(1).jpeg", transformation.GetFullName());

			var rendition2 = MediaTransformation.ParsePath(transformation.GetPath());

			Assert.AreEqual(3, rendition2.Transforms.Count);

			Assert.AreEqual("contrast", ((ApplyFilter)rendition2.Transforms[0]).Name);
			Assert.AreEqual("grayscale", ((ApplyFilter)rendition2.Transforms[1]).Name);
			Assert.AreEqual("sepia", ((ApplyFilter)rendition2.Transforms[2]).Name);
		}

		[Test]
		public void BuilderTests()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645), "jpeg")
				.Resize(100, 100)
				.Rotate(90)
				.ApplyFilter("sepia", 1);


			Assert.AreEqual("100x100/rotate(90)/sepia(1).jpeg", transformation.GetFullName());
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

		public string Format { get; set; }

		public Uri Url { get; set; }
	}
}