
using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class PaletteFilterTests
    {
        [Fact]
        public void Parse1()
        {
            var filter = PaletteFilter.Create(CallSyntax.Parse("palette(256)"));

            Assert.Equal(256, filter.Count);
            Assert.Null(filter.Format);

            Assert.Equal("palette(256)", filter.ToString());
        }

        [Fact]
        public void Parse2()
        {
            var filter = PaletteFilter.Create(CallSyntax.Parse("palette(10,hex8)"));

            Assert.Equal(10, filter.Count);
            Assert.Equal("hex8", filter.Format);

            Assert.Equal("palette(10,hex8)", filter.ToString());
        }
    }
}
