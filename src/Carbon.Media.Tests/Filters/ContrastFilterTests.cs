using System;

using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{

    public class ContrastFilterTests
    {
        [Fact]
        public void Parse()
        {
            var filter = ContrastFilter.Create(CallSyntax.Parse("contrast(0.5)"));

            Assert.Equal(0.5, filter.Amount);
        }


        [Fact]
        public void SupportsPercentageUnit()
        {
            var filter = ContrastFilter.Create(CallSyntax.Parse("contrast(50%)"));

            Assert.Equal(0.5, filter.Amount);
        }

    
        [Fact]
        public void ThrowsWhenGreaterThan10x()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ContrastFilter.Create(CallSyntax.Parse("contrast(-1001%)")));
            Assert.Throws<ArgumentOutOfRangeException>(() => ContrastFilter.Create(CallSyntax.Parse("contrast(1001%)")));
        }
    }
}
