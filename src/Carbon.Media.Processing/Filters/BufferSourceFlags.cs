namespace Carbon.Media
{
    internal enum BufferSourceFlags
    {
        None = 0,

        /// <summary>
        /// Do not check for format changes.
        /// </summary>
        NoCheckFormat = 1,

        /// <summary>
        /// Immediately push the frame to the output.
        /// </summary>
        Push = 4,

        /// <summary>
        /// Keep a reference to the frame.
        /// If the frame if reference-counted, create a new reference; otherwise copy the frame data.
        /// </summary>
        KeepRef = 8
    }
}