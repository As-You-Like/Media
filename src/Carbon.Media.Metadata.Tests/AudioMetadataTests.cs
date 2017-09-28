using System;
using System.IO;
using Carbon.Json;
using ProtoBuf;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class AudioMetadataTests
    {
        [Fact]
        public void Test1()
        {
            var audio = new AudioMetadata
            {
                Format = AudioFormat.Aac,
                ChannelCount = 2,
                Duration = TimeSpan.FromSeconds(30)
            };

            // TODO: format should be "aac"

            var output = new MemoryStream();

            Serializer.Serialize(output, audio);

            output.Position = 0;

            var audio2 = Serializer.Deserialize<AudioMetadata>(output);

            Assert.Equal(AudioFormat.Aac, audio2.Format);
            Assert.Equal(TimeSpan.FromSeconds(30), audio2.Duration);

            Assert.Equal(@"{
  ""format"": ""Aac"",
  ""duration"": ""00:00:30"",
  ""channelCount"": 2
}", JsonObject.FromObject(audio).ToString());
        }
    }
}