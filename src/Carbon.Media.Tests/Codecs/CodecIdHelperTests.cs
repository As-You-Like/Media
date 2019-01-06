
using Xunit;

namespace Carbon.Media.Codecs.Tests
{
    public class CodecIdHelperTests
    {
        [Theory]
        [InlineData("av1",  CodecId.AV1)]
        [InlineData("h264", CodecId.H264)]
        [InlineData("hevc", CodecId.Hevc)]
        [InlineData("vp8",  CodecId.Vp8)]
        [InlineData("vp9",  CodecId.Vp9)]
        public void Parse(string name, CodecId id)
        {
            Assert.Equal(id, CodecIdHelper.Parse(name));
        }   
    }
}