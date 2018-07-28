using System;
using System.Runtime.InteropServices;
using Carbon.Media.Codecs;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class FilterGraph
    {
        private AVFilterGraph* pointer;

        public FilterGraph()
        {
            this.pointer = ffmpeg.avfilter_graph_alloc();

            if (this.pointer == null)
            {
                throw new Exception("AVFilterGraph was not allocated");
            }
        }

        public AVFilterGraph* Pointer => pointer;

        // Source
        public FilterInOut Inputs;

        // Sink
        public FilterInOut Outputs;

        // Add a graph described by a string
        public void Parse(string filters)
        {
            // aresample=22050,aformat=sample_fmts=s16:channel_layouts=mono,asetnsamples=n=1024:p=0

            fixed (AVFilterInOut** inputs  = &Inputs.Pointer)
            fixed (AVFilterInOut** outputs = &Outputs.Pointer)
            {
                ffmpeg.avfilter_graph_parse_ptr(
                    pointer,
                    filters,
                    inputs,
                    outputs,
                    log_ctx: null
                ).EnsureSuccess();
            }
        }
        
        public void Initialize()
        {
            ffmpeg.avfilter_graph_config(pointer, null);
        }
  
        public FilterContext AddSink(Filter sinkFilter)
        {
            AVFilterContext* sinkContextPointer;
            
            ffmpeg.avfilter_graph_create_filter(
                filt_ctx  : &sinkContextPointer,
                filt      : sinkFilter.Pointer,
                name      : "out", 
                args      : null, 
                opaque    : null, 
                graph_ctx : pointer
            ).EnsureSuccess();
            
            return new FilterContext(sinkContextPointer);
        }

        public FilterContext AddSource(VideoFormatInfo format)
        {
            AVFilterContext* sourceFilterContext;

            var pixelFormatName = ffmpeg.av_get_pix_fmt_name(format.PixelFormat.ToAVFormat());
            
            var args = string.Format(
                "video_size={0}x{1}:pix_fmt={2}:time_base={3}/{4}:pixel_aspect={5}/{6}",
                format.Width,
                format.Height,
                pixelFormatName,
                format.TimeBase.Numerator,
                format.TimeBase.Denominator,
                format.AspectRatio.Numerator,
                format.AspectRatio.Denominator
            );

            var sourceFilter = Filter.FromName("buffer");

            ffmpeg.avfilter_graph_create_filter(&sourceFilterContext, sourceFilter.Pointer, "in", args, null, pointer).EnsureSuccess();
            
            return new FilterContext(sourceFilterContext);
        }

        public FilterContext AddSource(in AudioFormatInfo format)
        {
            AVFilterContext* filterContext;

            var sampleFormatName = ffmpeg.av_get_sample_fmt_name(format.SampleFormat.ToAVFormat());

            var channelLayoutHex = ((ulong)format.ChannelLayout);
            var hexChannelLayout = ((long)format.ChannelLayout).ToString("x");
            
            var args = string.Join(':',
                $"time_base=1/{format.SampleRate}",
                $"sample_rate={format.SampleRate}",
                $"sample_fmt={sampleFormatName}",
                $"channel_layout=0x{hexChannelLayout}"
            );

            ffmpeg.avfilter_graph_create_filter(
                filt_ctx  : &filterContext,
                filt      : Filter.FromName("abuffer").Pointer,
                name      : "in",
                args      : args,
                opaque    : null,
                graph_ctx : pointer
            ).EnsureSuccess();

            Console.WriteLine("added source:" + Marshal.PtrToStringAnsi((IntPtr)filterContext->name));

            return new FilterContext(filterContext);
        }

        // sourceOutput
        // sinkInput

    
        // Push to the buffer source
        public void PushFrame(Frame frame)
        {
            if (frame == null) throw new ArgumentNullException(nameof(frame));

            // Console.WriteLine("pushing frame to:" + bufferSource.Name);

            ffmpeg.av_buffersrc_add_frame_flags(
                buffer_src  : bufferSource.Pointer, 
                frame       : frame.Pointer, 
                flags       : 0 // ((int)(BufferSourceFlags.Push | BufferSourceFlags.KeepRef))
            ).EnsureSuccess();

        }

        // pull from the sink
        public OperationStatus TryPullFrame(Frame frame)
        {
            var result = ffmpeg.av_buffersink_get_frame(bufferSink.Pointer, frame.Pointer);

            if (result == 0) return OperationStatus.Ok;

            switch (result)
            {
                case -11        : return OperationStatus.Again;
                case -541478725 : return OperationStatus.EOF;
            }

            throw new FFmpegException(result);
        }

        private FilterContext bufferSource;
        private FilterContext bufferSink;

        public static FilterGraph Create(
            Codec decoder,
            Codec encoder,
            string filterSpecification)
        {
            if (decoder == null)
                throw new ArgumentNullException(nameof(decoder));

            if (encoder == null)
                throw new ArgumentNullException(nameof(encoder));
            
            FilterContext bufferSource = default; 
            FilterContext bufferSink = default;

            var graph = new FilterGraph();

            if (decoder is VideoDecoder)
            {
                bufferSource = graph.AddSource(new VideoFormatInfo(
                    decoder.Context.PixelFormat,
                    decoder.Context.Width,
                    decoder.Context.Height,
                    decoder.Context.TimeBase,
                    decoder.Context.AspectRatio
                ));

                bufferSink = graph.AddSink(Filter.FromName("buffersink"));

                bufferSink.SetOption("pix_fmts", (int)encoder.Context.PixelFormat.ToAVFormat());
            }
            else if (decoder is AudioDecoder audioDecoder)
            {
                if (audioDecoder.Context.ChannelLayout == ChannelLayout.Unknown)
                {
                    throw new Exception("Invalid ChannelLayout:" + audioDecoder.Context.ChannelLayout);

                    // decoder.Context.ChannelLayout = (ChannelLayout)ffmpeg.av_get_default_channel_layout(decoder.Context.ChannelCount);
                }
               
                bufferSource = graph.AddSource(new AudioFormatInfo(
                   audioDecoder.Context.SampleFormat,
                   audioDecoder.Context.ChannelLayout,
                   audioDecoder.Context.SampleRate
                ));

                bufferSink = graph.AddSink(Filter.FromName("abuffersink"));
                
                // $"aresample={resampledAudioFormat.SampleRate},aformat=sample_fmts={sampleFormat}:channel_layouts=stereo,asetnsamples=n=1024:p=0"

                // var sampleFormatName = ffmpeg.av_get_sample_fmt_name(encoder.Context.SampleFormat.ToAVFormat());

                bufferSink.SetOption("sample_fmts",     (int)encoder.Context.SampleFormat.ToAVFormat());
                bufferSink.SetOption("channel_layouts", (ulong)encoder.Context.ChannelLayout);
                bufferSink.SetOption("sample_rates",    encoder.Context.SampleRate);
            }
            else
            {
                throw new Exception("Invalid codec");
            }   

            graph.Outputs = new FilterInOut("in",  bufferSource);
            graph.Inputs  = new FilterInOut("out", bufferSink);

            graph.bufferSource = bufferSource;
            graph.bufferSink = bufferSink;

            if (filterSpecification != null)
            {
                graph.Parse(filterSpecification);
            }

            graph.Initialize();

            return graph;
        }

        public string Dump()
        {
            var data = ffmpeg.avfilter_graph_dump(pointer, null);

            return Marshal.PtrToStringAnsi((IntPtr)data);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (pointer == null) return;

            Console.WriteLine("Disposing FilterGraph");

            fixed (AVFilterGraph** p = &pointer)
            {
                ffmpeg.avfilter_graph_free(p);
            }

            Inputs.Dispose();
            Outputs.Dispose();

            pointer = null;
        }

        ~FilterGraph()
        {
            Dispose(false);
        }
    }
}