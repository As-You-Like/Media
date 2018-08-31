using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class Encoder : Codec
    {
        public Encoder(CodecId id)
            : base(id, CodecType.Encoder) { }

        internal Encoder(AVCodecContext* context)
            : base(context, CodecType.Encoder) { }

        public OperationStatus TryEncode(Frame frame)
        {
            var result = ffmpeg.avcodec_send_frame(context.Pointer, frame.Pointer);
            
            if (frame is UnmanagedFrame unmanaged)
            {
                // unreference the frame so it may be reused...
                unmanaged.Unref();
            }

            switch (result)
            {
                case 0          : return OperationStatus.Ok;
                case -11        : return OperationStatus.Again;
                case -541478725 : return OperationStatus.EOF;
                default         : throw new FFmpegException(result);
            }
        }

        public void Complete()
        {
            // Sends a drain single
            ffmpeg.avcodec_send_frame(context.Pointer, null);
        }
        
        public OperationStatus TryReadPacket(Packet packet)
        {
            var result = ffmpeg.avcodec_receive_packet(context.Pointer, packet.Pointer);

            if (result == 0) // Success, we've recieved a compressed frame
            {
                packet.StreamIndex = Stream.Index;

                return OperationStatus.Ok;
            }

            switch (result)
            {
                case -11        : return OperationStatus.Again; // Needs more data
                case -541478725 : return OperationStatus.EOF;
            }

            throw new FFmpegException(result);
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