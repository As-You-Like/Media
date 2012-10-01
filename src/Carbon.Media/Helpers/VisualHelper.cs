namespace Carbon.Helpers
{
	using System;
	using System.Drawing;

	using Carbon.Math;
	using Carbon.Media;

	public static class VisualHelper
	{
		public static Size ParseSize(this string size)
		{
			#region Preconditions

			if (size == null)
				throw new ArgumentNullException("size");

			if (!size.Contains("x"))
				throw new ArgumentException(string.Format("Invalid size. Was '{0}'.", size));

			#endregion

			var parts = size.Split('x');

			return new Size(Int32.Parse(parts[0]), Int32.Parse(parts[1]));
		}

		public static Size CalculateScaledSize(IMediaInfo source, Size maxSize)
		{
			#region Preconditions

			if (source == null)
				throw new ArgumentNullException("source");

			#endregion

			return CalculateScaledSize(new Size(source.Width, source.Height), maxSize);
		}

		public static Size CalculateScaledSize(Size sourceSize, Size maxSize, ScaleMode scaleMode = ScaleMode.None)
		{
			var aspect = sourceSize.ToRational();

			var calculatedSize = CalculateMaxSize(maxSize, aspect);

			// If we are not stretching the image, make sure the result is not bigger then the sourceSize
			if (scaleMode == ScaleMode.None)
			{
				if (calculatedSize.Height > sourceSize.Height || calculatedSize.Width > sourceSize.Width)
				{
					calculatedSize = CalculateMaxSize(sourceSize, aspect);
				}
			}

			return calculatedSize;
		}

		public static Rectangle CalculateCropRectangle(Size sourceSize, Size targetSize, Alignment anchor)
		{
			var cropResult = new Rectangle { X = 0, Y = 0 };

			double nPercent = 0;
			double nPercentW = (double)targetSize.Width / (double)sourceSize.Width;
			double nPercentH = (double)targetSize.Height / (double)sourceSize.Height;

			if (nPercentH < nPercentW)
			{
				nPercent = nPercentW;

				switch (anchor)
				{
					case Alignment.Top:
						cropResult.Y = 0;
						break;
					case Alignment.Bottom:
						cropResult.Y = (int)(targetSize.Height - ((double)sourceSize.Height * nPercent));
						break;
					default:
						cropResult.Y = (int)((targetSize.Height - ((double)sourceSize.Height * nPercent)) / 2);
						break;
				}
			}
			else
			{
				nPercent = nPercentH;

				switch (anchor)
				{
					case Alignment.Left: 
						cropResult.Y = 0;
						break;
					case Alignment.Right:
						cropResult.X = (int)(targetSize.Width - ((double)sourceSize.Width * nPercent));
						break;
					default:
						cropResult.X = (int)((targetSize.Width - ((double)sourceSize.Width * nPercent)) / 2);
						break;
				}
			}

			cropResult.Width = (int)((double)sourceSize.Width * nPercent);
			cropResult.Height = (int)((double)sourceSize.Height * nPercent);

			return cropResult;
		}

		/// <summary>
		/// Returns the maximium dimensions of an image w/ a specific aspect
		/// </summary>
		public static Size CalculateMaxSize(Size sourceSize, Rational aspect)
		{
			double targetAspect = aspect.ToDouble();
			double currentAspect = sourceSize.ToRational().ToDouble();

			if (currentAspect > targetAspect) // Shrink the width
			{
				int newWidth = (int)((double)sourceSize.Height * targetAspect);

				return new Size(newWidth, sourceSize.Height);
			}

			else if (currentAspect < targetAspect) // Shrink the height
			{
				int newHeight = (int)((double)sourceSize.Width / targetAspect);

				return new Size(sourceSize.Width, newHeight);
			}

			else // The source and target aspect are the same
			{
				return sourceSize;
			}
		}
	}
}