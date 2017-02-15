using System.Reflection;

[assembly: AssemblyTitle("Carbon.Media")]
[assembly: AssemblyProduct("Carbon")]
[assembly: AssemblyCopyright("© 2012 - 2017 Jason Nelson")]
[assembly: AssemblyVersion("1.4.3")]

/* 
 1.0.0 (2016-10-27)
 -----------------------------------------------------
 Remove System.Drawing dependecy
 Make Mime a Class
 Add ai, psd, and mpd formats
 dotnetcore support

 0.1.1 (2013-10-10)
 -----------------------------------------------------
 Calculate the size correctly when rotating
 
 0.1.0 (2012-10-26)
 -----------------------------------------------------
 * Mime *
 - FromName
 - FromPath
 - Added Formats[]
 
 - Renamed Fraction to Rational
 - Removed VideoFormat
 - Removed VideoHelper
 
 0.0.8 (2012-09-20)
 -----------------------------------------------------
 * Mimes *
 - Added Opus
 - Added WebP
 
 * Transformations *
 - Base the format on the LAST dot
 - Changed rotate format to rotate(90deg) 
 - Added FilterTransform

 0.0.4 (2012-08-12)
 -----------------------------------------------------
 Simplified Transforms to use ToString() & Parse()
 
 0.0.3 (2012-08-11)
 -----------------------------------------------------
 Added Mime, MediaType, and MimeHelper (From Carbon.Core)
 Removed System.Web and WindowsBase references
 
 0.0.2 (2012-08-01)
 -----------------------------------------------------
 Added MediaCodec & Merged in AudioCodec & VideoCodec classes

 0.0.1 (2012-07-11)
 -----------------------------------------------------
 Initial (Broke out of Carbon.Core)
*/
