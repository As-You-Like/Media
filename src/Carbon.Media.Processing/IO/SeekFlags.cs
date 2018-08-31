using System;

using FFmpeg.AutoGen;
namespace Carbon.Media.IO
{
    [Flags]
    public enum SeekFlags
    {
        SeekSet = 0, // Begin
        SeekCur = 1, // Current
        SeekEnd = 2, // End
        SeekSize = ffmpeg.AVSEEK_SIZE,
        SeekForce = ffmpeg.AVSEEK_FORCE
    }
}