namespace Carbon.Media
{
	using System;
	using System.IO;

	using text = System.Text;

	public class ColorProfileParser : IDisposable
	{
		private readonly BinaryReader reader;

		public ColorProfileParser(MemoryStream stream)
		{
			this.reader = new BinaryReader(stream);
		}

		public ICCHeader ReadHeader()
		{
			var header = new ICCHeader();

			header.ProfileSize			= reader.ReadUInt32BE();
			header.CMMType				= reader.ReadString(4);

			header.ProfileVersionNumber = new Version((int)reader.ReadByte(), (int)reader.ReadByte()); reader.ReadBytes(2);
				
			header.ProfileDeviceClass	= reader.ReadString(4);
			header.ColorSpaceOfData		= reader.ReadString(4).TrimEnd(' ');
			header.PCS					= reader.ReadInt32BE(); 
			
			return header;
		}

		public void Dispose()
		{
			reader.Dispose();
		}
	}

	public class ICCHeader
	{
		// 0-3		(4)
		public UInt32 ProfileSize { get; set; }

		// 4-7		(4)
		public string CMMType { get; set; }

		/* Profile version number where the first 8 bits are the major version number and
		the next 8 bits are for the minor version number. The major and minor version
		numbers are set by the International Color Consortium and will match up with
		the profile format revisions. The current version number is 02h with a minor
		version number of 00h.
		*/
		// 8-11		(4)
		public Version ProfileVersionNumber { get; set; }

		// 12-15	(4)
		public string ProfileDeviceClass { get; set; }

		// 16-19
		public string ColorSpaceOfData { get; set; }

		// 20-23	(4)
		public int PCS { get; set; }
		
		// 24-35	(12)
		public DateTime DateTime { get ;set ;}

		// 36-39	(4)
		public string FileSignature { get; set; }

		// 40-43	(4)
		public string PlatformTarget { get; set; }

	}


	public static class BinaryReaderExtensions
	{
		public static string ReadString(this BinaryReader binRdr, int length)
		{
			return text::Encoding.ASCII.GetString(binRdr.ReadBytes(length));
		}

		public static UInt16 ReadUInt16BE(this BinaryReader binRdr)
		{
			return BitConverter.ToUInt16(binRdr.ReadBytesRequired(sizeof(UInt16)).Reverse(), 0);
		}

		public static Int16 ReadInt16BE(this BinaryReader binRdr)
		{
			return BitConverter.ToInt16(binRdr.ReadBytesRequired(sizeof(Int16)).Reverse(), 0);
		}

		public static UInt32 ReadUInt32BE(this BinaryReader binRdr)
		{
			return BitConverter.ToUInt32(binRdr.ReadBytesRequired(sizeof(UInt32)).Reverse(), 0);
		}

		public static Int32 ReadInt32BE(this BinaryReader binRdr)
		{
			return BitConverter.ToInt32(binRdr.ReadBytesRequired(sizeof(Int32)).Reverse(), 0);
		}

		private static byte[] ReadBytesRequired(this BinaryReader binRdr, int byteCount)
		{
			var result = binRdr.ReadBytes(byteCount);

			if (result.Length != byteCount)
				throw new EndOfStreamException(string.Format("{0} bytes required from stream, but only {1} returned.", byteCount, result.Length));

			return result;
		}

		// Note this MODIFIES THE GIVEN ARRAY then returns a reference to the modified array.
		private static byte[] Reverse(this byte[] b)
		{
			Array.Reverse(b);
			return b;
		}
	}
}

/*

[ICC_Profile, ICC-header, Image] 4 - Profile CMM Type: ADBE
[ICC_Profile, ICC-header, Image] 8 - Profile Version: 2.1.0
[ICC_Profile, ICC-header, Image] 12 - Profile Class: Display Device Profile
[ICC_Profile, ICC-header, Image] 16 - Color Space Data: RGB 
[ICC_Profile, ICC-header, Image] 20 - Profile Connection Space: XYZ 
[ICC_Profile, ICC-header, Time] 24 - Profile Date Time: 1999:06:03 00:00:00
[ICC_Profile, ICC-header, Image] 36 - Profile File Signature: acsp
[ICC_Profile, ICC-header, Image] 40 - Primary Platform: Apple Computer Inc.
[ICC_Profile, ICC-header, Image] 44 - CMM Flags: Not Embedded, Independent
[ICC_Profile, ICC-header, Image] 48 - Device Manufacturer: none
[ICC_Profile, ICC-header, Image] 52 - Device Model: 
[ICC_Profile, ICC-header, Image] 56 - Device Attributes: Reflective, Glossy, Positive, Color
[ICC_Profile, ICC-header, Image] 64 - Rendering Intent: Media-Relative Colorimetric
[ICC_Profile, ICC-header, Image] 68 - Connection Space Illuminant: 0.9642 1 0.82491
[ICC_Profile, ICC-header, Image] 80 - Profile Creator: ADBE
[ICC_Profile, ICC-header, Image] 84 - Profile ID: 0
[ICC_Profile, ICC_Profile, Image] cprt - Profile Copyright: Copyright 1999 Adobe Systems Incorporated
[ICC_Profile, ICC_Profile, Image] desc - Profile Description: Apple RGB
[ICC_Profile, ICC_Profile, Image] wtpt - Media White Point: 0.95045 1 1.08905
[ICC_Profile, ICC_Profile, Image] bkpt - Media Black Point: 0 0 0
[ICC_Profile, ICC_Profile, Image] rTRC - Red Tone Reproduction Curve: (Binary data 14 bytes)
[ICC_Profile, ICC_Profile, Image] gTRC - Green Tone Reproduction Curve: (Binary data 14 bytes)
[ICC_Profile, ICC_Profile, Image] bTRC - Blue Tone Reproduction Curve: (Binary data 14 bytes)
[ICC_Profile, ICC_Profile, Image] rXYZ - Red Matrix Column: 0.47554 0.25516 0.01845
[ICC_Profile, ICC_Profile, Image] gXYZ - Green Matrix Column: 0.33972 0.67259 0.11333
[ICC_Profile, ICC_Profile, Image] bXYZ - Blue Matrix Column: 0.14896 0.07225 0.69312
*/