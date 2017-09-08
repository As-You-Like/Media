using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public class Frame
    {
        public Frame(IBuffer data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        // The picture / channel planes
        public IBuffer Data { get; }

        /// <summary>
        ///  The order the frame is encoded within the bitstream (coded picture number)
        /// </summary>
        public int CodedIndex { get; set; } 

        /// <summary>
        /// The order the frame is presented (e.g. display picture number)
        /// </summary>
        public int PresentationIndex { get; set; }

        /// <summary>
        /// pts
        /// </summary>
        public TimeSpan Timestamp { get; set; }

        // DTS (when we need to decode something) [pkt_pts]
        public TimeSpan DecodingTimestamp { get; set; }

        // PTS (when we need to display [present] something) [pkt_dts]
        public TimeSpan PresentationTimestamp { get; set; }
        
        public Dictionary<string, string> Metadata { get; set; }
    }
}
