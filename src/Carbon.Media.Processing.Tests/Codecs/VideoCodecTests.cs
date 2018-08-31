using FFmpeg.AutoGen;
using Xunit;

namespace Carbon.Media.Processing.Tests
{
    using static AVCodecID;

    public class VideoCodecTests
    {
        [Theory]
        [InlineData(CodecId.AV1,    AV_CODEC_ID_AV1)]
        [InlineData(CodecId.Hevc,   AV_CODEC_ID_HEVC)]
        [InlineData(CodecId.H263,   AV_CODEC_ID_H263)]
        [InlineData(CodecId.H264,   AV_CODEC_ID_H264)]
        [InlineData(CodecId.Vp6,    AV_CODEC_ID_VP6)]
        [InlineData(CodecId.Vp7,    AV_CODEC_ID_VP7)]
        [InlineData(CodecId.Vp8,    AV_CODEC_ID_VP8)]
        [InlineData(CodecId.Vp9,    AV_CODEC_ID_VP9)]
        public void Core(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
        }

        [Theory]
        [InlineData(CodecId.BmvVideo,   AV_CODEC_ID_BMV_VIDEO)]
        [InlineData(CodecId.Kmvc,       AV_CODEC_ID_KMVC)]
        [InlineData(CodecId.FlashSv,    AV_CODEC_ID_FLASHSV)]
        [InlineData(CodecId.ProRes,     AV_CODEC_ID_PRORES)]
        public void Extended(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());

        }
    }
}
