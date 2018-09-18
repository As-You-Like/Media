using Xunit;

namespace Carbon.Media.Tests
{
    using static FormatId;

    public class AudioFormatTests
    {
        [Theory]
        [InlineData(Aac,  "audio/aac")]
        [InlineData(Aiff, "audio/aiff")]
        [InlineData(M4a,  "audio/mp4")]
        [InlineData(Mp3,  "audio/mpeg")]
       //  [InlineData(Mka,  "audio/mka")]
        [InlineData(Oga,  "audio/ogg")] // Can contain Flac, Vorbis, ...
        [InlineData(Opus, "audio/opus")]
        public void CanGetMime(FormatId format, string mediaType)
        {
            var mime = Mime.FromFormat(format);

            Assert.Equal(mediaType, mime.Name);
        }
    }
}