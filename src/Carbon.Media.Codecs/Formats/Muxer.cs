using System;
using System.IO;
using System.Runtime.InteropServices;

using Carbon.Media.Codecs;
using Carbon.Media.IO;

using FFmpeg.AutoGen;

namespace Carbon.Media.Formats
{
    public unsafe class Muxer : Format
    {
        private IOContext ioContext;
        
        public Muxer(FormatId format)
            : base(format)
        {
            if (format == FormatId.M4a)
            {
                format = FormatId.Mp4;
            }

            var fmt = ffmpeg.av_guess_format(format.ToString().ToLower(), null, format.ToMime());

            if (fmt == null)
            {
                throw new Exception("Could not guess format:" + format.ToMime() + "|" + format.ToString().ToLower());
            }

            Context.Pointer->oformat = fmt;

            Console.WriteLine("OUTPUT:" + Marshal.PtrToStringAnsi((IntPtr)fmt->long_name));
        }
        
        public override FormatType Type => FormatType.Muxer;
        
        public void Initialize(params Encoder[] encoders)
        {
            if (encoders == null) throw new ArgumentNullException(nameof(encoders));

            var streams = new MediaStream[encoders.Length];

            for (var i = 0; i < streams.Length; i++)
            {
                var encoder = encoders[i];

                // Ensure a stream was intilized...
                if (encoder.Stream == null)
                {
                    MediaStream stream;

                    switch (encoder)
                    {
                        case AudioEncoder _ : stream = VideoStream.Create(this, encoder); break;
                        case VideoEncoder _ : stream = AudioStream.Create(this, encoder); break;
                        default             : throw new Exception("Invalid encoder type:" + encoder.GetType().Name);
                    }

                    stream.TimeBase = encoder.Context.TimeBase;

                    encoder.Stream = stream;

                    ffmpeg.avcodec_parameters_from_context(stream.Pointer->codecpar, encoder.Context.Pointer);
                }

                if (Context.OutputFormat.Flags.HasFlag(OutputFormatFlags.GlobalHeader))
                {
                    encoder.Context.Flags |= (int)OutputFormatFlags.GlobalHeader;
                }

                streams[i] = encoder.Stream;
            }
            
            this.Context.Streams = streams;
        }
        
        public virtual void WriteHeader(AvDictionary options = null)
        {
            if (options != null)
            {
                fixed (AVDictionary** p = &options.Pointer)
                {
                    ffmpeg.avformat_write_header(Context.Pointer, options: p).EnsureSuccess();
                }
            }
            else
            {
                ffmpeg.avformat_write_header(Context.Pointer, options: null).EnsureSuccess();
            }
        }

        public void WritePacket(Packet packet)
        {
            ffmpeg.av_interleaved_write_frame(Context.Pointer, packet.Pointer).EnsureSuccess();
        }

        public virtual void WriteTrailer()
        {
            ffmpeg.av_write_trailer(Context.Pointer);
        }
        
        public void Open(FileInfo outputFile)
        {
            ffmpeg.avio_open(&Context.Pointer->pb, outputFile.FullName, ffmpeg.AVIO_FLAG_WRITE);
        }

        public void Open(Stream outputStream)
        {
            Open(new IOContext(outputStream, writable: true));
        }

        internal void Open(IOContext ioContext)
        {
            this.ioContext = ioContext ?? throw new ArgumentNullException(nameof(ioContext));

            Context.Pointer->flags |= ffmpeg.AVFMT_FLAG_CUSTOM_IO;

            Context.Pointer->pb = ioContext.Pointer;
        }

        internal override void OnDisposing()
        {
            ioContext?.Dispose();

            ioContext = null;
        }

        public static Muxer Create(FormatId format, Stream stream)
        {
            var muxer = new Muxer(format);
            
            muxer.Open(stream);

            return muxer;
        }
    }
}