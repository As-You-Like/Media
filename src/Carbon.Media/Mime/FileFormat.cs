namespace Carbon.Media
{
	using System;
	using System.IO;

	public static class FileFormat
	{
		private static readonly string[] compressableFormats = { "appcache", "atom", "css", "csv", "html", "js", "json", "txt", "xml" };

		public static string Normalize(string format)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			// Strip any leading periods and convert to lowercase
			format = format.TrimStart('.').ToLower();

			switch (format)
			{
				case "jpg": return "jpeg";
				case "tif": return "tiff";
				case "mpg": return "mpeg";

				default: return format;
			}
		}

		public static bool IsCompressible(string format)
		{
			return Array.BinarySearch(compressableFormats, format) > 0;
		}

		public static string FromPath(string path)
		{
			var extension = Path.GetExtension(path);

			return Normalize(extension);
		}
	}
}