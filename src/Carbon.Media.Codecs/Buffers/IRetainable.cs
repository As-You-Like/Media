namespace Carbon.Media
{
    public interface IRetainable
    {
        void Retain();

        bool Release();
    }
}