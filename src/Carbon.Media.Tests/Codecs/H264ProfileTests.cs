using Xunit;

namespace Carbon.Media.Codecs.Tests
{
    public class H264ProfileTests
    {
        [Fact]
        public void Parse()
        {
            var bp_30   = new H264Profile(H264ProfileType.BP, 30);
            var main_30 = new H264Profile(H264ProfileType.MP, 30);
            var high_30 = new H264Profile(H264ProfileType.HiP, 30);

            Assert.Equal(bp_30,  CodecInfo.Parse("avc1.42001e")); // 66:0:30
            Assert.Equal(new H264Profile(H264ProfileType.BP, 31),  CodecInfo.Parse("avc1.42001f")); // 66:0:31
            Assert.Equal(new H264Profile(H264ProfileType.BP, 32),  CodecInfo.Parse("avc1.420020")); // 66:0:32
            Assert.Equal(high_30, CodecInfo.Parse("avc1.64001E")); // 100:0:30
            Assert.Equal(new H264Profile(H264ProfileType.HiP, 41),CodecInfo.Parse("avc1.640029")); // 100:0:41

            Assert.Equal("avc1.42001e", bp_30.ToString());
            Assert.Equal("avc1.4d001e", main_30.ToString());
            Assert.Equal("avc1.64001e", high_30.ToString());
        }

        [Fact]
        public void ParseShortcuts()
        {
            // Assert.Equal(H264Profile.Level0Simple,   CodecInfo.Parse("mp4v.20.9"));
            // Assert.Equal(H264Profile.Level0Advanced, CodecInfo.Parse("mp4v.20.240"));

            // Assert.Equal(H264Profile.Main,      H264Profile.Parse("main"));
            // Assert.Equal(H264Profile.Extended,  H264Profile.Parse("extended"));
            // Assert.Equal(H264Profile.High,      H264Profile.Parse("high"));
        }

        [Fact]
        public void DoesNotDropMiddle()
        {
            Assert.Equal("avc1.4d401e", H264Profile.Parse("avc1.4d401e").Name);

        }
    }
}