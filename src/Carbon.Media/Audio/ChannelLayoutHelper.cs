namespace Carbon.Media
{
    public static class ChannelLayoutHelper
    {
        public static bool TryParse(string text, out ChannelLayout layout)
        {
            switch (text)
            {
                case "mono"   : layout = ChannelLayout.Mono;            return true;
                case "stereo" : layout = ChannelLayout.Stereo;          return true;
                case "downmix": layout = ChannelLayout.StereoDownmix;   return true;
                case "2.1"    : layout = ChannelLayout._2_1;            return true;
                case "3.0"    : layout = ChannelLayout._3_0;            return true;
                case "3.1"    : layout = ChannelLayout._3_1;            return true;
                case "4.0"    : layout = ChannelLayout._4_0;            return true;
                case "5.0"    : layout = ChannelLayout._5_0;            return true;
                case "5.1"    : layout = ChannelLayout._5_1;            return true;
                case "6.0"    : layout = ChannelLayout._6_0;            return true;
                case "7.1"    : layout = ChannelLayout._7_1;            return true;
            }

            layout = default;

            return false;
        }

        public static int GetChannelCount(this ChannelLayout layout)
        {
            return CountSetBits((ulong)layout);
        }

        private static int CountSetBits(ulong value)
        {
            // TODO: Use popcnt when available

            value = value - ((value >> 1) & 0x5555555555555555UL);
            value = (value & 0x3333333333333333UL) + ((value >> 2) & 0x3333333333333333UL);
            return (int)(unchecked(((value + (value >> 4)) & 0xF0F0F0F0F0F0F0FUL) * 0x101010101010101UL) >> 56);
        }
    }
}