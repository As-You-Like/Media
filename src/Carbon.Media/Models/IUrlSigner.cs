namespace Carbon.Media
{
    public interface IUrlSigner
    {
        string Sign(string path);
    }
}