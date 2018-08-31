using System;
using System.Collections.Generic;
using System.IO;
using Carbon.Media.Codecs;
using Carbon.Media.IO;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class FormatContext : IDisposable
    {
        private bool isDisposed = false;
        private AVFormatContext* pointer;

        public FormatContext()
        {
            this.pointer = ffmpeg.avformat_alloc_context();

            if (pointer == null)
            {
                throw new Exception("Unable to allocate format context");
            }
        }

        public AVFormatContext* Pointer => pointer;
        
        public MediaStream[] Streams { get; internal set; }

        // public Chapter[] Chapters { get; }

        public BitRate? BitRate => new BitRate(pointer->bit_rate);
        
        public TimeSpan? MaxAnalyzeDuration { get; }

        public TimeSpan? Duration => new Timestamp(pointer->duration, Timebases.DotNetTicks).TimeSpan;
        
        public Dictionary<string, string> Metadata { get; }

        // public object A => pointer->iformat;

        internal OutputFormat OutputFormat => new OutputFormat(pointer->oformat);
        
        internal FormatFlags Flags
        {
            get => (FormatFlags)pointer->flags;
            set => pointer->flags = (int)value;
        }

        // Input Format
        // Output Format

        public void Open(IOContext source)
        {
            pointer->pb = source.Pointer;
            
            pointer->flags |= ffmpeg.AVFMT_FLAG_CUSTOM_IO;

            AVInputFormat* inputFormat = null;

            ffmpeg.av_probe_input_buffer(source.Pointer, &inputFormat, null, null, 0, 0).EnsureSuccess();
            
            // Console.WriteLine("probed -> " + Marshal.PtrToStringAnsi((IntPtr)inputFormat->name));

            fixed (AVFormatContext** ps = &pointer)
            {
                ffmpeg.avformat_open_input(ps, url: "", inputFormat, options: null).EnsureSuccess();
            }

            SetupStreams();
        }

        public void Open(Uri url)
        {
            fixed (AVFormatContext** ps = &pointer)
            {
                ffmpeg.avformat_open_input(ps, url.ToString(), null, null).EnsureSuccess();
            }

            SetupStreams();
        }

        public void Open(FileInfo file)
        {
            fixed (AVFormatContext** ps = &pointer)
            {
                ffmpeg.avformat_open_input(ps, file.FullName, null, null).EnsureSuccess();
            }

            SetupStreams();
        }

        private void SetupStreams()
        {
            ffmpeg.avformat_find_stream_info(pointer, null).EnsureSuccess(); // populate the streams

            var streams = new MediaStream[pointer->nb_streams];

            for (int i = 0; i < pointer->nb_streams; i++)
            {
                var stream = MediaStream.Create(pointer->streams[i]);

                streams[i] = stream;
            }

            // Note: the codecs must be manually initilized before use

            Streams = streams;
        }
        
        public void Seek(int streamIndex, long position)
        {
            var time = new Timestamp(position, Streams[0].TimeBase);

             // ffmpeg.avformat_seek_file(pointer, streamIndex, time )
        }

        public bool CanSeek => pointer->pb->seekable == 1;

        public void Dispose()
        {
            if (isDisposed) return;

            // Console.WriteLine("Disposing FormatContext");

            if (Streams != null)
            {
                foreach (var stream in Streams)
                {
                    if (stream.Codec is Encoder)
                    {
                        ffmpeg.avcodec_close(stream.Codec.Context.Pointer);

                        // stream.Codec.Dispose();
                    }
                }
            }
            
            fixed (AVFormatContext** p = &pointer)
            {
                // avformat_close_input calls avformat_free_context 
                // avformat_free_context frees the streams

                ffmpeg.avformat_close_input(p);
            }

            pointer = null;

            isDisposed = true;
        }
    }
}

// ref for freeing logic: https://github.com/FFmpeg/FFmpeg/blob/2b1324bd167553f49736e4eaa94f96da9982925e/libavformat/utils.c