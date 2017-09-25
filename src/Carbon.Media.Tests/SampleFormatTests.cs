using System;
using Xunit;

namespace Carbon.Media.Tests
{
    public class SampleFormatTests
    {
        [Theory]
        [InlineData(SampleFormat.Int16,        16, typeof(short), false)]
        [InlineData(SampleFormat.Int32,        32, typeof(int), false)]
        [InlineData(SampleFormat.Int64,        64, typeof(long), false)]
        [InlineData(SampleFormat.FloatPlanar,  32, typeof(float), true)]
        [InlineData(SampleFormat.DoublePlanar, 64, typeof(double), true)]
        public void InfoIsCorrect(SampleFormat id, int bitCount, Type type, bool isPlanar)
        {
            var format = SampleFormatInfo.Get(id);

            Assert.Equal(id, format.Id);
            Assert.Equal(bitCount, format.BitCount);
            Assert.Equal(type, format.Type);
            Assert.Equal(isPlanar, format.IsPlanar);
        }
    }
}
