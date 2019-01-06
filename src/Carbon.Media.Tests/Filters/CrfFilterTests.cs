using System;
using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class CrfFilterTests
    {
        [Fact]
        public void Parse()
        {
            var crf = Processor.Parse("crf(10)") as ConstantRateFactorFilter;

            Assert.Equal(10, crf.Value);
            Assert.Equal("crf(10)", crf.ToString());
        }

        [Fact]
        public void ThrowsOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.Parse("crf(-1)"));
            Assert.Throws<ArgumentOutOfRangeException>(() => Processor.Parse("crf(100)"));
            
        }
    }
}