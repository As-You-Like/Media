namespace Carbon.Media
{
    public enum ScaleMode
    {
        None,

        /// <summary>
        /// Keep the aspect ratio
        /// </summary>
        Preserve,

        /// <summary>
        /// Strech sets the width and the height of the content to the container width and height,
        /// possibly changing the content aspect ratio.
        /// </summary>
        Stretch,

        Crop,

        // Pad with black bars
        Pad
    }
}