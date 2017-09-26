namespace Carbon.Media.Metadata
{
    public enum MediaOrientation
    {
        Horizontal                   = 1,
        MirrorHorizontal             = 2,
        Rotate180                    = 3,
        MirrorVertical               = 4,
        MirrorHorizontalAndRotate270 = 5,
        Rotate90                     = 6,
        MirroHorizontalAndRotate90   = 7,
        Rotate270                    = 8
    }

    /*
	1 = Horizontal (normal) 
	2 = Mirror horizontal 
	3 = Rotate 180 
	4 = Mirror vertical 
	5 = Mirror horizontal and rotate 270 CW 
	6 = Rotate 90 CW 
	7 = Mirror horizontal and rotate 90 CW 
	8 = Rotate 270 CW
	*/

    /*
	274	0×0112	integer
	(unsigned short)	Orientation	1 = Horizontal
	3 = Rotate 180 degrees
	6 = Rotate 90 degrees clockwise
	8 = Rotate 270 degrees clockwise
	*/
}
