using Xunit;

namespace Carbon.Media.Tests
{
    using static FormatId;

    public class VideoFormatTests
    {
        [Theory]
        [InlineData(_3GP, "3gp")]
        [InlineData(Avi, "avi")]
        // [InlineData(Hevc, "hevc")]
        [InlineData(Mp4, "m4v")]
        [InlineData(Matroska, "mkv")]
        [InlineData(WebM, "webm")]
        [InlineData(Ogg, "ogv")]
        public void VideoFormats(FormatId id, string extension)
        {
            Assert.Equal(extension, id.GetVideoFormat());
        }
    }
}