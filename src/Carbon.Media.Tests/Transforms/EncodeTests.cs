using Xunit;

namespace Carbon.Media.Tests
{	
	public class EncodeTests
	{
        [Theory]
        [InlineData("jpeg")]
        [InlineData("gif")]
        [InlineData("png")]
        [InlineData("webp")]
        [InlineData("jxr")]
        public void A(string name)
        {
            var encode = Encode.Parse($"encode({name}, quality:95)");

            Assert.Equal(95, encode.Quality);

            // TODO: Finalize encoder case... leaning toward upper

            Assert.Equal($"encode({name.ToUpper()},quality:95)", encode.Canonicalize());
        }

    }
}