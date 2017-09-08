using System;

namespace Carbon.Media.Containers
{
    public class MovMuxer : Muxer
    {
        private readonly MovMuxerOptions options;

        public MovMuxer(MovMuxerOptions options)
        {
            this.options = options;
        }


        // StartNewFragment (av_write_frame(ctx, NULL))
    }

    public class MovMuxerOptions
    {
        /// <summary>
        /// Reserves space for the moov atom at the beginning of the file instead of placing the moov atom at the end
        /// </summary>
        public int MoovSize { get; set; }

        public MovFlags MovFlags { get; set; }

        public TimeSpan? FragmentDuration { get; set; }

        public long? FragmentSize { get; set; }

        /// <summary>
        /// Don’t create fragments that are shorter than duration microseconds long.
        /// </summary>
        public TimeSpan MinFragmentDuration { get; set; }
    }

    public enum MovFlags
    {
        // Start a new fragment at each video keyframe
        FragKeyFrame,
        FragCustom,
        EmptyMoov,
        SeperateMoof,
        FastStart,
        RtphHint,
        DisableChpl,
        OmitTfhdOffset,
        DefaultBaseMoof
    }
}

/// Mp4
/// Ismv