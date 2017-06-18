using Xunit;

namespace Carbon.Media.Tests
{
    public class CodecTests
    {
        [Theory]
        [InlineData(AudioFormat.Ac3, CodecType.Ac3)]
        [InlineData(AudioFormat.Aiff, CodecType.Aiff)]
        [InlineData(AudioFormat.Alac, CodecType.Alac)]
        [InlineData(AudioFormat.Flac, CodecType.Flac)]
        [InlineData(AudioFormat.Opus, CodecType.Opus)]
        public void AudioCodecTypes(AudioFormat a, CodecType b)
        {
            Assert.Equal((int)a, (int)b);
        }

        [Fact]
        public void A()
        {
            var codec = CodecInfo.Aac;

            Assert.Equal("aac", codec.Name);
            Assert.True(codec.Equals(CodecInfo.Aac));
            Assert.False(codec.Equals(null));
        }

        [Fact]
        public void H264Profiles()
        {
            Assert.Equal(CodecInfo.H264Baseline, CodecInfo.Parse("avc1.42E01E"));
            Assert.Equal(CodecInfo.H264Main,     CodecInfo.Parse("avc1.4D401E"));
            Assert.Equal(CodecInfo.H264Extended, CodecInfo.Parse("avc1.58A01E"));
            Assert.Equal(CodecInfo.H264High,     CodecInfo.Parse("avc1.64001E"));


            Assert.Equal(CodecInfo.H264Level0Simple,   CodecInfo.Parse("mp4v.20.9"));
            Assert.Equal(CodecInfo.H264Level0Advanced, CodecInfo.Parse("mp4v.20.240"));


            Assert.Equal(CodecInfo.AacLC, CodecInfo.Parse("mp4a.40.2"));

        }
    }
}