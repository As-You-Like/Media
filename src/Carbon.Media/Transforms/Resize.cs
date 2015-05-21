namespace Carbon.Media
{
	using System;
	using System.Runtime.Serialization;

	public class Resize : ITransform
	{
		private readonly int height;
		private readonly int width;

		public Resize(Size size) 
			: this(size.Width, size.Height) { }

		public Resize(int width, int height)
		{
			#region Preconditions

			if (width < 0 || width > 5000)
				throw new ArgumentOutOfRangeException("width", width, message: "Must be between 0 and 5,000");

			if (height < 0 || height > 10000)
				throw new ArgumentOutOfRangeException("height", height, message: "Must be between 0 and 10,000");
			
			#endregion

			this.width = width;
			this.height = height;
		}

		public int Height => height;

		public int Width => width;

		[IgnoreDataMember]
		public Size Size => new Size(width, height);

		public override string ToString() => width + "x" + height;

		public static Resize Parse(string key)
		{
			#region Normalization

			if (key.StartsWith("resize:")) {
				key = key.Remove(0, 7);
			}

			#endregion

			return new Resize(Size.Parse(key));
		}
	}
}

/* 

500x0
0x500

500x500;fit:crop;anchor:center
500x500(fit:crop;anchor:center)
500x500+x:100+y:200 

500x500(fit:crop anchor:center)

HTTP HEADER SYNTAX

compress;q=0.5, gzip;q=1.0
text/html; charset=ISO-8859-4
 
Image Magic : 
-resize 64x64
-crop 40x30+10+10  (width,height,top,left)

-crop <width>x<height>{+-}<x>{+-}<y>{%}

*/