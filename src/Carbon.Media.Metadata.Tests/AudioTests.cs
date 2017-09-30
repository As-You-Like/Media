using System;
using Carbon.Json;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class AudioMetadataTests
    {
        [Fact]
        public void Test1()
        {
            var audio = new AudioMetadata {
                Format        = "aac",
                Codec         = "mp4a.40.2",
                ChannelCount  = 2,
                ChannelLayout = ChannelLayout.Stereo,
                Duration      = TimeSpan.FromSeconds(30)
            };
            
            var audio2 = Helper.SerializeAndBack(audio);

            Assert.Equal("aac",                    audio2.Format);
            Assert.Equal("mp4a.40.2",              audio2.Codec);
            Assert.Equal(TimeSpan.FromSeconds(30), audio2.Duration);

            Assert.Equal(@"{
  ""format"": ""aac"",
  ""codec"": ""mp4a.40.2"",
  ""duration"": ""00:00:30"",
  ""channelCount"": 2,
  ""channelLayout"": ""Stereo""
}", JsonObject.FromObject(audio).ToString());
        }
    }
}