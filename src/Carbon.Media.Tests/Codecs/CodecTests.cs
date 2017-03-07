using Xunit;

namespace Carbon.Media.Tests
{
    public class CodecTests
    {
        [Theory]
        [InlineData(AudioFormat.Ac3, MediaCodecType.Ac3)]
        [InlineData(AudioFormat.Aiff, MediaCodecType.Aiff)]
        [InlineData(AudioFormat.Alac, MediaCodecType.Alac)]
        [InlineData(AudioFormat.Flac, MediaCodecType.Flac)]
        [InlineData(AudioFormat.Opus, MediaCodecType.Opus)]
        public void AudioCodecTypes(AudioFormat a, MediaCodecType b)
        {
            Assert.Equal((int)a, (int)b);
        }

        [Fact]
        public void A()
        {
            var codec = MediaCodec.Aac;

            Assert.Equal("aac", codec.Name);
            Assert.True(codec.Equals(MediaCodec.Aac));
            Assert.False(codec.Equals(null));
        }

        [Fact]
        public void H264Profiles()
        {
            Assert.Equal(MediaCodec.H264Baseline, MediaCodec.Parse("avc1.42E01E"));
            Assert.Equal(MediaCodec.H264Main,     MediaCodec.Parse("avc1.4D401E"));
            Assert.Equal(MediaCodec.H264Extended, MediaCodec.Parse("avc1.58A01E"));
            Assert.Equal(MediaCodec.H264High,     MediaCodec.Parse("avc1.64001E"));


            Assert.Equal(MediaCodec.H264Level0Simple,   MediaCodec.Parse("mp4v.20.9"));
            Assert.Equal(MediaCodec.H264Level0Advanced, MediaCodec.Parse("mp4v.20.240"));


            Assert.Equal(MediaCodec.AacLC, MediaCodec.Parse("mp4a.40.2"));

        }
    }
}