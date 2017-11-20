using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe abstract class Codec : ICodec, IDisposable
    {
        protected AVCodec* pointer;
        protected CodecContext context;

        public Codec(CodecId id)
        {
            Id = id;

            this.pointer = ffmpeg.avcodec_find_decoder((AVCodecID)id);

            this.context = new CodecContext(this);
        }

        public CodecId Id { get; }

        public AVCodec* Pointer => pointer;

        public CodecContext Context => context;
        
        public string Name => Marshal.PtrToStringAnsi((IntPtr)pointer->name);
        
        public void Open()
        {
            int result = ffmpeg.avcodec_open2(context.Pointer, pointer, options: null);

            if (result < 0) throw new FFmpegException(result);
        }

        public void Close()
        {
            ffmpeg.avcodec_close(this.context.Pointer);
        }

        public void Flush()
        {
          
        }

        // SendFrame
        // SendPacket
        // RecieveFrame
        // RecievePacket
        // Flush

        public void Dispose()
        {
            context.Dispose();            
        }
    }

    public abstract class AudioCodec : Codec
    {
        public AudioCodec(CodecId id)
            : base(id) { }

        public int[] SupportedSampleRates { get; set; }

        public ChannelLayout[] SupportedChannelLayouts { get; set; }

    }

    public abstract class VideoCodec : Codec
    {
        public VideoCodec(CodecId id)
            : base(id) { }

        public Rational[] SupportedFrameRates { get; set; }

        public PixelFormat[] SupportedPixelFormats { get; set; }
    }
}