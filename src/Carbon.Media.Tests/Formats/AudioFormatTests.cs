using Xunit;

namespace Carbon.Media.Tests
{
    using static FormatId;

    public class AudioFormatTests
    {
        [Theory]
        [InlineData(Aac,  "audio/aac")]
        [InlineData(Alac, "audio/mp4")]
        [InlineData(Aiff, "audio/aiff")]
        [InlineData(Flac, "audio/flac")]
        [InlineData(M4a,  "audio/mp4")]
        [InlineData(Mp3,  "audio/mpeg")]
        [InlineData(Oga,  "audio/ogg")] // Can contain Flac, Vorbis, ...
        [InlineData(Opus, "audio/opus")]
        [InlineData(Wave, "audio/wav")]
        public void CanGetMime(FormatId format, string mediaType)
        {
            var mime = Mime.FromFormat(format);

            Assert.Equal(mediaType, mime.Name);
        }

        [Theory]
        [InlineData(Aiff,       "aiff")]
        [InlineData(Mp4,        "m4a")]
        [InlineData(Mp3,        "mp3")]
        [InlineData(Matroska,   "mka")]
        [InlineData(Ogg,        "oga")]
        [InlineData(Opus,       "opus")]
        public void FormatToName(FormatId container, string format)
        {
            Assert.Equal(format, container.GetAudioFormat());
        }
    }
}