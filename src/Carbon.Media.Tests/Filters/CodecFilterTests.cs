using System;

using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class CodecFilterTests
    {
        [Fact]
        public void ParseName()
        {
            var filter = CodecFilter.Create(CallSyntax.Parse("codec(vp9)"));

            Assert.Equal("vp9", filter.Name);
        }

        [Fact]
        public void ParseNameAndProfile()
        {
            var filter = CodecFilter.Create(CallSyntax.Parse("codec(h264,high)"));

            Assert.Equal("h264", filter.Name);
            Assert.Equal("high", filter.Profile);
        }

        [Fact]
        public void ParseNameProfileAndLevel()
        {
            var filter = CodecFilter.Create(CallSyntax.Parse("codec(h264,high,4.1)"));

            Assert.Equal("h264", filter.Name);
            Assert.Equal("high", filter.Profile);
            Assert.Equal(4.1f, filter.Level);
        }

        [Fact]
        public void ParseNameProfileAndLevel_2()
        {
            var filter = CodecFilter.Create(CallSyntax.Parse("codec(h264,baseline,3)"));

            Assert.Equal("h264",     filter.Name);
            Assert.Equal("baseline", filter.Profile);
            Assert.Equal(3f,         filter.Level);
        }


        [Fact]
        public void ThrowsOnInvalidLevel()
        {
            Assert.Throws<FormatException>(() => CodecFilter.Create(CallSyntax.Parse("codec(h264,high,a)")));
        }
    }
}
