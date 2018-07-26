using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    [Flags]
    internal enum FormatFlags : int
    {
        /// <summary>
        /// Generate missing pts even if it requires parsing future frames.
        /// </summary>
        GenPts = ffmpeg.AVFMT_FLAG_GENPTS,

        /// <summary>
        /// Ignore index.
        /// </summary>
        IgnIdx = ffmpeg.AVFMT_FLAG_IGNIDX,

        /// <summary>
        /// Do not block when reading packets from input.
        /// </summary>
        NonBlock = ffmpeg.AVFMT_FLAG_NONBLOCK,

        /// <summary>
        /// Ignore DTS on frames that contain both DTS &amp; PTS
        /// </summary>
        IgnDts = ffmpeg.AVFMT_FLAG_IGNDTS,

        /// <summary>
        /// Do not infer any values from other values, just return what is stored in the container
        /// </summary>
        NoFillIn = ffmpeg.AVFMT_FLAG_NOFILLIN,


        /// <summary>
        /// Do not use AVParsers, you also must set AVFMT_FLAG_NOFILLIN as the fillin code works on frames and no parsing -> no frames. 
        /// Also seeking to frames can not work if parsing to find frame boundaries has been disabled
        /// </summary>
        NoParse = ffmpeg.AVFMT_FLAG_NOPARSE,

        /// <summary>
        /// Do not buffer frames when possible
        /// </summary>
        NoBuffer = ffmpeg.AVFMT_FLAG_NOBUFFER,
        
        /// <summary>
        /// The caller has supplied a custom AVIOContext, don't avio_close() it.
        /// </summary>
        CustomIO = ffmpeg.AVFMT_FLAG_CUSTOM_IO,
        
        /// <summary>
        /// Discard frames marked corrupted
        /// </summary>
        DiscardCorrupt = ffmpeg.AVFMT_FLAG_DISCARD_CORRUPT,

        /// <summary>
        /// Flush the AVIOContext every packet.
        /// </summary>
        FlushPackets = ffmpeg.AVFMT_FLAG_FLUSH_PACKETS,

        /// <summary>
        /// Enable RTP MP4A-LATM payload
        /// </summary>
        Mp4aLatm = ffmpeg.AVFMT_FLAG_MP4A_LATM,

        /// <summary>
        /// try to interleave outputted packets by dts (using this flag can slow demuxing down)
        /// </summary>
        SortDts = ffmpeg.AVFMT_FLAG_SORT_DTS,

        /// <summary>
        /// Enable use of private options by delaying codec open (this could be made default once all code is converted)
        /// </summary>
        PrivOpt = ffmpeg.AVFMT_FLAG_PRIV_OPT,

        /// <summary>
        /// Don't merge side data but keep it separate.
        /// </summary>
        KeepSideData = ffmpeg.AVFMT_FLAG_KEEP_SIDE_DATA,

        /// <summary>
        /// Enable fast, but inaccurate seeks for some formats
        /// </summary>
        FastSeek = ffmpeg.AVFMT_FLAG_FAST_SEEK
    }
}
