namespace Carbon.Media.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class ImageRendentionTests
	{
		[Test]
		public void ScaleTest()
		{
			var rendition = new MediaRenditionInfo(85, 20, "http://google.com/1045645/100x100/crop:0-0_85x20.png");

			var b = rendition.Scale(2f);

			Assert.AreEqual("http://google.com/1045645/200x200/crop:0-0_170x40.png", b.Url);
		}

		[Test]
		public void ResampleTest()
		{

			var rendition = new MediaRenditionInfo(85, 20, "http://google.com/1045645/100x100/crop:0-0_85x20.png");

			var b = rendition.Scale(2).Resample("abc");

			Assert.AreEqual("http://google.com/1045645/200x200/crop:0-0_170x40/resample(abc).png", b.Url);

		}

		[Test]
		public void WithFormatTests()
		{

			var rendition = new MediaRenditionInfo(85, 20, "http://google.com/1045645/100x100/crop:0-0_85x20.png");

			var b = rendition.Scale(2).Resample("abc").WithFormat("jpeg");

			Assert.AreEqual("http://google.com/1045645/200x200/crop:0-0_170x40/resample(abc).jpeg", b.Url);

		}

		[Test]
		public void ResizedJpegUriIsCorrect()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg").Resize(85, 20);

			Assert.AreEqual("1045645/85x20.jpeg", rendition.GetPath());
		}

		[Test]
		public void OrientedPhotoHasCorrectThings()
		{
			var rendition = new MediaTransformation(new MediaInfo(1, 100, 50), MediaOrientation.Rotate90, "jpeg");

			Assert.AreEqual(50, rendition.Width);
			Assert.AreEqual(100, rendition.Height);

			Assert.AreEqual("rotate(90)", rendition.GetTransforms()[0].ToString());

			Assert.AreEqual("1/rotate(90).jpeg", rendition.GetPath());
		}

		[Test]
		public void RotatedSizeIsCorrect()
		{
			var rendition = new MediaTransformation(new MediaInfo(1, 100, 50), "jpeg").Rotate(90);

			Assert.AreEqual(50, rendition.Width);
			Assert.AreEqual(100, rendition.Height);

			Assert.AreEqual("1/rotate(90).jpeg", rendition.GetPath());
		}

		[Test]
		public void ResizeJpeg()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg").Resize(85, 20);

			Assert.AreEqual("85x20.jpeg", rendition.GetFullName());
			Assert.AreEqual("1045645/85x20.jpeg", rendition.GetPath());

			var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("jpeg", rendition2.Format);
			Assert.AreEqual(1, rendition2.GetTransforms().Count);
			Assert.AreEqual("85x20", rendition2.GetTransforms()[0].ToString());
		}

		[Test]
		public void CropPng()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "png")
				.Resize(100, 100)
				.Crop(0, 0, 85, 20);

			Assert.AreEqual("100x100/crop:0-0_85x20.png", rendition.GetFullName());
			Assert.AreEqual("1045645/100x100/crop:0-0_85x20.png", rendition.GetPath());

			var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

			Assert.AreEqual(1045645, rendition2.Source.Id);
			Assert.AreEqual("png", rendition2.Format);
			Assert.AreEqual(2, rendition2.GetTransforms().Count);
			Assert.AreEqual("100x100", rendition2.GetTransforms()[0].ToString());
			Assert.AreEqual("crop:0-0_85x20", rendition2.GetTransforms()[1].ToString());
		}

		[Test]
		public void CenterAnchoredResizePng()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "png")
				.Transform(new AnchoredResize(100, 50, Alignment.Center));


			Assert.AreEqual(100, rendition.Width);
			Assert.AreEqual(50, rendition.Height);

			Assert.AreEqual("100x50-c.png", rendition.GetFullName());
		}

		[Test]
		public void ResizeAndRotated90()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "jpeg")
				.Resize(50, 50)
				.Crop(0, 0, 85, 20)
				.Rotate(90);

			Assert.AreEqual("50x50/crop:0-0_85x20/rotate(90).jpeg", rendition.GetFullName());

			var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

			Assert.AreEqual(20, rendition.Width);
			Assert.AreEqual(85, rendition.Height);

			Assert.AreEqual(3, rendition2.GetTransforms().Count);

			Assert.AreEqual(90, ((Rotate)rendition2.GetTransforms()[2]).Angle);
		}

		[Test]
		public void LeftAnchoredResizeAndRotate90()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645), "jpeg")
				.Transform(new AnchoredResize(150, 50, Alignment.Left))
				.Rotate(90);

			Assert.AreEqual("150x50-l/rotate(90).jpeg", transformation.GetFullName());
		}

		[Test]
		public void LeftAnchoredResizeAndRotatationTiff()
		{
			var rendition = new MediaTransformation(new MediaInfo(1045645), "tiff")
				.Transform(new AnchoredResize(50, 50, Alignment.Left))
				.Rotate(180);

			Assert.AreEqual("50x50-l/rotate(180).tiff", rendition.GetFullName());
		}

		[Test]
		public void AnchoredResizeHasValidFileName()
		{
			var rendition = new MediaTransformation(new MediaInfo(100), "jpeg").Transform(new AnchoredResize(100, 100, Alignment.Center));
			Assert.AreEqual(@"100x100-c.jpeg", rendition.GetFullName());

			rendition = new MediaTransformation(new MediaInfo(254565), "jpeg")
				.Transform(new AnchoredResize(500, 100, Alignment.Center));

			Assert.AreEqual(@"500x100-c.jpeg", rendition.GetFullName());
		}

		[Test]
		public void Filters()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645, 100, 50), "jpeg")
				.Transform(new ApplyFilter("contrast", "2"))
				.Transform(new ApplyFilter("grayscale", "1"))
				.Transform(new ApplyFilter("sepia", "1"));


			Assert.AreEqual(100, transformation.Width);
			Assert.AreEqual(50, transformation.Height);


			Assert.AreEqual("contrast(2)/grayscale(1)/sepia(1).jpeg", transformation.GetFullName());

			var rendition2 = MediaTransformation.ParsePath(transformation.GetPath());
			Assert.AreEqual(3, rendition2.GetTransforms().Count);

			Assert.AreEqual("contrast", ((ApplyFilter)rendition2.GetTransforms()[0]).Name);
			Assert.AreEqual("grayscale", ((ApplyFilter)rendition2.GetTransforms()[1]).Name);
			Assert.AreEqual("sepia", ((ApplyFilter)rendition2.GetTransforms()[2]).Name);
		}

		[Test]
		public void BuilderTests()
		{
			var transformation = new MediaTransformation(new MediaInfo(1045645, 50, 50), "jpeg")
				.Resize(100, 100)
				.Rotate(90)
				.ApplyFilter("sepia", 1);

			Assert.AreEqual(100, transformation.Width);
			Assert.AreEqual(100, transformation.Height);
			
			Assert.AreEqual("100x100/rotate(90)/sepia(1).jpeg", transformation.GetFullName());
		}
	}

	public class MediaInfo : IMediaInfo
	{
		private readonly int id;
		private readonly int width;
		private readonly int height;

		public MediaInfo(int id, int width = 0, int height = 0)
		{
			this.id = id;
			this.width = width;
			this.height = height;
		}

		public int Id
		{
			get { return id; }
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public string Format { get; set; }

		public Uri Url { get; set; }
	}
}