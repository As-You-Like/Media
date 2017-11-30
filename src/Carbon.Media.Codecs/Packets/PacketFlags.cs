using System;

namespace Carbon.Media
{
    [Flags]
    public enum PacketFlags
    {
        None     = 0,
        Keyframe = 0x0001,
        Corrupt  = 2,           // 0x0002
        Discard  = 4,
        Trusted  = 8
    }
}