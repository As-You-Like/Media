namespace Carbon.Media
{
    public class CameraInfo
    {
        public CameraInfo() { }

        public CameraInfo(string make, string model)
        {
            Make = make;
            Model = model;
        }

        // e.g. Canon
        public string Make { get; set; }

        // e.g. EOS5
        public string Model { get; set; }

        // TODO: Canonicalize
    }
}