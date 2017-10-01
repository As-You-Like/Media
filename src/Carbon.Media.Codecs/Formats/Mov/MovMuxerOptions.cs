using System;

namespace Carbon.Media.Formats
{
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
}

/// Mp4
/// Ismv