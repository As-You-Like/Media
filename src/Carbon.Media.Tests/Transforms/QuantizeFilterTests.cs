using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class QuantizeFilterTests
    {
        [Fact]
        public void A()
        {
            var filter = QuantizeFilter.Create(CallSyntax.Parse("quantize(256,algorithm:wu)"));

            Assert.Equal(256, filter.MaxColors);
            Assert.Equal("wu", filter.Algorithm);
            Assert.Null(filter.Dither);

            Assert.Equal("quantize(256,algorithm:wu)", filter.ToString());
        }

        [Fact]
        public void B()
        {
            var filter = QuantizeFilter.Create(CallSyntax.Parse("quantize(1,Octree,dither:1)"));

            Assert.Equal(1, filter.MaxColors);
            Assert.Equal("Octree", filter.Algorithm);
            Assert.True(filter.Dither);
        }
    }
}