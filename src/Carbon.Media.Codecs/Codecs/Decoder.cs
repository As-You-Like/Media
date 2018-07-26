using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class Decoder : Codec
    {
        public Decoder(CodecId id)
            : base(id, CodecType.Decoder)
        {
        }

        public Decoder(AVCodecContext* context)
            : base(context, CodecType.Decoder) { }

        public virtual bool IsEof { get; }

        /// <summary>
        /// Provide the decoder with raw (compressed) data
        /// </summary>
        public OperationStatus TrySendPacket(Packet packet)
        {
            var result = ffmpeg.avcodec_send_packet(Context.Pointer, packet.Pointer);

            if (result == 0) return OperationStatus.Ok;
            
            switch (result)
            {
                case -11        : throw new FFmpegException(result); // Internal buffer full
                case -541478725 : return OperationStatus.EOF;
            }

            throw new FFmpegException(result);
        }

        /// <summary>
        /// Signal the end of the stream
        /// </summary>
        public void Complete()
        {
            ffmpeg.avcodec_send_packet(Context.Pointer, null);
        }
       
        public OperationStatus TryGetFrame(Frame frame)
        {
            var result = ffmpeg.avcodec_receive_frame(Context.Pointer, frame.Pointer);

            if (result == 0)
            {
                return OperationStatus.Ok;
            }
            
            switch (result)
            {
                case -11        : return OperationStatus.Again; // EAGAIN (needs more data)
                case -541478725 : return OperationStatus.EOF;   // EOF
            }

            throw new FFmpegException(result);
        }

        internal static Decoder Create(AVCodecContext* context)
        {
            switch (context->codec_type)
            {
                case AVMediaType.AVMEDIA_TYPE_VIDEO: return new VideoDecoder(context);
                case AVMediaType.AVMEDIA_TYPE_AUDIO: return new AudioDecoder(context);
            }

            return new Decoder(context);
        }
    }

    public enum OperationStatus
    {
        Ok    = 1,
        Again = 2,
        EOF   = 3
    }
}