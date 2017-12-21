using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class MetadataTests
    {
        [Fact]
        public void A()
        {
            var meta = MetadataFilter.Parse("metadata(width,height)");

            Assert.Equal("width",  meta.Properties[0]);
            Assert.Equal("height", meta.Properties[1]);
        }

        [Fact]
        public void B()
        {
            var meta = MetadataFilter.Parse("metadata(width,height,colors(count:10))");

            Assert.Equal("width",            meta.Properties[0]);
            Assert.Equal("height",           meta.Properties[1]);
            Assert.Equal("colors(count:10)", meta.Properties[2]);
        }
    }
}