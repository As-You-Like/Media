namespace Carbon.Media
{
    public interface IPage
    {
        int Number { get; }

        int Rotation { get; }

        int Width { get; }

        int Height { get; }
    }
}

// NOTE: The width and height default to the crop box dimensions