using System;
using Carbon.Media;
using FFmpeg.AutoGen;

using Carbon.Media.Codecs;

namespace FFmpeg
{
    using static ffmpeg;
    public unsafe sealed class AvCodecContext : CodecContext
    {
        private readonly AVCodecContext* pointer;

        private bool isDisposed = false;

        public AvCodecContext(AVCodecContext* pointer)
            : base()
        {
            this.pointer = pointer;
        }

        public AVCodecContext* Pointer => pointer;

        public AvFrame CodedFrame => new AvFrame(pointer->coded_frame);

        public override BitRate BitRate => new BitRate(pointer->bit_rate);

        public override Rational TimeBase => new Rational(pointer->time_base.num, pointer->time_base.den);

        public override int ChannelCount => pointer->channels;

        public void Close()
        {
            if (isDisposed) throw new ObjectDisposedException("AvCodec is disposed");

            avcodec_close(pointer);
        }

        public void Dipose()
        {
            Close();

            isDisposed = true;
        }

        /*
        public  void Open()
        {
        }
        */
    }

}
