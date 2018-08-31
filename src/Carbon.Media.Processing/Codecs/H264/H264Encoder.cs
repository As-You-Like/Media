using System;

namespace Carbon.Media.Codecs
{
    public sealed class H264Encoder : VideoEncoder
    {
        private readonly H264EncodingParameters paramaters;

        public H264Encoder(H264EncodingParameters paramaters)
             : base(CodecId.H264)
        {
            this.paramaters = paramaters ?? throw new ArgumentNullException(nameof(paramaters));
        }

        public override void Open()
        {
            Context.PixelFormat = paramaters.PixelFormat;

            if (paramaters.TimeBase != null)
            {
                Context.TimeBase = paramaters.TimeBase.Value;
            }

            if (paramaters.AspectRatio != null)
            {
                Context.AspectRatio = paramaters.AspectRatio.Value;
            }

            Context.Width = paramaters.Width;
            Context.Height = paramaters.Height;

            base.Open();
        }
    }
}