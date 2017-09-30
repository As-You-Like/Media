using System;
using Carbon.Json;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class VideoMetadataTests
    {
        [Fact]
        public void Test1()
        {
            var video = new VideoMetadata {
                Format    = "mp4",
                FrameRate = new Rational(30000, 1001),
                Codec     = "h.265",
                Duration  = TimeSpan.FromSeconds(30)
            };

            Assert.Equal(@"{
  ""format"": ""mp4"",
  ""codec"": ""h.265"",
  ""duration"": ""00:00:30"",
  ""frameRate"": ""30000\/1001""
}", JsonObject.FromObject(video).ToString());
        }
    }
}