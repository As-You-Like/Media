using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe abstract class Decoder : Codec
    {
        public Decoder(CodecId id)
            : base(id){ }

        public virtual bool IsEof { get; }

        // returns the number of decoded frames?
        public int Decode(Packet packet)
        {
            // provides the decoder with raw compressed data
            ffmpeg.avcodec_send_packet(Context.Pointer, packet.Pointer);

            return 0;
        }

        public virtual bool TryGetFrame(Frame frame)
        {
            var result = ffmpeg.avcodec_receive_frame(Context.Pointer, frame.Pointer);

            return result > 0;
        }
    }

    public abstract class VideoDecoder : Decoder
    {
        public VideoDecoder(CodecId id)
            : base(id){ }
    }

    public abstract class AudioDecoder : Decoder
    {
        public AudioDecoder(CodecId id)
            : base(id){ }
    }
}