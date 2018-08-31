using Xunit;

namespace Carbon.Media.Tests
{
    public class AudioCodecTests
    {
        [Theory]
        [InlineData("aac", CodecId.Aac)]
        [InlineData("mp3", CodecId.Mp3)]
        [InlineData("opus", CodecId.Opus)]
        public void ParseTests(string name, CodecId id)
        {
            Assert.Equal(id, CodecIdHelper.Parse(name));
        }
        
        [Fact]
        public void Aliases()
        {
            Assert.Equal(CodecId.G722_2, CodecId.AmrWb);
        }

        [Fact]
        public void Aac()
        {
            var codec = CodecInfo.Aac;

            Assert.Equal("aac", codec.Name);
            Assert.True(codec.Equals(CodecInfo.Aac));
            Assert.False(codec.Equals(null));
        }
    }
}