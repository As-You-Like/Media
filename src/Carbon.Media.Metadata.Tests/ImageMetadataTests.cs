using System;
using Carbon.Json;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class ImageMetadataTests
    {
        [Fact]
        public void Test1()
        {
            var image = new ImageMetadata {
                Format = "gif",
                Width  = 800,
                Height = 600
            };
            
            var image2 = Helper.SerializeAndBack(image);

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
                PixelFormat = PixelFormat.Cmyk32,
                Width       = 1_000_000,
                Height      = 1_000_000,
                Orientation = ExifOrientation.Rotate90,
                ColorSpace  = ColorSpace.CMYK
            };

            var image2 = Helper.SerializeAndBack(image);
            
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
                Copyright   = "©2018 Willy Wonka. All Rights Reserved.",
                Exposure    = new ExposureInfo { Time = TimeSpan.FromSeconds(1) },
                Lens        = new LensInfo("Canon", "EF-S 35mm f/2.8 Macro IS STM"),
                Location    = new GpsData { Altitude = 1, Latitude = 2, Longitude = 3 },
                Lighting    = new LightingInfo { Source = LightSource.D50 },
                Software    = new SoftwareInfo { Name = "Photoshop" },
                Owner       = new ActorInfo {  Name = "Willy Wonka" }
            };

            var image2 = Helper.SerializeAndBack(image);

            Assert.Equal("dng",                                     image2.Format);
            Assert.Equal(4000,                                      image2.Width);
            Assert.Equal(ExifOrientation.None,                      image2.Orientation);
            Assert.Equal("©2018 Willy Wonka. All Rights Reserved.", image2.Copyright);
            Assert.Equal(ColorSpace.RGB,                            image2.ColorSpace);
            Assert.Equal("Canon",                                   image2.Camera.Make);
            Assert.Equal("EOS 5D",                                  image2.Camera.Model);
            Assert.Equal("Canon",                                   image2.Lens.Make);
            Assert.Equal("EF-S 35mm f/2.8 Macro IS STM",            image2.Lens.Model);
            Assert.Equal(1,                                         image2.Location.Altitude);
            Assert.Equal(2,                                         image2.Location.Latitude);
            Assert.Equal(3,                                         image2.Location.Longitude);

            Assert.Equal(@"{
  ""format"": ""dng"",
  ""width"": 4000,
  ""height"": 3000,
  ""pixelFormat"": ""Rgba64"",
  ""colorSpace"": ""RGB"",
  ""camera"": {
    ""make"": ""Canon"",
    ""model"": ""EOS 5D""
  },
  ""copyright"": ""\u00A92018 Willy Wonka. All Rights Reserved."",
  ""exposure"": {
    ""time"": ""00:00:01""
  },
  ""lens"": {
    ""make"": ""Canon"",
    ""model"": ""EF-S 35mm f\/2.8 Macro IS STM""
  },
  ""lighting"": {
    ""source"": ""D50""
  },
  ""location"": {
    ""longitude"": 3,
    ""latitude"": 2,
    ""altitude"": 1
  },
  ""owner"": {
    ""name"": ""Willy Wonka""
  },
  ""software"": {
    ""name"": ""Photoshop""
  }
}", JsonObject.FromObject(image).ToString());
        }
    }
}