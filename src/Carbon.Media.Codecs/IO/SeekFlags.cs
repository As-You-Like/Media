using System;

using FFmpeg.AutoGen;
namespace Carbon.Media.IO
{
    [Flags]
    public enum SeekFlags
    {
        SeekSet = 0,
        SeekCur = 1,
        SeekEnd = 2,
        SeekSize = ffmpeg.AVSEEK_SIZE,
        SeekForce = ffmpeg.AVSEEK_FORCE
    }
}