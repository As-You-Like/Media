namespace Carbon.Media
{
	using System.Drawing;

	public static class OrientationHelper
	{
		public static Size GetOrientatedSize(IMediaInfo media, MediaOrientation orientation)
		{
			switch (orientation)
			{
				case MediaOrientation.Transpose	 : 
				case MediaOrientation.Rotate90	 :
				case MediaOrientation.Transverse :
				case MediaOrientation.Rotate270	 : return new Size(media.Height, media.Width);
				default							 : return new Size(media.Width, media.Height);
			}
		}

		public static ITransform[] GetTransforms(this MediaOrientation orientation)
		{
			switch(orientation)
			{
				case MediaOrientation.FlipHorizontal	: return new ITransform[] { Flip.Horizontally };
				case MediaOrientation.Rotate180			: return new ITransform[] { new Rotate(180) };
				case MediaOrientation.FlipVertical		: return new ITransform[] { Flip.Vertically };
				case MediaOrientation.Transpose			: return new ITransform[] { Flip.Horizontally, new Rotate(270) };
				case MediaOrientation.Rotate90			: return new ITransform[] { new Rotate(90) };
				case MediaOrientation.Transverse		: return new ITransform[] { Flip.Horizontally, new Rotate(90) };
				case MediaOrientation.Rotate270			: return new ITransform[] { new Rotate(270) };
				default									: return new ITransform[0];
			}
		}
	}
}
