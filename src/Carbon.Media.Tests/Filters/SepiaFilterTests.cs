using System;
using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class SepiaFilterTests
    {
        [Fact]
        public void SupportsPercentageUnit()
        {
            var filter = SepiaFilter.Create(CallSyntax.Parse("sepia(50%)"));

            Assert.Equal(0.5, filter.Amount);
        }

        [Fact]
        public void Parse()
        {
            var filter = SepiaFilter.Create(CallSyntax.Parse("sepia(0.5)"));

            Assert.Equal(0.5, filter.Amount);
        }

        [Fact]
        public void ThrowsWheNegtive()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SepiaFilter.Create(CallSyntax.Parse("sepia(-1%)")));
        }

        [Fact]
        public void ClampsWhenGreaterThan100P()
        {
            var filter = SepiaFilter.Create(CallSyntax.Parse("sepia(101%)"));

            Assert.Equal(1, filter.Amount);
        }
    }
}