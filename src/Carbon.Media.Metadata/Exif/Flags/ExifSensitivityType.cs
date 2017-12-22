namespace Carbon.Media.Metadata
{
	public enum ExifSensitivityType : byte
	{
		Unknown                                                      = 0,
		StandardOutputSensitivity                                    = 1,
		RecommendedExposureIndex                                     = 2,
		ISOSpeed                                                     = 3,
		StandardOutputSensitivityAndRecommendedExposureIndex         = 4,
		StandardOutputSensitivityAndIsoSpeed                         = 5,
		RecommendedExposureIndexAndIsoSpeed                          = 6,
		StandardOutputSensitivityRecommendedExposureIndexAndIsoSpeed = 7
	}
}
