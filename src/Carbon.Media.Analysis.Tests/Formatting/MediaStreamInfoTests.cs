using System;
using Carbon.Json;
using Carbon.Media.Metadata;
using Xunit;

namespace Carbon.Media.Analysis.Tests.Formatting
{
    public class MediaStreamInfoTests
    {
        [Fact]
        public void A()
        {
            var stream = new AudioStreamInfo {
                Codec         = CodecInfo.Create(CodecId.Aac, "LC").Name,
                ChannelLayout = "Stereo",
                Duration      = TimeSpan.FromMinutes(1),
                SampleRate    = 44100,
                StartTime     = TimeSpan.Zero,
                SampleFormat  = SampleFormat.F32
            };

            Assert.Equal(@"{
  ""type"": ""Audio"",
  ""codec"": ""mp4a.40.2"",
  ""duration"": ""00:01:00"",
  ""sampleFormat"": ""F32"",
  ""sampleRate"": 44100,
  ""channelLayout"": ""Stereo""
}", JsonObject.FromObject(stream).ToString());

        }

        [Fact]
        public void V()
        {
            var stream = new VideoStreamInfo
            {
                Codec = CodecInfo.Create(CodecId.H264, "high").Name,
                Duration = TimeSpan.FromMinutes(1),
                StartTime = TimeSpan.Zero,
                Width = 1920,
                Height = 1080
            };

            // throw new Exception(JsonObject.FromObject(stream).ToString());

            Assert.Equal(@"{
  ""type"": ""Video"",
  ""codec"": ""avc1.64001E"",
  ""duration"": ""00:01:00"",
  ""height"": 1080,
  ""width"": 1920
}", JsonObject.FromObject(stream).ToString());

        }
    }
}
