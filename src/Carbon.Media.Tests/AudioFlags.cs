
using Xunit;

namespace Carbon.Media.Tests
{
    using static ChannelLayout;

    public class AudioFlags
    {
        [Theory]
        [InlineData(FrontLeft,          1)]
        [InlineData(FrontRight,         2)]
        [InlineData(FrontCenter,        4)]
        [InlineData(LowFrequency,       8)]
        [InlineData(BackLeft,           0x000000010)]
        [InlineData(BackRight,          0x000000020)]
        [InlineData(FrontLeftOfCenter,  0x00000040)]
        [InlineData(FrontRightOfCenter, 0x00000080)]
        [InlineData(BackCenter,         0x00000100)]
        [InlineData(SideLeft,           0x00000200)]
        [InlineData(SideRight,          0x00000400)]
        [InlineData(TopCenter,          0x00000800)]
        [InlineData(TopBackCenter,      0x00010000)]
        [InlineData(TopBackRight,       0x00020000)]
        [InlineData(DownmixLeft,        0x20000000)]
        [InlineData(DownmixRight,       0x40000000)]
        public void EqualToFFmpeg(ChannelLayout channel, long value)
        {
            Assert.Equal(value, (long)channel);
        }

        [Theory]
        [InlineData(FrontLeft,            0x1)]
        [InlineData(FrontRight,           0x2)]
        [InlineData(FrontCenter,          0x4)]
        [InlineData(LowFrequency,         0x8)]
        [InlineData(BackLeft,             0x10)]
        [InlineData(BackRight,            0x20)]
        [InlineData(FrontLeftOfCenter,    0x40)]
        [InlineData(FrontRightOfCenter,   0x80)]
        [InlineData(BackCenter,           0x100)]
        [InlineData(SideLeft,             0x200)]
        [InlineData(SideRight,            0x400)]
        [InlineData(TopCenter,            0x800)]
        [InlineData(TopFrontLeft,         0x1000)]
        [InlineData(TopFrontCenter,       0x2000)]
        [InlineData(TopFrontRight,        0x4000)]
        [InlineData(TopBackLeft,          0x8000)]
        [InlineData(TopBackCenter,        0x10000)]
        [InlineData(TopBackRight,         0x20000)] 
        public void EqualToMediaFoundation(ChannelLayout channel, long value)
        {
            Assert.Equal(value, (long)channel);
        }
    }
}

