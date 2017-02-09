using System;

using Xunit;

namespace Carbon.Media.Tests
{
    public sealed class Signer : ISigner
    {
        private readonly string name;

        public Signer(string name)
        {
            this.name = name;
        }

        public string Sign(string path)
        {
            return name;
        }
    }

    public class ImageRendentionTests
    {
        private static readonly MediaSource jpeg_50x50 = new MediaSource("1045645", 100, 50);
        private static readonly MediaSource jpeg_85x20 = new MediaSource("a", 85, 20);

        [Fact]
        public void ResizePercent()
        {

            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("300％"), Unit.Parse("200％"));

            Assert.Equal(85 * 3, rendition.Width);
            Assert.Equal(20 * 2, rendition.Height);
        }

        [Fact]
        public void ResizeAuto()
        {
            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("_"), Unit.Parse("40"));

            Assert.Equal(170, rendition.Width);
            Assert.Equal(40, rendition.Height);

            rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("170px"), Unit.Parse("_"));

            Assert.Equal(170, rendition.Width);
            Assert.Equal(40, rendition.Height);
        }

        [Fact]
        public void DrawTextTests()
        {
            var transformation = MediaTransformation.ParsePath("1045645/text(Hello World,font:14px Helvetica)/100x100.jpeg");

            var text = (DrawText)transformation.GetTransforms()[0];

            Assert.Equal("Hello World", text.Text);
            Assert.Equal(14, text.Font?.Size.Value);
            Assert.Equal(UnitType.Px, text.Font?.Size.Type);
            Assert.Equal("Helvetica", text.Font?.Name);
        }

        [Fact]
        public void ClipTest1()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/1:00/100x100.jpeg");

            var transform = rendition.TransformString[0];

            Assert.Equal("1:00/100x100.jpeg", rendition.TransformString);

            // 1045645/1:00/100x100.jpeg
            var transformation = MediaTransformation.ParsePath("1045645/00:01:00/100x100.jpeg");

            var clip = (Clip)transformation.GetTransforms()[0];

            Assert.Equal(TimeSpan.FromSeconds(60), clip.Start);
            Assert.Equal(TimeSpan.FromSeconds(60), clip.End);
        }

        [Fact]
        public void ScaleTest2()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/100x100/crop(0,0,85,20).png");

            var b = rendition.Scale(2f);

            Assert.Equal("200x200/crop(0,0,170,40).png", b.TransformString);

            var c = b.Scale(2f);

            Assert.Equal("400x400/crop(0,0,340,80).png", c.TransformString);

            var d = c.WithFormat("gif");

            Assert.Equal("400x400/crop(0,0,340,80).gif", d.TransformString);
        }

        [Fact]
        public void ScaleTest()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/100x100/crop(0,0,85,20).png");

            var b = rendition.Scale(2f);

            Assert.Equal("https://google.com/1045645/200x200/crop(0,0,170,40).png", b.Url);
        }

        [Fact]
        public void ResampleTest()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/100x100/crop:0-0_85x20.png");

            var b = rendition.Scale(2).Resample("abc");

            Assert.Equal("https://google.com/1045645/200x200/crop(0,0,170,40)/resample(abc).png", b.Url);

        }

        [Fact]
        public void ResampleTest2()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/100x100/crop:0-0_85x20.png");

            var b = rendition.Scale(2).Resample("abc");

            MediaRenditionInfo.Signer = new Signer("hey");

            Assert.Equal("https://google.com/hey/1045645/200x200/crop(0,0,170,40)/resample(abc).png", b.Url);

            MediaRenditionInfo.Signer = null;
        }

        [Fact]
        public void WithFormatTests()
        {
            MediaRenditionInfo.Host = "google.com";

            var rendition = new MediaRenditionInfo(85, 20, "1045645/100x100/crop(0,0,85,20).png");

            var b = rendition.Scale(2).Resample("abc").WithFormat("jpeg");

            Assert.Equal("https://google.com/1045645/200x200/crop(0,0,170,40)/resample(abc).jpeg", b.Url);
        }

        [Fact]
        public void ResizedJpegUriIsCorrect()
        {
            var rendition = new MediaTransformation(new MediaSource("64a5e3944d4f11c05cde1a60efa9b86e9c4c6e54f3cb17269454472fdfa88d89"), "jpeg").Resize(85, 20);

            Assert.Equal("64a5e3944d4f11c05cde1a60efa9b86e9c4c6e54f3cb17269454472fdfa88d89/85x20.jpeg", rendition.GetPath());
        }

        [Fact]
        public void OrientedPhotoHasCorrectThings()
        {
            var rendition = new MediaTransformation(new MediaSource("1", 100, 50), MediaOrientation.Rotate90, "jpeg");

            Assert.Equal(50, rendition.Width);
            Assert.Equal(100, rendition.Height);

            Assert.Equal("rotate(90)", rendition.GetTransforms()[0].ToString());

            Assert.Equal("1/rotate(90).jpeg", rendition.GetPath());
        }

        [Fact]
        public void RotatedSizeIsCorrect()
        {
            var rendition = new MediaTransformation(new MediaSource("1", 100, 50), "jpeg").Rotate(90);

            Assert.Equal(50, rendition.Width);
            Assert.Equal(100, rendition.Height);

            Assert.Equal("1/rotate(90).jpeg", rendition.GetPath());
        }

        [Fact]
        public void ResizeJpeg()
        {
            var rendition = new MediaTransformation(new MediaSource("64a5e3944d4f11c05cde1a60efa9b86e9c4c6e54f3cb17269454472fdfa88d89"), "jpeg").Resize(85, 20);

            Assert.Equal("85x20.jpeg", rendition.GetFullName());
            Assert.Equal("64a5e3944d4f11c05cde1a60efa9b86e9c4c6e54f3cb17269454472fdfa88d89/85x20.jpeg", rendition.GetPath());

            var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

            Assert.Equal("jpeg", rendition2.Format);
            Assert.Equal(1, rendition2.GetTransforms().Count);
            Assert.Equal("85x20", rendition2.GetTransforms()[0].ToString());
        }

        [Fact]
        public void CropPng()
        {
            var rendition = new MediaTransformation(new MediaSource("1045645"), "png")
                .Resize(100, 100)
                .Crop(0, 0, 85, 20);

            Assert.Equal("100x100/crop(0,0,85,20).png", rendition.GetFullName());
            Assert.Equal("1045645/100x100/crop(0,0,85,20).png", rendition.GetPath());

            Assert.Equal("100x100|crop(0,0,85,20).png", rendition.GetFullName("|"));

            Assert.Equal("1045645|>resize(100,100)|>crop(0,0,85,20)|>encode(png)", rendition.GetScript());

            var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

            Assert.Equal("1045645", rendition2.Source.Key);
            Assert.Equal("png", rendition2.Format);
            Assert.Equal(2, rendition2.GetTransforms().Count);
            Assert.Equal("100x100", rendition2.GetTransforms()[0].ToString());
            Assert.Equal("crop(0,0,85,20)", rendition2.GetTransforms()[1].ToString());



        }

        [Fact]
        public void CenterAnchoredResizePng()
        {
            var rendition = new MediaTransformation(new MediaSource("1045645"), "png")
                .Transform(new Resize(new Size(100, 50), CropAnchor.Center));

            Assert.Equal(100, rendition.Width);
            Assert.Equal(50, rendition.Height);

            Assert.Equal("100x50-c.png", rendition.GetFullName());
        }

        [Fact]
        public void ResizeAndRotated90()
        {
            var rendition = new MediaTransformation(new MediaSource("1045645"), "jpeg")
                .Resize(50, 50)
                .Crop(0, 0, 85, 20)
                .Rotate(90);

            Assert.Equal("50x50/crop(0,0,85,20)/rotate(90).jpeg", rendition.GetFullName());

            var rendition2 = MediaTransformation.ParsePath(rendition.GetPath());

            Assert.Equal(20, rendition.Width);
            Assert.Equal(85, rendition.Height);

            Assert.Equal(3, rendition2.GetTransforms().Count);

            Assert.Equal(90, ((Rotate)rendition2.GetTransforms()[2]).Angle);
        }

        [Fact]
        public void LeftAnchoredResizeAndRotate90()
        {
            var transformation = new MediaTransformation(new MediaSource("1045645"), "jpeg")
                .Transform(new Resize(new Size(150, 50), anchor: CropAnchor.Left))
                .Rotate(90);

            Assert.Equal("150x50-l/rotate(90).jpeg", transformation.GetFullName());
        }

        [Fact]
        public void LeftAnchoredResizeAndRotatationTiff()
        {
            var rendition = new MediaTransformation(new MediaSource("1045645"), "tiff")
                .Transform(new Resize(new Size(50, 50), anchor: CropAnchor.Left))
                .Rotate(180);

            Assert.Equal("50x50-l/rotate(180).tiff", rendition.GetFullName());
        }

        [Fact]
        public void AnchoredResizeHasValidFileName()
        {
            var rendition = new MediaTransformation(new MediaSource("100"), "jpeg")
                .Transform(new Resize(new Size(100, 100), anchor: CropAnchor.Center));

            Assert.Equal(@"100x100-c.jpeg", rendition.GetFullName());

            rendition = new MediaTransformation(new MediaSource("254565"), "jpeg")
                .Transform(new Resize(new Size(500, 100), anchor: CropAnchor.Center));

            Assert.Equal(@"500x100-c.jpeg", rendition.GetFullName());
        }

        [Fact]
        public void Filters()
        {
            var transformation = new MediaTransformation(jpeg_50x50, "jpeg")
                .Transform(new ContrastFilter(2f))
                .Transform(new GrayscaleFilter(1f))
                .Transform(new SepiaFilter(1f))
                .Transform(new OpacityFilter(1f))
                .Transform(new SaturateFilter(1f))
                .Transform(new HueRotateFilter(90));

            Assert.Equal(100, transformation.Width);
            Assert.Equal(50, transformation.Height);

            Assert.Equal("contrast(2)/grayscale(1)/sepia(1)/opacity(1)/saturate(1)/hue-rotate(90deg).jpeg", transformation.GetFullName());

            var rendition2 = MediaTransformation.ParsePath(transformation.GetPath());
            Assert.Equal(6, rendition2.GetTransforms().Count);

            Assert.Equal(2f, ((ContrastFilter)rendition2.GetTransforms()[0]).Amount);
            Assert.Equal(1f, ((GrayscaleFilter)rendition2.GetTransforms()[1]).Amount);
            Assert.Equal(1f, ((SepiaFilter)rendition2.GetTransforms()[2]).Amount);
            Assert.Equal(1f, ((OpacityFilter)rendition2.GetTransforms()[3]).Amount);
            Assert.Equal(1f, ((SaturateFilter)rendition2.GetTransforms()[4]).Amount);
            Assert.Equal(90, ((HueRotateFilter)rendition2.GetTransforms()[5]).Degrees);

        }

        [Fact]
        public void BuilderTests()
        {
            var transformation = new MediaTransformation(jpeg_50x50, "jpeg")
                .Resize(100, 100)
                .Rotate(90)
                .ApplyFilter("sepia", 1);

            Assert.Equal("1045645", transformation.Source.Key);
            Assert.Equal(100, transformation.Width);
            Assert.Equal(100, transformation.Height);

            Assert.Equal("100x100/rotate(90)/sepia(1).jpeg", transformation.GetFullName());
        }
    }

    public class MediaSource : IMediaSource
    {
        public MediaSource(string key, int width = 0, int height = 0)
        {
            Key = key;
            Width = width;
            Height = height;
        }

        public string Key { get; }

        public int Width { get; }

        public int Height { get; }
    }
}