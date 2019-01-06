using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class CustomFilterTests
    {
        [Fact]
        public void A()
        {
            var filter = UnknownFilter.Create(CallSyntax.Parse("starburst(count:100)"));

            Assert.Equal("starburst", filter.Name);
            Assert.Equal("count", filter.Arguments[0].Name);
            Assert.Equal("100", filter.Arguments[0].Value);
        }

        [Fact]
        public void B()
        {
            var filter = UnknownFilter.Create(CallSyntax.Parse("starburst"));

            Assert.Equal("starburst", filter.Name);
            Assert.Empty(filter.Arguments);
        }
    }
}
