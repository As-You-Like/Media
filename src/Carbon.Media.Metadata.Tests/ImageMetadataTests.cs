using System;
using System.IO;
using Carbon.Json;
using ProtoBuf;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class ImageMetadataTests
    {
        private static T SerializeAndBack<T>(T metadata)
        {
            var output = new MemoryStream();

            Serializer.Serialize(output, metadata);

            output.Position = 0;

            return Serializer.Deserialize<T>(output);
        }

        [Fact]
        public void Test1()
        {
            var image = new ImageMetadata {
                Format = "gif",
                Width  = 800,
                Height = 600
            };
            
            var image2 = SerializeAndBack(image);

            Assert.Equal("gif", image2.Format);
            Assert.Equal(800, image2.Width);
            Assert.Equal(600, image2.Height);

            // TODO: format should be "aac"

            Assert.Equal(@"{
  ""format"": ""gif"",
  ""width"": 800,
  ""height"": 600
}", JsonObject.FromObject(image).ToString());
        }

        [Fact]
        public void Test3()
        {
            var image = new ImageMetadata {
                Format      = "tiff",
                Width       = 1_000_000,
                Height      = 1_000_000,
                Orientation = ExifOrientation.Rotate90,
                PixelFormat = PixelFormat.Cmyk32,
                ColorSpace  = ColorSpace.CMYK
            };

            var image2 = SerializeAndBack(image);
            
            Assert.Equal("tiff",                    image2.Format);
            Assert.Equal(1_000_000,                 image2.Width);
            Assert.Equal(1_000_000,                 image2.Height);
            Assert.Equal(ExifOrientation.Rotate90,  image2.Orientation);
            Assert.Equal(PixelFormat.Cmyk32,        image2.PixelFormat);
        }

        [Fact]
        public void TestPhotograph()
        {
            // 12MP Digital Negitive
            // 64bpp = 96MB buffer
            var image = new ImageMetadata
            {
                Format      = "dng",
                Width       = 4000,
                Height      = 3000,
                PixelFormat = PixelFormat.Rgba64,
                ColorSpace  = ColorSpace.RGB,
                Camera      = new CameraInfo("Canon", "EOS 5D"),
                Lens        = new LensInfo("Canon", "EF-S 35mm f/2.8 Macro IS STM"),
                Exposure    = new ExposureInfo    { Time = TimeSpan.FromSeconds(1) },
                Sensor      = new SensorInfo      { Type = SensingMethod.Trilinear },
                Lighting    = new LightingInfo    { Source = LightSource.D50 },
                Software    = new SoftwareInfo    { Name = "Photoshop" },
                Location    = new GpsData         { Altitude = 1, Latitude = 2, Longitude = 3 }
            };

            var image2 = SerializeAndBack(image);

            Assert.Equal("dng",                          image2.Format);
            Assert.Equal(4000,                           image2.Width);
            Assert.Null(image2.Orientation);
            Assert.Equal(ColorSpace.RGB,                 image2.ColorSpace);
            Assert.Equal("Canon",                        image2.Camera.Make);
            Assert.Equal("EOS 5D",                       image2.Camera.Model);
            Assert.Equal("Canon",                        image2.Lens.Make);
            Assert.Equal("EF-S 35mm f/2.8 Macro IS STM", image2.Lens.Model);
            Assert.Equal(1,                              image2.Location.Altitude);
            Assert.Equal(2,                              image2.Location.Latitude);
            Assert.Equal(3,                              image2.Location.Longitude);

        }
    }
}