using Xunit;

namespace Carbon.Media.Codecs.Tests
{
    public class CodecIdTests
    {
        [Theory]
        [InlineData(CodecId.Aac, 2200)]
        [InlineData(CodecId.AV1, 9033)]
        [InlineData(CodecId.H264, 9306)]
        [InlineData(CodecId.Hevc, 9307)]
        public void IdsAreCorrect(CodecId type, int id)
        {
            Assert.Equal(id, (int)type);
        }
    }
}