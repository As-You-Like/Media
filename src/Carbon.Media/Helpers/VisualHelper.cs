using System;

namespace Carbon.Helpers
{
    using Math;
    using Media;
    using Geometry;

    public static class VisualHelper
    {
        public static Size CalculateScaledSize(ISize source, double scale)
        {
            #region Preconditions

            if (source == null) throw new ArgumentNullException("source");

            #endregion

            return new Size(
                width: (int)(source.Height * scale),
                height: (int)(source.Width * scale)
            );
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

        public static Rectangle CalculateCropRectangle(ISize sourceSize, ISize targetSize, Alignment anchor)
        {
            var x = 0d;
            var y = 0d;

            var nPercent = 0d;
            double nPercentW = (double)targetSize.Width / (double)sourceSize.Width;
            double nPercentH = (double)targetSize.Height / (double)sourceSize.Height;

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;

                switch (anchor)
                {
                    case Alignment.Top:
                        y = 0;
                        break;
                    case Alignment.Bottom:
                        y = targetSize.Height - (sourceSize.Height * nPercent);
                        break;
                    default:
                        y = (targetSize.Height - (sourceSize.Height * nPercent)) / 2d;
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;

                switch (anchor)
                {
                    case Alignment.Left:
                        y = 0;
                        break;
                    case Alignment.Right:
                        x = targetSize.Width - (sourceSize.Width * nPercent);
                        break;
                    default:
                        x = (targetSize.Width - (sourceSize.Width * nPercent)) / 2d;
                        break;
                }
            }

            return new Rectangle(
                x: (int)x,
                y: (int)y,
                width: (int)(sourceSize.Width * nPercent),
                height: (int)(sourceSize.Height * nPercent)
            );
        }

        /// <summary>
        /// Returns the maximium dimensions of an image w/ a specific aspect
        /// </summary>
        public static Size CalculateMaxSize(Size sourceSize, Rational aspect)
        {
            var targetAspect = aspect.ToDouble();
            var currentAspect = sourceSize.ToRational().ToDouble();

            if (currentAspect > targetAspect) // Shrink the width
            {
                int newWidth = (int)((double)sourceSize.Height * targetAspect);

                return new Size(newWidth, sourceSize.Height);
            }

            else if (currentAspect < targetAspect) // Shrink the height
            {
                int newHeight = (int)(sourceSize.Width / targetAspect);

                return new Size(sourceSize.Width, newHeight);
            }

            else // The source and target aspect are the same
            {
                return sourceSize;
            }
        }
    }
}