
using Xunit;

namespace Carbon.Media.Tests
{
    public class VideoCodecTests
    {
        [Theory]
        [InlineData("av1",  CodecId.AV1)]
        [InlineData("h264", CodecId.H264)]
        [InlineData("hevc", CodecId.Hevc)]
        [InlineData("vp8",  CodecId.Vp8)]
        [InlineData("vp9",  CodecId.Vp9)]
        public void ParseTests(string name, CodecId id)
        {
            Assert.Equal(id, CodecIdHelper.Parse(name));
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