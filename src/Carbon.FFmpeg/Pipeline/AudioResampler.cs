using System;
using System.Collections.Generic;
using Carbon.Media;
using FFmpeg.AutoGen;
using FFmpeg.Helpers;
using static FFmpeg.AutoGen.ffmpeg;

namespace FFmpeg
{
    public unsafe class AudioResampler
    {
        private static readonly Dictionary<AudioFormat, AudioResampler> planarResamplers = new Dictionary<AudioFormat, AudioResampler>();

        private SwrContext* ctx;

        public AudioStream Source { get; }
        public AudioStream Destination { get; }

        public AudioResampler(AudioStream src, AudioStream dst)
        {
            Source      = src ?? throw new ArgumentNullException(nameof(src));
            Destination = dst ?? throw new ArgumentNullException(nameof(dst));

       
            ctx = swr_alloc_set_opts(null,
                out_ch_layout    : (long)Destination.ChannelLayout,
                out_sample_fmt   : Destination.SampleFormat.ToAVSampleFormat(),
                out_sample_rate  : Destination.SampleRate,
                in_ch_layout     : (long)Source.ChannelLayout,
                in_sample_fmt    : Source.SampleFormat.ToAVSampleFormat(),
                in_sample_rate   : Source.SampleRate,
                log_offset       : 0,
                log_ctx          : null
            );

        }
        
    }
}
