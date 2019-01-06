using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class VolumeFilterTests
    {
        [Fact]
        public void Parse()
        {
            var filter = Processor.Parse("volume(0.5)") as VolumeFilter;

            Assert.Equal(0.5, filter.Value);

            Assert.Equal("volume(0.5)", filter.ToString());
        }

        [Fact]
        public void Parse2()
        {
            var filter = Processor.Parse("volume(0)") as VolumeFilter;

            Assert.Equal(0, filter.Value);

            Assert.Equal("volume(0)", filter.ToString());
        }


        [Fact]
        public void Parse3()
        {
            var filter = Processor.Parse("volume(100%)") as VolumeFilter;

            Assert.Equal(1, filter.Value);

            Assert.Equal("volume(1)", filter.ToString());
        }

    }
}