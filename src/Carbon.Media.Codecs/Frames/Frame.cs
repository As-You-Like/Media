using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public abstract class Frame
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

        // SmtpeTimecode
        
        // dts (when we need to decode something)
        public TimeSpan DecodingTime { get; set; }

        // pts (when we need to display [present] something) 
        public TimeSpan PresentationTime { get; set; }

        /// <summary>
        /// The time the frame is presented
        /// </summary>
        public TimeSpan Duration { get; set; }
        
        public Dictionary<string, string> Metadata { get; set; }
    }
}
