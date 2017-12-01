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
       
        public int SampleRate => Codec.Context.SampleRate;

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