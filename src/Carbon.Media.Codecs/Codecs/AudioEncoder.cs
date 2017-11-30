using System;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class AudioEncoder : Encoder
    {
        public AudioEncoder(CodecId id)
            : base(id) { }

        internal AudioEncoder(AVCodecContext* context)
            : base(context) { }

        public virtual int[] SampleRates => Array.Empty<int>();

        public virtual SampleFormat[] SampleFormats => Array.Empty<SampleFormat>();

        public AudioFormatInfo GetFormat()
        {
            return new AudioFormatInfo(Context.SampleFormat, context.ChannelLayout, context.SampleRate);
        }

        public bool SupportsSampleRate(int sampleRate)
        {
            foreach (var r in SampleRates)
            {
                if (r == sampleRate) return true;
            }

            return false;
        }

        public bool SupportsSampleFormat(SampleFormat sampleFormat)
        {
            foreach (var f in SampleFormats)
            {
                if (f == sampleFormat) return true;
            }

            return false;
        }


        public void SetFormat(AudioFormatInfo format)
        {
            Validate(format);

            Context.SampleFormat  = format.SampleFormat;
            Context.SampleRate    = format.SampleRate;
            Context.ChannelLayout = format.ChannelLayout;
            Context.ChannelCount  = format.ChannelCount;

            Context.TimeBase = new Rational(1, format.SampleRate);
        }

        private void Validate(AudioFormatInfo format)
        {
            // TODO: Validate channelLayout

            if (!SupportsSampleFormat(format.SampleFormat))
            {
                throw new Exception($"{this.GetType().Name} does not support sampleFormat:" + format.SampleFormat);
            }

            if (!SupportsSampleRate(format.SampleRate))
            {
                throw new Exception($"{this.GetType().Name} does not support sampleRate:" + format.SampleFormat);
            }
        }
    }
}