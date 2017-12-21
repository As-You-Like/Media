using System;
using System.Collections.Generic;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    internal static class AudioFormatHelper
    {
        public unsafe static int GetBufferSize(in this AudioFormatInfo format, int sampleCount)
        {
            #region Preconditions
            
            if (sampleCount <= 0)
                throw new ArgumentException("Must be > 0");

            #endregion

            return ffmpeg.av_samples_get_buffer_size(
                linesize    : null,
                nb_channels : format.ChannelCount,
                nb_samples  : sampleCount,
                sample_fmt  : format.SampleFormat.ToAVFormat(),
                align       : 0
            );
        }

        public unsafe static SampleFormat[] GetSampleFormats(CodecId codecId)
        {
            var codec = ffmpeg.avcodec_find_encoder((AVCodecID)codecId);

            var result = new List<SampleFormat>();

            // 0 terminated
            for (var p = codec->sample_fmts; *p != AVSampleFormat.AV_SAMPLE_FMT_NONE; p++)
            {
                result.Add((*p).ToFormat());
            }

            return result.Count > 0 ? result.ToArray() : Array.Empty<SampleFormat>(); 
        }

        public static unsafe int[] GetSupportedSampleRates(CodecId codecId)
        {
            var codec = ffmpeg.avcodec_find_encoder((AVCodecID)codecId);

            var result = new List<int>();

            // 0 terminated
            for (var p = codec->supported_samplerates; *p != 0; p++)
            {
                result.Add(*p);
            }
            
            return result.Count > 0 ? result.ToArray() : Array.Empty<int>();
        }

        public static unsafe ChannelLayout[] GetSupportedChannelLayouts(CodecId codecId)
        {
            var encoder = ffmpeg.avcodec_find_encoder((AVCodecID)codecId);

            if (encoder->channel_layouts == null) return Array.Empty<ChannelLayout>();

            var result = new List<ChannelLayout>();

            // 0 terminated
            for (var p = encoder->channel_layouts; *p != 0; p++)
            {
                result.Add((ChannelLayout)(*p));
            }

            return result.Count > 0 ? result.ToArray() : Array.Empty<ChannelLayout>();
        }
    }
}