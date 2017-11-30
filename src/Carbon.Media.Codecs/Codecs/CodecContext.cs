using System;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class CodecContext
    {
        protected AVCodecContext* pointer;

        public CodecContext(Codec codec)
        {
            Codec = codec ?? throw new ArgumentNullException(nameof(codec));

            this.pointer = ffmpeg.avcodec_alloc_context3(codec.Pointer);

            if (this.pointer == null)
            {
                throw new Exception("error allocating codec context");
            }

            ffmpeg.avcodec_get_context_defaults3(pointer, codec.Pointer); // set the defaults
        }

        public CodecContext(AVCodecContext* pointer, Codec codec)
        {
            if (pointer == null) throw new ArgumentNullException(nameof(pointer));

            Codec = codec ?? throw new ArgumentNullException(nameof(codec));

            this.pointer = pointer;

            pointer->codec = codec.Pointer;
        }

        public AVCodecContext* Pointer => pointer;

        public Codec Codec { get; }

        public int Flags
        {
            get => pointer->flags;
            set => pointer->flags = value;
        }

        public BitRate? BitRate
        {
            get => new BitRate(pointer->bit_rate);
            set => pointer->bit_rate = value.Value.Value;
        }

        public BitRate? BitrateTolerance
        {
            get => new BitRate(pointer->bit_rate_tolerance);
            set => pointer->bit_rate_tolerance = (int)value.Value.Value;
        }

        public Rational TimeBase
        {
            get => new Rational(pointer->time_base.num, pointer->time_base.den);
            set => pointer->time_base = value.ToAVRational();
        }

        public int Delay
        {
            get => pointer->delay;
            set => pointer->delay = value;
        }

        #region Audio

        public int SampleRate
        {
            get => pointer->sample_rate;
            set => pointer->sample_rate = value;
        }

        public SampleFormat SampleFormat
        {
            get => pointer->sample_fmt.ToFormat();
            set => pointer->sample_fmt = value.ToAVFormat();
        }

        public int ChannelCount
        {
            get => pointer->channels;
            set => pointer->channels = value;
        }

        public ChannelLayout ChannelLayout
        {
            get => (ChannelLayout)pointer->channel_layout;
            set => pointer->channel_layout = (ulong)value;
        }

        public int BlockAlignment
        {
            get => pointer->block_align;
        }

        // number of samples per channel in audio
        public int FrameSize => pointer->frame_size;

        #endregion

        #region Image / Video

        // public ColorSpace ColorSpace { get; }
        // ColorRange

        public PixelFormat PixelFormat
        {
            get => pointer->pix_fmt.ToFormat();
            set => pointer->pix_fmt = value.ToAVFormat();
        }

        public int Width
        {
            get => pointer->width;
            set => pointer->width = value;
        }

        public int Height
        {
            get => pointer->height;
            set => pointer->height = value;
        }

        public int CodedWidth => pointer->coded_width;

        public int CodedHeight => pointer->coded_height;

        public Rational AspectRatio
        {
            get => pointer->sample_aspect_ratio.ToRational();
            set => pointer->sample_aspect_ratio = value.ToAVRational();
        }

        public int MaxBFrames
        {
            get => pointer->max_b_frames;
            set => pointer->max_b_frames = value;
        }

        public float BQuantFactor
        {
            get => pointer->b_quant_factor;
            set => pointer->b_quant_factor = value;
        }

        public float BQuantOffset
        {
            get => pointer->b_quant_offset;
            set => pointer->b_quant_offset = value;
        }

        public float IQuantFactor
        {
            get => pointer->i_quant_factor;
            set => pointer->i_quant_factor = value;
        }

        public float IQuantOffset
        {
            get => pointer->i_quant_offset;
            set => pointer->i_quant_offset = value;
        }

        public float LumiMasking
        {
            get => pointer->lumi_masking;
        }


        public int GopSize
        {
            get => pointer->gop_size;
            set => pointer->gop_size = value;
        }
        

        // VIDEO
      
        // temporalCplxMasking
        // SpacialCplxMasking
        // PMasking
        // DarkMasking
        // PreditionMode
        // AspectRatio
        // DiaSize
        // LastPredicaators
        // PreMe
        // MePreComparision
        // PreDiaSize
        // MeSubpelQuality
        // MeRange
        // IntraQuantBias
        // InterQuantBias
        // ColorRange
        // ColorSpace

        // FrameRate
        // TimeBase
        // Compression
        // Quality
       


        #endregion

        public void Dispose()
        {
            if (pointer != null)
            {
                fixed (AVCodecContext** p = &pointer)
                {
                    ffmpeg.avcodec_free_context(p);
                }

                pointer = null;
            }
        }
    }
}