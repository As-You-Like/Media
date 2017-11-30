using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class FlashInfo
    {
        /// <summary>
        /// The strobe energy at the time the image is captured measured in Beam Candle Power Seconds
        /// </summary>
        [DataMember(Name = "energy")]
        public double Energy { get; set; }
    }
}


/*
0000.H = Flash did not fire.
0001.H = Flash fired.
0005.H = Strobe return light not detected.
0007.H = Strobe return light detected.
0009.H = Flash fired, compulsory flash mode
000D.H = Flash fired, compulsory flash mode, return light not detected
000F.H = Flash fired, compulsory flash mode, return light detected
0010.H = Flash did not fire, compulsory flash mode
0018.H = Flash did not fire, auto mode
0019.H = Flash fired, auto mode
001D.H = Flash fired, auto mode, return light not detected
001F.H = Flash fired, auto mode, return light detected
0020.H = No flash function
0041.H = Flash fired, red-eye reduction mode
0045.H = Flash fired, red-eye reduction mode, return light not detected
0047.H = Flash fired, red-eye reduction mode, return light detected
0049.H = Flash fired, compulsory flash mode, red-eye reduction mode
004D.H = Flash fired, compulsory flash mode, red-eye reduction mode, return light not detected
004F.H = Flash fired, compulsory flash mode, red-eye reduction mode, return light detected
0059.H = Flash fired, auto mode, red-eye reduction mode
005D.H = Flash fired, auto mode, return light not detected, red-eye reduction mode
005F.H = Flash fired, auto mode, return light detected, red-eye reduction mode
Other = reserved
*/
