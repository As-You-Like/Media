using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class PageFilterTests
    {
        [Fact]
        public void A()
        {
            var scale = PageFilter.Create(CallSyntax.Parse("page(11)"));

            Assert.Equal("page(11)", scale.Canonicalize());
        }
    }
}