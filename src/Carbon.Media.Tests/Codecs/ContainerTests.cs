using Xunit;

namespace Carbon.Media.Tests
{
    using static ContainerId;

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
        public void VideoFormats(ContainerId container, string format)
        {
            Assert.Equal(format, container.GetVideoFormat());
        }

        [Theory]
        [InlineData(Aiff, "aiff")]
        [InlineData(Mp4, "m4a")]
        [InlineData(Matroska, "mka")]
        [InlineData(Ogg, "oga")]
        public void AudioFormats(ContainerId container, string format)
        {
            Assert.Equal(format, container.GetAudioFormat());
        }
    }
}