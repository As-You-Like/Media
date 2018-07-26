using System;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class Encoder : Codec
    {
        public Encoder(CodecId id)
            : base(id, CodecType.Encoder) { }

        internal Encoder(AVCodecContext* context)
            : base(context, CodecType.Encoder) { }

        // FilterContext?

        public OperationStatus TryEncode(Frame frame)
        {
            var result = ffmpeg.avcodec_send_frame(context.Pointer, frame.Pointer);

            if (result == 0) return OperationStatus.Ok;

            switch (result)
            {
                case -11        : return OperationStatus.Again;
                case -541478725 : return OperationStatus.EOF;
            }

            throw new FFmpegException(result);
        }

        public void Complete()
        {
            Console.WriteLine("Sending drain signal");

            ffmpeg.avcodec_send_frame(context.Pointer, null);
        }

        private readonly Packet tempPacket = Packet.Allocate();
        
        public OperationStatus TryGetPacket(out Packet packet)
        {
            var result = ffmpeg.avcodec_receive_packet(context.Pointer, tempPacket.Pointer);
            
            if (result == 0)
            {
                tempPacket.StreamIndex = Stream.Index;

                packet = tempPacket;

                return OperationStatus.Ok;
            }

            packet = default;

            switch (result)
            {
                case -11        : return OperationStatus.Again; // Needs more data
                case -541478725 : return OperationStatus.EOF;
            }

            throw new FFmpegException(result);
        }

        public override void Cleanup()
        {
            tempPacket?.Dispose();
        }

        #region Helpers

        public static Encoder Create(AVCodecContext* context)
        {
            switch (context->codec_type)
            {
                case AVMediaType.AVMEDIA_TYPE_VIDEO: return new VideoEncoder(context);
                case AVMediaType.AVMEDIA_TYPE_AUDIO: return new AudioEncoder(context);
            }

            return new Encoder(context);
        }

        #endregion
    }
}