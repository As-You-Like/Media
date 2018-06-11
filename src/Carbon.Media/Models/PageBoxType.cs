namespace Carbon.Media
{
    public enum PageBoxType
    {
        /// <summary>
        /// The dimensions of the physical medium (e.g. paper) that the epage is printed too.
        /// </summary>
        Media = 1,
        
        /// <summary>
        /// The dimensions allocated for overprinting / bleed.
        /// </summary>
        Bleed = 2,

        /// <summary>
        /// The dimensions of the page after trimming.
        /// </summary>
        Trim = 3,
        
        /// <summary>
        /// The dimensions of the art, or content.
        /// </summary>
        Art = 4,

        /// <summary>
        /// The dimensions to display on screen.
        /// </summary>
        Crop = 5
    }
}