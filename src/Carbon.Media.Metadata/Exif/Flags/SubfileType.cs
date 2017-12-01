namespace Carbon.Media.Metadata
{
    public enum SubfileType : byte
    {
        Full                                              = 0,
        ReducedResolution                                 = 1, 
        SinglePageOfMultiPage                             = 2, 
        SinglePageOfMultiPageReducedResolution            = 3,
        TransparencyMask                                  = 4,
        TransparencyMaskOfReducedResolutionImage          = 5,
        TransparencyMaskOfMultiPageImage                  = 6,
        TransparencyMaskOfReducedResolutionMultiPageImage = 7
    }
}