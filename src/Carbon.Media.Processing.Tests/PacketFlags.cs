using FFmpeg.AutoGen;
using Xunit;

namespace Carbon.Media.Ffmpeg.Tests
{
    public class PacketFlagTests
    {
        [Theory]
        [InlineData(PacketFlags.Corrupt,  ffmpeg.AV_PKT_FLAG_CORRUPT)]
        [InlineData(PacketFlags.Discard,  ffmpeg.AV_PKT_FLAG_DISCARD)]
        [InlineData(PacketFlags.Keyframe, ffmpeg.AV_PKT_FLAG_KEY)]
        [InlineData(PacketFlags.Trusted,  ffmpeg.AV_PKT_FLAG_TRUSTED)]
        public void FfmpegCodesAreEqual(PacketFlags flag, int ffmpegCode)
        {
            Assert.Equal((int)flag, ffmpegCode);
        }
    }
}