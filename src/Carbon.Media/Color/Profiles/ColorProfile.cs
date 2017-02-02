using System;
using System.IO;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class ColorProfile
    {
        [DataMember(Name = "type")]
        public ColorProfileType Type { get; set; }

        [DataMember(Name = "version")]
        public Version Version { get; set; }

        [DataMember(Name = "colorSpace")]
        public ColorSpace ColorSpace { get; set; }

        [DataMember(Name = "targetDevice")]
        public DeviceType TargetDevice { get; set; }

        [DataMember(Name = "data")]
        public byte[] Data { get; set; }

        public static ColorProfile Parse(byte[] data)
        {
            var result = new ColorProfile {
                Type = ColorProfileType.ICC,
                Data = data
            };

            try
            {
                using (var ms = new MemoryStream(data))
                using (var parser = new ColorProfileParser(ms))
                {
                    var header = parser.ReadHeader();

                    result.Version    = header.ProfileVersionNumber;
                    result.ColorSpace = ICCColorSpace.Parse(header.ColorSpaceOfData);

                    switch (header.ProfileDeviceClass)
                    {
                        case "scnr": result.TargetDevice = DeviceType.Scanner; break;
                        case "mntr": result.TargetDevice = DeviceType.Monitor; break;
                        case "prtr": result.TargetDevice = DeviceType.Printer; break;
                    }
                }
            }
            catch { }

            return result;
        }
    }

    public enum DeviceType
    {
        Unknown = 0,
        Scanner = 1,
        Monitor = 2,
        Printer = 3
    }
}

/*
'scnr' 73636E72h input devices - scanners and digital cameras
'mntr' 6D6E7472h display devices - CRTs and LCDs
'prtr' 70727472h output devices - printers.
*/

// ICC, ICM
// Profile or ExifColorSpace

// Represents the International Color Consortium (ICC) or Image Color Management (ICM) color profile that is associated with a bitmap image.

/*
ICC profile
In color management, an ICC profile is a set of data that characterizes a color input or output device, or a color space, according 
to standards promulgated by the International Color Consortium (ICC). 
Profiles describe the color attributes of a particular device or viewing requirement by defining a mapping between the device source 
or target color space and a profile connection space (PCS). This PCS is either CIELAB (L*a*b*) or CIEXYZ. Mappings may be specified using tables,
to which interpolation is applied, or through a series of parameters for transformations.
*/

/*
ICM 1.0 supports profiles that conform to the International Color Consortium (ICC) profile specification. 
The ICC profile specification is a cross-platform industry standard that accurately and consistently characterizes devices including scanners, monitors, and printers.
The ICC started in 1993 as an organization to promote color standards with desktop applications.
*/

/*
Q. Are there any differences between profiles with ".icc" and ".icm" extensions?

A. The answer is no. '.ICC' and '.ICM' files should be identical except for the suffix. The .ICC suffix was originated by Apple and Windows uses .ICM.
*/
