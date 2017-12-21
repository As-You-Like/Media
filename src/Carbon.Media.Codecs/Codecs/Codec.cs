using System;
using System.Runtime.InteropServices;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class Codec : ICodec, IDisposable
    {
        protected AVCodec* pointer;
        protected CodecContext context;

        private bool isOpen = false;
        private readonly CodecType type;

        public Codec(CodecId id, CodecType type)
        {
            Id = id;

            this.type = type;
            this.pointer = Get(id, type);
            
            this.context = new CodecContext(this);
        }

        protected Codec(AVCodecContext* context, CodecType type)
        {
            this.Id = (CodecId)context->codec_id;

            this.type = type;

            this.pointer = context->codec;

            this.context = new CodecContext(context, this);
        }
        
        public CodecId Id { get; }

        public AVCodec* Pointer => pointer;

        public CodecContext Context => context;
        
        public MediaStream Stream { get; set; }

        public string Name => Marshal.PtrToStringAnsi((IntPtr)pointer->name);

        public CodecCapabilities Capabilities
        {
            get => (CodecCapabilities)pointer->capabilities;
        }

        public void Initialize()
        {
            if (pointer != null)
            {
                throw new Exception("Codec is already initialized");
            }

            this.pointer = Get(Id, type);

            if (pointer == null)
            {
                throw new Exception($"Could not find {type} for: " + Id);
            }

            context.Pointer->codec = this.pointer;
        }

        public void Open()
        {
            Open(null);
        }

        internal void Open(AvDictionary options)
        {
            if (isOpen)
            {
                Console.WriteLine("already open");

                return;
            }

            if (pointer == null)
            {
                Initialize();
            }

            if (options != null)
            {
                fixed (AVDictionary** o = &options.Pointer)
                {
                    ffmpeg.avcodec_open2(context.Pointer, pointer, o).EnsureSuccess();
                }
            }
            else
            {
                ffmpeg.avcodec_open2(context.Pointer, pointer, options: null).EnsureSuccess();
            }

            isOpen = true;
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

        public virtual void Cleanup()
        {
        }

        public void Dispose()
        {
            if (context != null)
            {
                ffmpeg.avcodec_close(context.Pointer); // does not dispose the context

                context.Dispose();

                pointer = null;

                context = null;

                Cleanup();
            }
        }

        #region Passthrough

        public Rational TimeBase => Context.TimeBase;

        public BitRate? BitRate => context.BitRate;

        #endregion

        #region Helpers

        private static AVCodec* Get(CodecId id, CodecType type)
        {
            switch (type)
            {
                case CodecType.Encoder  : return ffmpeg.avcodec_find_encoder((AVCodecID)id);
                default                 : return ffmpeg.avcodec_find_decoder((AVCodecID)id);
            }
        }

        #endregion
    }
}