using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public enum CodecCapabilities : long
    {
        None                 = 0,
        Dr1                  = ffmpeg.AV_CODEC_CAP_DR1,
        Truncated            = ffmpeg.AV_CODEC_CAP_TRUNCATED,

        /// <summary>
        /// Encoder or decoder requires flushing with NULL input at the end in order to give the complete and correct output.
        /// </summary>
        Delay                = ffmpeg.AV_CODEC_CAP_DELAY,
        Subframes            = ffmpeg.AV_CODEC_CAP_SUBFRAMES,
        Experimental         = ffmpeg.AV_CODEC_CAP_EXPERIMENTAL,
        FrameThreads         = ffmpeg.AV_CODEC_CAP_FRAME_THREADS,
        IntraOnly            = ffmpeg.AV_CODEC_CAP_INTRA_ONLY,
        Lossless             = ffmpeg.AV_CODEC_CAP_LOSSLESS,
        HardwareAcceleration = ffmpeg.AV_CODEC_CAP_HARDWARE,

        /// <summary>
        /// Codec can be fed a final frame with a smaller size.
        /// </summary>
        SmallLastFrame = ffmpeg.AV_CODEC_CAP_SMALL_LAST_FRAME
    }

}
