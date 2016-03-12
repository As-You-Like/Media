namespace Carbon.Media.Encoding
{
    /// <summary>
    /// The bit rate is quantified using the bits per second (bit/s or bps) unit
    /// often in conjunction with an SI prefix such as kilo- (kbit/s or kbps), 
    /// mega- (Mbit/s or Mbps), giga- (Gbit/s or Gbps) or tera- (Tbit/s or Tbps).
    /// </summary>
    public abstract class Bitrate
    {
    }

    public class VariableBitrate : Bitrate
    {
        // min
        // average
        // max
    }

    public class FixedBitrate : Bitrate
    {
        public FixedBitrate(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}