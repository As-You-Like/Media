using System;
using Carbon.Media.Codecs;
using Carbon.Media.Formats;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class AudioStream : MediaStream, IAudio
    {
        public AudioStream(AVStream* pointer)
            : base(pointer) { }

        public int ChannelCount => Codec.Context.ChannelCount;

        public ChannelLayout ChannelLayout => Codec.Context.ChannelLayout;

        public SampleFormat SampleFormat => Codec.Context.SampleFormat;

        /// <summary>
        /// The sampling rate defines the number of samples per second
        /// taken from a continuous signal to make a discrete signal.
        /// Measured in hertz (Hz)
        /// </summary>
        public int SampleRate => Codec.Context.SampleRate;

        /// <summary>
        /// The block alignment, in bytes, of the stream.
        /// note: PCM formats = audio channels * bytes per sample
        /// </summary>
        public int BlockAlignment => Codec.Context.BlockAlignment;

        public override MediaType Type => MediaType.Audio;

        public static AudioStream Create(Format format, Codec codec)
        {
            var stream = ffmpeg.avformat_new_stream(format.Context.Pointer, codec.Pointer);

            if (stream->codec == null)
            {
                throw new Exception("missing codec");
            }

            return new AudioStream(stream);
        }

        #region IAudio

        ICodec IAudio.Codec => Codec;

        TimeSpan? IAudio.Duration => base.Duration?.TimeSpan;

        #endregion
    }
}

/// 8,000 Hz     : Telephone
/// 44,100 Hz    : Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
/// 48,000 Hz    : TV, DVD, and films. 
/// 96,000 Hz    : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 192,000 Hz   : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 2,822,400 Hz : SACD
// Channels { L, R, C }