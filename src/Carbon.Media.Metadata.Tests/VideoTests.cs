using System;
using Carbon.Json;

using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class VideoMetadataTests
    {
        [Fact]
        public void Serialize1()
        {
            var video = new VideoInfo {
                Format    = "mp4",
                FrameRate = new Rational(30000, 1001),
                Codec     = "h.265",
                Duration  = TimeSpan.FromSeconds(30)
            };

            var video2 = Helper.SerializeAndBack(video);

            Assert.Equal(30d, video.Duration.TotalSeconds);

            Assert.Equal(@"{
  ""format"": ""mp4"",
  ""codec"": ""h.265"",
  ""duration"": ""00:00:30"",
  ""frameRate"": ""30000\/1001""
}", JsonObject.FromObject(video).ToString());
        }
    }

    public class DocumentTests
    {
        [Fact]
        public void Serialize1()
        {
            var model = new DocumentInfo
            {
                Format = "pdf",
                Blob = new BlobInfo {  Size= 10345 },
                Pages = new[] {
                    new PageInfo(1000, 2000),
                    new PageInfo(1, 1) { Rotation = 90 }
                }
            };

            var convertBack = Helper.SerializeAndBack(model);

            Assert.Equal(@"{
  ""format"": ""pdf"",
  ""blob"": {
    ""size"": 10345
  },
  ""pages"": [
    {
      ""width"": 1000,
      ""height"": 2000
    },
    {
      ""width"": 1,
      ""height"": 1,
      ""rotation"": 90
    }
  ]
}", JsonObject.FromObject(model).ToString());
        }
    }
}