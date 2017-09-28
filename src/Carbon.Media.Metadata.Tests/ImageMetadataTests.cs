using System.IO;
using Carbon.Json;
using ProtoBuf;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class ImageMetadataTests
    {
        [Fact]
        public void Test1()
        {
            var image = new ImageMetadata {
                Format = ImageFormat.Gif,
                Width = 800,
                Height = 600
            };
            
            var output = new MemoryStream();

            Serializer.Serialize(output, image);

            output.Position = 0;

            var image2 = Serializer.Deserialize<ImageMetadata>(output);

            Assert.Equal(ImageFormat.Gif, image2.Format);

            // TODO: format should be "aac"

            Assert.Equal(@"{
  ""format"": ""Gif"",
  ""width"": 800,
  ""height"": 600
}", JsonObject.FromObject(image).ToString());
        }

        [Fact]
        public void Test3()
        {
            var image = new ImageMetadata {
                Format = ImageFormat.Tiff,
                Width  = 1_000_000,
                Height = 1_000_000,
                Orientation = ExifOrientation.Rotate90,
                PixelFormat = PixelFormat.Cmyk32,
                ColorSpace = ColorSpace.CMYK
            };

            var output = new MemoryStream();

            Serializer.Serialize(output, image);

            output.Position = 0;

            var image2 = Serializer.Deserialize<ImageMetadata>(output);

            Assert.Equal(ImageFormat.Tiff,          image2.Format);
            Assert.Equal(1_000_000,                 image2.Width);
            Assert.Equal(1_000_000,                 image2.Height);
            Assert.Equal(ExifOrientation.Rotate90,  image2.Orientation);
            Assert.Equal(PixelFormat.Cmyk32,        image2.PixelFormat);
        }
    }
}