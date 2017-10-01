using System.IO;
using Carbon.Media.Formats;
using Carbon.Media.Processors;

namespace Carbon.Media.Processing
{
    public class Processor
    {
        private readonly MediaPipeline pipeline;

        public Processor(MediaPipeline pipeline)
        {
            this.pipeline = pipeline;
        }

        public void Process(MediaSource input, Stream output)
        {
            // av_format_open (auto detects format, reads header, and creates an AV context)

            var inputContext  = new FormatContext();
            var outputContext = new FormatContext();

            // - build a filter graph from the pipeline (deinterlace, scale, etc)

            using (var demuxer = new HlsDemuxer())
            using (var muxer = new MovMuxer(new MovMuxerOptions()))
            {
                demuxer.ReadHeader(inputContext);

                muxer.WriteHeader(outputContext);

                // if the header is complete, fill in the missing details from the next few frames
                
                Packet packet;

                while ((packet = demuxer.ReadPacket()) != null)
                {
                    var stream = inputContext.Streams[packet.StreamIndex];

                    // Audio | Video

                    using (packet)
                    {
                        // TODO: Decode the packet
                        // TODO: Apply filters

                        muxer.WritePacket(packet);
                    }
                }
                
                muxer.WriteTrailer(outputContext);
            }            
        }
    }
}

/*
 _______              ______________
|       |            |              |
| input |  demuxer   | encoded data |   decoder
| file  | ---------> | packets      | -----+
|_______|            |______________|      |
                                           v
                                       _________
                                      |         |
                                      | decoded |
                                      | frames  |
                                      |_________|
 ________             ______________       |
|        |           |              |      |
| output | <-------- | encoded data | <----+
| file   |   muxer   | packets      |   encoder
|________|           |______________|
*/