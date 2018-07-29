using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class FrameFilterTests
    {
        [Fact]
        public void A()
        {
            var scale = FrameFilter.Create(CallSyntax.Parse("frame(11)"));

            Assert.Equal("frame(11)", scale.Canonicalize());
        }
    }
}