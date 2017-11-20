using System;

namespace Carbon.Media.Codecs
{
    public abstract class AacEncoder : AudioEncoder
    {
        private readonly AacEncoderOptions options;

        public AacEncoder(AacEncoderOptions options)
            : base(CodecId.Aac)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            /*
            if (!InFormat.Equals(OutFormat))
            {
                resampler = new AudioResampler(InFormat, OutFormat);
                tempFrame = new AudioFrame();
            }
            */

            Context.SampleFormat = options.SampleFormat;
            Context.SampleRate = options.SampleRate;
            Context.ChannelLayout = options.ChannelLayout;
            Context.BitRate = options.BitRate;
            // ChannelCount

          
            // var rates = codecContext->Flags;

           
            


        }

    }
}