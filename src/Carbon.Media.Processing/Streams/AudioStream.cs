using System;
using Carbon.Media.Codecs;
using Carbon.Media.Formats;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class AudioStream : MediaStream, IAudio
    {
        internal AudioStream(AVStream* pointer)
            : base(pointer) { }

        internal AudioStream(AVStream* pointer, Codec codec)
            : base(pointer, codec) { }

        public int ChannelCount => Codec.Context.ChannelCount;

        public ChannelLayout ChannelLayout => Codec.Context.ChannelLayout;

        public SampleFormat SampleFormat => Codec.Context.SampleFormat;

        public int SampleRate => Codec.Context.SampleRate;

        public int BlockAlignment => Codec.Context.BlockAlignment;

        public override MediaStreamType Type => MediaStreamType.Audio;

        public static AudioStream Create(Format format, Codec codec)
        {
            if (format is null)
                throw new ArgumentNullException(nameof(format));

            if (codec is null)
                throw new ArgumentNullException(nameof(codec));

            // Adds the stream to the format
            // Note: this will also create the codec context
            AVStream* pointer = ffmpeg.avformat_new_stream(format.Context.Pointer, codec.Pointer);

            return new AudioStream(pointer, codec);
        }

        #region IAudio

        ICodec IAudio.Codec => Codec;

        TimeSpan? IAudio.Duration => base.Duration?.TimeSpan;

        #endregion
    }
}