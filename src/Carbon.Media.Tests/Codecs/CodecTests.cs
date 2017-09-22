using FFmpeg.AutoGen;

using Xunit;

namespace Carbon.Media.Tests
{
    public class CodecTests
    {
        [Theory]
        [InlineData(CodecId.Aac,    86018, AVCodecID.AV_CODEC_ID_AAC)]
        [InlineData(CodecId.Ac3,    86019, AVCodecID.AV_CODEC_ID_AC3)]
        [InlineData(CodecId.Alac,   86032, AVCodecID.AV_CODEC_ID_ALAC)] // Apple Lossless
        [InlineData(CodecId.Flac,   86028, AVCodecID.AV_CODEC_ID_FLAC)]
        [InlineData(CodecId.Opus,   86077, AVCodecID.AV_CODEC_ID_OPUS)]
        [InlineData(CodecId.Mp3,    86017, AVCodecID.AV_CODEC_ID_MP3)]
        [InlineData(CodecId.Vorbis, 86021, AVCodecID.AV_CODEC_ID_VORBIS)]

        // MISC
        [InlineData(CodecId.AmrNb,      73728, AVCodecID.AV_CODEC_ID_AMR_NB)]
        [InlineData(CodecId.Cook,       86036, AVCodecID.AV_CODEC_ID_COOK)]
        [InlineData(CodecId.Ra144,      77824, AVCodecID.AV_CODEC_ID_RA_144)]
        [InlineData(CodecId.Ra288,      77825, AVCodecID.AV_CODEC_ID_RA_288)]
        [InlineData(CodecId.Gsm,        86034, AVCodecID.AV_CODEC_ID_GSM)]
        [InlineData(CodecId.Svq1,       23,    AVCodecID.AV_CODEC_ID_SVQ1)] // Sorenson Video 1
        [InlineData(CodecId.Svq3,       24,    AVCodecID.AV_CODEC_ID_SVQ3)] // Sorenson Video 3
        [InlineData(CodecId.TwinVQ,     86060, AVCodecID.AV_CODEC_ID_TWINVQ)]
        [InlineData(CodecId.TrueSpeech, 86037, AVCodecID.AV_CODEC_ID_TRUESPEECH)]
        [InlineData(CodecId.G722_2,     73729, AVCodecID.AV_CODEC_ID_AMR_WB)]
        [InlineData(CodecId.G723_1,     86069, AVCodecID.AV_CODEC_ID_G723_1)]
        [InlineData(CodecId.G729,       86070, AVCodecID.AV_CODEC_ID_G729)]
        [InlineData(CodecId.WavPack,    86041, AVCodecID.AV_CODEC_ID_WAVPACK)]

        public void AudioCodecTypes(CodecId a, int b, AVCodecID codecId)
        {
            Assert.Equal(b, (int)a);
            Assert.Equal(b, (int)codecId);
        }

        [Theory]
        [InlineData(CodecId.Png,  62,    AVCodecID.AV_CODEC_ID_PNG)]
        [InlineData(CodecId.Tiff, 97,    AVCodecID.AV_CODEC_ID_TIFF)]
        [InlineData(CodecId.Psd,  32790, AVCodecID.AV_CODEC_ID_PSD)]
        [InlineData(CodecId.WebP, 172,   AVCodecID.AV_CODEC_ID_WEBP)]
        [InlineData(CodecId.Bmp,  79,    AVCodecID.AV_CODEC_ID_BMP)]
        [InlineData(CodecId.Jp2,  89,    AVCodecID.AV_CODEC_ID_JPEG2000)]

        public void ImageCodecTypes(CodecId a, int b, AVCodecID codecId)
        {
            Assert.Equal(b, (int)a);
            Assert.Equal(b, (int)codecId);
        }

        [Theory]
        [InlineData(CodecId.AV1,  32797, AVCodecID.AV_CODEC_ID_AV1)]
        [InlineData(CodecId.Hevc, 174,   AVCodecID.AV_CODEC_ID_HEVC)]
        [InlineData(CodecId.H263, 5,     AVCodecID.AV_CODEC_ID_H263)]
        [InlineData(CodecId.H264, 28,    AVCodecID.AV_CODEC_ID_H264)]
        [InlineData(CodecId.Vp6,  92,    AVCodecID.AV_CODEC_ID_VP6)]
        [InlineData(CodecId.Vp7,  180,   AVCodecID.AV_CODEC_ID_VP7)]
        [InlineData(CodecId.Vp8,  140,   AVCodecID.AV_CODEC_ID_VP8)]
        [InlineData(CodecId.Vp9,  168,   AVCodecID.AV_CODEC_ID_VP9)]

        // Random
        [InlineData(CodecId.Kmvc,    86, AVCodecID.AV_CODEC_ID_KMVC)]
        [InlineData(CodecId.FlashSv, 87, AVCodecID.AV_CODEC_ID_FLASHSV)]

        public void VideoCodecTypes(CodecId a, int b, AVCodecID codecId)
        {
            Assert.Equal(b, (int)a);
            Assert.Equal(b, (int)codecId);
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