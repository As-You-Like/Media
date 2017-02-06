using System;

namespace Carbon.Media
{
    using Geometry;

    public static class VisualHelper
    {
        public static Size CalculateSize(ISize source, Size maxSize)
        {
            #region Preconditions

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            #endregion

            return CalculateSize(new Size(source.Width, source.Height), maxSize);
        }

        public static Size CalculateSize(Size sourceSize, Size maxSize, ResizeFlags mode = ResizeFlags.None)
        {
            var aspect = sourceSize.ToRational();

            var calculatedSize = CalculateMaxSize(maxSize, aspect);

            // If we are not stretching the image, make sure the result is not bigger then the sourceSize
            if (mode == ResizeFlags.None)
            {
                if (calculatedSize.Height > sourceSize.Height || calculatedSize.Width > sourceSize.Width)
                {
                    calculatedSize = CalculateMaxSize(sourceSize, aspect);
                }
            }

            return calculatedSize;
        }

        public static Rectangle CalculateCropRectangle(ISize sourceSize, ISize box, CropAnchor anchor)
        {
            double x = 0d,
                   y = 0d,
                   nPercent = 0d;
            
            double nPercentW = (double)box.Width / sourceSize.Width;
            double nPercentH = (double)box.Height / sourceSize.Height;

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;

                switch (anchor)
                {
                    case CropAnchor.Top:
                        y = 0;
                        break;
                    case CropAnchor.Bottom:
                        y = box.Height - (sourceSize.Height * nPercent);
                        break;
                    default:
                        y = (box.Height - (sourceSize.Height * nPercent)) / 2d;
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;

                switch (anchor)
                {
                    case CropAnchor.Left:
                        y = 0;
                        break;
                    case CropAnchor.Right:
                        x = box.Width - (sourceSize.Width * nPercent);
                        break;
                    default:
                        x = (box.Width - (sourceSize.Width * nPercent)) / 2d;
                        break;
                }
            }

            return new Rectangle(
                x       : x,
                y       : y,
                width   : sourceSize.Width * nPercent,
                height  : sourceSize.Height * nPercent
            );
        }

        /// <summary>
        /// Returns the maximium dimensions of an image w/ a specific aspect
        /// </summary>
        public static Size CalculateMaxSize(Size sourceSize, Rational aspect)
        {
            double targetAspect = aspect;
            double currentAspect = sourceSize.ToRational();

            if (currentAspect > targetAspect) // Shrink the width
            {
                int newWidth = (int)(sourceSize.Height * targetAspect);

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