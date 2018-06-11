using FFmpeg.AutoGen;

using Xunit;

namespace Carbon.Media.Tests
{
    public class SubtitleCodecTests
    {
        [Theory]
        [InlineData(CodecId.Ass, AVCodecID.AV_CODEC_ID_ASS)]
        // [InlineData(CodecId.CVD, AVCodecID.AV_CODEC_ID_CVD)]
        [InlineData(CodecId.MicroDvd, AVCodecID.AV_CODEC_ID_MICRODVD)]
        [InlineData(CodecId.Mpl2, AVCodecID.AV_CODEC_ID_MPL2)]
        [InlineData(CodecId.SubRip, AVCodecID.AV_CODEC_ID_SUBRIP)]
        [InlineData(CodecId.VPlayer, AVCodecID.AV_CODEC_ID_VPLAYER)]
        [InlineData(CodecId.RealText, AVCodecID.AV_CODEC_ID_REALTEXT)]

        public void Core(CodecId codecId, AVCodecID avCodecId)
        {
            var i = (int)codecId;

            Assert.True(i >= 100_000 && i <= 100_999);

            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());

        }

    }
}