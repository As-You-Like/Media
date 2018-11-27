using Carbon.Media.Metadata.Exif;
using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class MetadataMapTests
    {
        [Fact]
        public void Test1()
        {
            var result = ExifTagMap.Get(ExifTag.ExposureTime);

            Assert.NotNull(result.Converter); // RationalConverter
            Assert.Equal("ExposureTime", result.Name);
            Assert.Equal(33434,           result.Code);

            result = ExifTagMap.Get(ExifTag.ExposureMode);

            Assert.Equal("ExposureMode", result.Name);
            Assert.Equal(41986,          result.Code);

            result = ExifTagMap.Get(ExifTag.GPSAltitude);

            Assert.Equal("GPSAltitude", result.Name);
            Assert.Equal(6, result.Code);

            /*
            result = MetadataMap.Get(ExifTag.Acceleration);

            Assert.Equal("Acceleration", result.Name);
            Assert.Equal(37892,          result.Code);
            */
        }
    }
}