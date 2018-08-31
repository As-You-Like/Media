using FFmpeg.AutoGen;

using Xunit;

namespace Carbon.Media.Tests
{
    using static AVCodecID;

    public class ImageCodecTests
    {
        [Theory]
        [InlineData("apng", CodecId.Apng)]
        [InlineData("bmp", CodecId.Bmp)]
        [InlineData("jpeg", CodecId.Jpeg)]
        [InlineData("jp2", CodecId.Jp2)]
        [InlineData("webp", CodecId.WebP)]
        public void ParseTests(string name, CodecId id)
        {
            Assert.Equal(id, CodecIdHelper.Parse(name));
        }

        [Theory]
        [InlineData(CodecId.Apng, AV_CODEC_ID_APNG,     ImageFormat.Apng)]
        [InlineData(CodecId.Bmp,  AV_CODEC_ID_BMP,      ImageFormat.Bmp)]
        [InlineData(CodecId.Jp2,  AV_CODEC_ID_JPEG2000, ImageFormat.Jp2)]
        [InlineData(CodecId.Png,  AV_CODEC_ID_PNG,      ImageFormat.Png)]
        [InlineData(CodecId.Svg,  AV_CODEC_ID_SVG,      ImageFormat.Svg)]
        [InlineData(CodecId.Tiff, AV_CODEC_ID_TIFF,     ImageFormat.Tiff)]
        [InlineData(CodecId.Psd,  AV_CODEC_ID_PSD,      ImageFormat.Psd)]
        [InlineData(CodecId.WebP, AV_CODEC_ID_WEBP,     ImageFormat.WebP)]
        public void Core(CodecId codecId, AVCodecID avCodecId, ImageFormat format)
        {
            Assert.Equal((int)format, (int)codecId);

            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
        }

        [Theory]
        [InlineData(CodecId.Dpx, AV_CODEC_ID_DPX)]
        [InlineData(CodecId.Tga, AV_CODEC_ID_TARGA)]
        public void Extended(CodecId codecId, AVCodecID avCodecId)
        {
            Assert.Equal(codecId, avCodecId.ToCodecId());
            Assert.Equal(avCodecId, codecId.ToAVCodecID());
        }
    }
}