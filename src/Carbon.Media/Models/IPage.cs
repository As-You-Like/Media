namespace Carbon.Media
{
    public interface IPage
    {
        int Number { get; }

        int Width { get; }

        int Height { get; }

        int Rotation { get; }
    }
}

// NOTE: The width and height default to the crop box dimensions