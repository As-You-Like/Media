using System.Runtime.InteropServices;

public static class FFmpegHelper
{
    internal static void RegisterBinaries()
    {
        SetDllDirectory(@"E:\Carbon\Media\lib");
    }

    [DllImport("kernel32", SetLastError = true)]
    private static extern bool SetDllDirectory(string lpPathName);
}