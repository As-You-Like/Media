using System;
using System.Runtime.InteropServices;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class Codec : ICodec, IDisposable
    {
        protected AVCodec* pointer;
        protected CodecContext context;
        private bool isDisposed = false;
        private bool isOpen = false;

        public Codec(CodecId id, CodecType type)
        {
            Id = id;
            Type = type;
            this.pointer = Get(id, type);
        }

        protected Codec(AVCodecContext* context, CodecType type)
        {
            Id = (context->codec_id).ToCodecId();
            Type = type;

            this.pointer = context->codec;

            if (pointer == null)
            {
                pointer = Get(Id, Type);
            }

            this.context = new CodecContext(context);
        }

        public CodecId Id { get; }

        public CodecType Type { get; }

        public AVCodec* Pointer => pointer;

        public CodecContext Context => context;

        public MediaStream Stream { get; private set; }

        public string Name => Marshal.PtrToStringAnsi((IntPtr)pointer->name);

        public void Initialize(MediaStream stream)
        {
            if (this.context != null)
            {
                throw new Exception("Already Initialized");
            }

            Stream = stream ?? throw new ArgumentNullException(nameof(stream));

            this.context = new CodecContext(stream.Pointer->codec);

            //  context.Pointer->codec = this.pointer
        }

        public void Initialize()
        {
            if (this.context != null)
            {
                throw new Exception("Already Initialized");
            }

            this.context = new CodecContext(this);
        }

        public CodecCapabilities Capabilities
        {
            get => (CodecCapabilities)pointer->capabilities;
        }

        public virtual void Open()
        {
            InternalOpen();
        }

        protected void InternalOpen(AvDictionary options = null)
        {
            if (isOpen)
            {
                Console.WriteLine($"{this.GetType().Name} is already open");

                return;
            }

            if (context is null)
            {
                throw new Exception($"Uninitialized ({Id} + {Type})");
            }

            isOpen = true;


            if (ffmpeg.avcodec_is_open(context.Pointer) > 0)
            {
                Console.WriteLine("ALREADY OPEN");
            }

            if (options != null)
            {
                fixed (AVDictionary** o = &options.Pointer)
                {
                    ffmpeg.avcodec_open2(context.Pointer, pointer, o).EnsureSuccess();
                }

                options.Dispose();
            }
            else
            {
                ffmpeg.avcodec_open2(context.Pointer, pointer, options: null).EnsureSuccess();
            }
        }

        public static Codec Create(MediaStream stream, CodecType type)
        {
            Codec codec;

            switch (type)
            {
                case CodecType.Decoder: codec = Decoder.Create(stream.Pointer->codec); break;
                case CodecType.Encoder: codec = Encoder.Create(stream.Pointer->codec); break;

                default: throw new Exception("Invalid codec type:" + type);
            }

            codec.Stream = stream;

            return codec;

        }
        public static Codec Create(AVCodecContext* context, CodecType type)
        {
            switch (type)
            {
                case CodecType.Decoder: return Decoder.Create(context);
                case CodecType.Encoder: return Encoder.Create(context);

                default: throw new Exception("Invalid type:" + type);
            }
        }

        public void Dispose()
        {
            if (isDisposed) return;

            // Console.WriteLine("Disposing Codec");

            // ffmpeg.avcodec_close(context.Pointer);

            context?.Dispose();

            pointer = null;
            context = null;
            isDisposed = true;
        }


        #region Options

        public void SetOption(string key, string value)
        {
            ffmpeg.av_opt_set(context.Pointer->priv_data, key, value, 0);
        }

        #endregion


        #region Passthrough

        public Rational TimeBase => Context.TimeBase;

        public BitRate? BitRate => context.BitRate;

        #endregion

        #region Helpers

        private static AVCodec* Get(CodecId id, CodecType type)
        {
            switch (type)
            {
                case CodecType.Encoder : return ffmpeg.avcodec_find_encoder(id.ToAVCodecID());
                default                : return ffmpeg.avcodec_find_decoder(id.ToAVCodecID());
            }
        }

        #endregion
    }
}