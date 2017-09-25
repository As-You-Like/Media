using System.Collections.Generic;
using System.IO;
using Carbon.Media.Containers;
using Carbon.Media.Processors;

namespace Carbon.Media.Processing
{
    public class Processor
    {
        public void Process(MediaSource input, Stream output, ITransform[] filters)
        {
            // av_format_open (auto detects format, reads header, and creates an AV context)

            var inputContext  = new FormatContext();
            var outputContext = new FormatContext();

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

            
            // Build a filter graph from the filters (deinterlace, scale, etc)
        }
    }

    public class FilterGraph
    { 
        // Resize
        // Crop
        // Overlay
        // Draw
        // Clip
        // Filters

        // FilterLinks
        public IList<IFilter> Filters { get; }
    }
    
    // Custom IO Context...
    public class IOContext
    {
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