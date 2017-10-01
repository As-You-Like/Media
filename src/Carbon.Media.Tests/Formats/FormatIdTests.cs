using Xunit;

namespace Carbon.Media.Tests
{
    using static FormatId;

    public class FormatIdTests
    {
        [Theory]
        [InlineData(_3GP,     "3gp")]
        [InlineData(Avi,      "avi")]
        [InlineData(Flv,      "flv")]
        [InlineData(Mp4,      "mp4")]
        [InlineData(Matroska, "mkv")]
        [InlineData(WebM,     "webm")]
        [InlineData(Ogg,      "ogv")]
        public void VideoFormats(FormatId id, string extension)
        {
            Assert.Equal(extension, id.GetVideoFormat());
        }

        [Theory]
        [InlineData(Aiff,     "aiff")]
        [InlineData(Mp4,      "m4a")]
        [InlineData(Mp3,      "mp3")]
        [InlineData(Matroska, "mka")]
        [InlineData(Ogg,      "oga")]
        public void AudioFormats(FormatId container, string format)
        {
            Assert.Equal(format, container.GetAudioFormat());
        }
    }
}