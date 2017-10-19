using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class EncodeTests
	{
        [Theory]
        [InlineData("jpeg")]
        [InlineData("gif")]
        [InlineData("png")]
        [InlineData("webp")]
        // [InlineData("jxr")]
        public void A(string name)
        {
            var encode = ImageEncode.Parse($"{name}::encode(quality:95)");

            Assert.Equal(95, encode.Quality);

            var e = ImageEncode.Parse(encode.Canonicalize());

            // TODO: Finalize encoder case... leaning toward upper

            Assert.Equal($"{e.Format.Canonicalize()}::encode(quality:95)", encode.Canonicalize());
        }

        [Fact]
        public void Png8Test()
        {
            var encode = ImageEncode.Parse("png8::encode");

            Assert.Equal(ImageFormat.Png, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodeFlags._8bit));
        }

        [Fact]
        public void Png32Test()
        {
            var encode = ImageEncode.Parse("png32::encode");

            Assert.Equal(ImageFormat.Png, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodeFlags._32bit));
        }

        [Fact]
        public void ProgressiveJpegTest()
        {
            var encode = ImageEncode.Parse("pjpg::encode");

            Assert.Equal(ImageFormat.Jpeg, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodeFlags.Progressive));
        }
    }
}