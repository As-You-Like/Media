using System;

namespace Carbon.Media
{
    public class ContainerInfo
    {
        public ContainerInfo(ContainerId id, Mime[] mimes)
        {
            Id    = id;
            Mimes = mimes ?? throw new ArgumentNullException(nameof(mimes));
        }

        public ContainerId Id { get; }
        
        public Mime[] Mimes { get; }

        public static readonly ContainerInfo Tiff     = new ContainerInfo(ContainerId.Tiff,     new[] { Mime.Tiff });
        public static readonly ContainerInfo Mp4      = new ContainerInfo(ContainerId.Mp4,      new[] { Mime.Mp4 });
        public static readonly ContainerInfo WebM     = new ContainerInfo(ContainerId.WebM,     new[] { Mime.WebM });
        public static readonly ContainerInfo Matroska = new ContainerInfo(ContainerId.Matroska, new[] { Mime.Mka, Mime.Mkv });
        public static readonly ContainerInfo Ogg      = new ContainerInfo(ContainerId.Ogg,      new[] { Mime.Oga, Mime.Ogv });
    }
}
