using System;

namespace Carbon.Media.Formats
{
    public sealed class Mp4MuxerOptions
    {
        /// <summary>
        /// Reserves space for the moov atom at the beginning of the file instead of placing the moov atom at the end
        /// </summary>
        public int MoovSize { get; set; }

        public Mp4Flags MovFlags { get; set; }

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