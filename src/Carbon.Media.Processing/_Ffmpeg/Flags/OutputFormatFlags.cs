
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    internal enum OutputFormatFlags
    {
        GlobalHeader = ffmpeg.AVFMT_GLOBALHEADER,
        NeedNumber   = ffmpeg.AVFMT_NEEDNUMBER,
        NoBinSearch  = ffmpeg.AVFMT_NOBINSEARCH,
        NoDimensions = ffmpeg.AVFMT_NODIMENSIONS,
        NoFile       = ffmpeg.AVFMT_NOFILE,
        NoGenSearch  = ffmpeg.AVFMT_NOGENSEARCH,
        NoStreams    = ffmpeg.AVFMT_NOSTREAMS,
        NoTimestamps = ffmpeg.AVFMT_NOTIMESTAMPS,
        NoByteSeek   = ffmpeg.AVFMT_NO_BYTE_SEEK,
        NoBuffer     = ffmpeg.AVFMT_FLAG_NOBUFFER // 64
    }
}
