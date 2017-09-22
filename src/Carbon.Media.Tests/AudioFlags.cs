
using Xunit;

namespace Carbon.Media.Tests
{
    public class AudioFlags
    {
        [Theory]
        [InlineData(ChannelLayout.FrontLeft,          1)]
        [InlineData(ChannelLayout.FrontRight,         2)]
        [InlineData(ChannelLayout.FrontCenter,        4)]
        [InlineData(ChannelLayout.LowFrequency,       8)]
        [InlineData(ChannelLayout.BackLeft,           0x000000010)]
        [InlineData(ChannelLayout.BackRight,          0x000000020)]
        [InlineData(ChannelLayout.FrontLeftOfCenter,  0x00000040)]
        [InlineData(ChannelLayout.FrontRightOfCenter, 0x00000080)]
        [InlineData(ChannelLayout.BackCenter,         0x00000100)]
        [InlineData(ChannelLayout.SideLeft,           0x00000200)]
        [InlineData(ChannelLayout.SideRight,          0x00000400)]
        [InlineData(ChannelLayout.TopCenter,          0x00000800)]
        [InlineData(ChannelLayout.TopBackCenter,      0x00010000)]
        [InlineData(ChannelLayout.TopBackRight,       0x00020000)]
        [InlineData(ChannelLayout.DownmixLeft,        0x20000000)]
        [InlineData(ChannelLayout.DownmixRight,       0x40000000)]
        public void EqualToFFmpeg(ChannelLayout channel, long value)
        {
            Assert.Equal(value, (long)channel);
        }
    }
}

