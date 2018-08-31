using System;
using Xunit;

namespace Carbon.Media.Tests
{
    public class SampleFormatTests
    {
        [Theory]
        [InlineData(SampleFormat.I8,  8,  typeof(sbyte),  false)]
        [InlineData(SampleFormat.U8, 8,  typeof(byte),   false)]
        [InlineData(SampleFormat.I16, 16, typeof(short),  false)]
        [InlineData(SampleFormat.I32, 32, typeof(int),    false)]
        [InlineData(SampleFormat.I64, 64, typeof(long),   false)]
        [InlineData(SampleFormat.F32p,  32, typeof(float),  true)]
        [InlineData(SampleFormat.F64p,  64, typeof(double), true)]
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
