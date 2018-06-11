using FFmpeg.AutoGen;

using Xunit;

namespace Carbon.Media.Tests
{
    public class VideoCodecTests
    {
        [Theory]
        [InlineData(CodecId.AV1,  AVCodecID.AV_CODEC_ID_AV1)]
        [InlineData(CodecId.Hevc, AVCodecID.AV_CODEC_ID_HEVC)]
        [InlineData(CodecId.H263, AVCodecID.AV_CODEC_ID_H263)]
        [InlineData(CodecId.H264, AVCodecID.AV_CODEC_ID_H264)]
        [InlineData(CodecId.Vp6,  AVCodecID.AV_CODEC_ID_VP6)]
        [InlineData(CodecId.Vp7,  AVCodecID.AV_CODEC_ID_VP7)]
        [InlineData(CodecId.Vp8,  AVCodecID.AV_CODEC_ID_VP8)]
        [InlineData(CodecId.Vp9,  AVCodecID.AV_CODEC_ID_VP9)]
        public void Core(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
        }

        [Theory]
        [InlineData(CodecId.BmvVideo, AVCodecID.AV_CODEC_ID_BMV_VIDEO)]
        [InlineData(CodecId.Kmvc, AVCodecID.AV_CODEC_ID_KMVC)]
        [InlineData(CodecId.FlashSv, AVCodecID.AV_CODEC_ID_FLASHSV)]
        [InlineData(CodecId.ProRes, AVCodecID.AV_CODEC_ID_PRORES)]
        public void Extended(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());

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