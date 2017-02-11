using Xunit;

namespace Carbon.Media.Processors.Tests
{	
	public class EncodeTests
	{
        /*
        [Theory]
        [InlineData("jpeg")]
        [InlineData("gif")]
        [InlineData("png")]
        [InlineData("webp")]
        // [InlineData("jxr")]
        public void A(string name)
        {
            var encode = Encode.Parse($"{name}(quality:95)");

            Assert.Equal(95, encode.Quality);

            var e = Encode.Parse(encode.Canonicalize());

            // TODO: Finalize encoder case... leaning toward upper

            Assert.Equal($"{e.Format.Canonicalize()}::encode(quality:95)", encode.Canonicalize());
        }
        */

        // JPEG::encode(quality:100)
        // PNG::encode
        // WebP::encode
    }
}