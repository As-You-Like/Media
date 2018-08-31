using System.Collections.Generic;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class VideoEncoder : Encoder
    {
        public VideoEncoder(CodecId id)
            : base(id) { }

        internal VideoEncoder(AVCodecContext* context)
            : base(context) { }

        #region Options

        public int MaxBFrames
        {
            get => Context.MaxBFrames;
            set => Context.MaxBFrames = value;
        }

        #endregion

        public Rational[] SupportedFrameRates
        {
            get
            {
                var list = new List<Rational>();
                
            
                var i = 0;

                while (i < 100)
                {
                    AVRational rate = pointer->supported_framerates[i];

                    // {0,0} terminated
                    if (rate.den == 0 && rate.num == 0)
                    {
                        break;
                    }
                    else
                    {
                        list.Add(rate.ToRational());
                    }

                    i++;
                }

                return list.ToArray();
            }
        }

        public PixelFormat[] SupportedPixelFormats
        {
            get
            {
                var list = new List<PixelFormat>();

                // 0 terminated
                for (var p = pointer->pix_fmts; *p != AVPixelFormat.AV_PIX_FMT_NONE; p++)
                {
                    list.Add((*p).ToFormat());
                }

                return list.ToArray();
            }
        }
    }
}