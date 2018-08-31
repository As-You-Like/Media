using FFmpeg.AutoGen;

using Xunit;

using static FFmpeg.AutoGen.AVCodecID;

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

        [Theory]
        [InlineData(CodecId.Aac,    AV_CODEC_ID_AAC,         FormatId.Aac)]
        [InlineData(CodecId.Ac3,    AV_CODEC_ID_AC3,         FormatId.Ac3)]
        [InlineData(CodecId.Alac,   AV_CODEC_ID_ALAC,        FormatId.Alac)] // Apple Lossless
        [InlineData(CodecId.Flac,   AV_CODEC_ID_FLAC,        FormatId.Flac)]
        [InlineData(CodecId.Opus,   AV_CODEC_ID_OPUS,        FormatId.Opus)]
        [InlineData(CodecId.Mp3,    AV_CODEC_ID_MP3,         FormatId.Mp3)]
        [InlineData(CodecId.Vorbis, AV_CODEC_ID_VORBIS,      FormatId.Vorbis)]
        [InlineData(CodecId.Wma1,   AV_CODEC_ID_WMAV1,       FormatId.Wma)]
        [InlineData(CodecId.Wmal,   AV_CODEC_ID_WMALOSSLESS, FormatId.Wmal)]
        public void Core(CodecId codecId, AVCodecID avCodecId, FormatId format)
        {
            // Assert.Equal((int)codecId, (int)format);

            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());

        }

        [Theory]
        [InlineData(CodecId.AmrNb,      AV_CODEC_ID_AMR_NB)]
        [InlineData(CodecId.Cook,       AV_CODEC_ID_COOK)]
        [InlineData(CodecId.Ra144,      AV_CODEC_ID_RA_144)]
        [InlineData(CodecId.Ra288,      AV_CODEC_ID_RA_288)]
        [InlineData(CodecId.Gsm,        AV_CODEC_ID_GSM)]
        [InlineData(CodecId.Svq1,       AV_CODEC_ID_SVQ1)] // Sorenson Video 1
        [InlineData(CodecId.Svq3,       AV_CODEC_ID_SVQ3)] // Sorenson Video 3
        [InlineData(CodecId.TwinVQ,     AV_CODEC_ID_TWINVQ)]
        [InlineData(CodecId.TrueSpeech, AV_CODEC_ID_TRUESPEECH)]
        [InlineData(CodecId.WavPack,    AV_CODEC_ID_WAVPACK)]
        public void Extended(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
        }

        [Theory]
        [InlineData(CodecId.G722,   AV_CODEC_ID_ADPCM_G722)]
        [InlineData(CodecId.G722_2, AV_CODEC_ID_AMR_WB)]
        [InlineData(CodecId.G723_1, AV_CODEC_ID_G723_1)]
        [InlineData(CodecId.G726,   AV_CODEC_ID_ADPCM_G726)]
        [InlineData(CodecId.G729,   AV_CODEC_ID_G729)]
        public void G7Standards(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
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