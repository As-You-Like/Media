using Xunit;

namespace Carbon.Media.Tests
{
    using static MediaContainerType;

    public class ContainerTests
    {
        [Theory]
        [InlineData(_3GP, "3gp")]
        [InlineData(Avi, "avi")]
        [InlineData(Flv, "flv")]
        [InlineData(Mp4, "mp4")]
        [InlineData(Matroska, "mkv")]
        [InlineData(WebM, "webm")]
        [InlineData(Ogg, "ogv")]
        public void VideoFormats(MediaContainerType container, string format)
        {
            Assert.Equal(format, container.GetVideoFormat());
        }

        [Theory]
        [InlineData(Aiff, "aiff")]
        [InlineData(Mp4, "m4a")]
        [InlineData(Matroska, "mka")]
        [InlineData(Ogg, "oga")]
        public void AudioFormats(MediaContainerType container, string format)
        {
            Assert.Equal(format, container.GetAudioFormat());
        }
    }
}