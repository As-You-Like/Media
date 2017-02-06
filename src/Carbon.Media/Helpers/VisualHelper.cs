using System;

namespace Carbon.Media
{
    using Geometry;

    public static class ResizeHelper
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
                   scale = 0d;
            
            double widthP  = (double)box.Width / sourceSize.Width;
            double heightP = (double)box.Height / sourceSize.Height;

            if (heightP < widthP)
            {
                scale = widthP;

                if (anchor.HasFlag(CropAnchor.Top))
                {
                    y = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Bottom))
                {
                    y = box.Height - (sourceSize.Height * scale);
                }
                else // Center
                {
                    y = (box.Height - (sourceSize.Height * scale)) / 2d;
                }
            }
            else
            {
                scale = heightP;

                if (anchor.HasFlag(CropAnchor.Left))
                {
                    x = 0;
                }
                if (anchor.HasFlag(CropAnchor.Right))
                {
                    x = box.Width - (sourceSize.Width * scale);
                }
                else // center
                {
                    x = (box.Width - (sourceSize.Width * scale)) / 2d;
                }
            }

            return new Rectangle(
                x       : x,
                y       : y,
                width   : sourceSize.Width * scale,
                height  : sourceSize.Height * scale
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