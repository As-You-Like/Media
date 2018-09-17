namespace Carbon.Media
{
    public enum UnitType
    {
        None = 0,
        Px = 1, // pixels	     1px = 1/96th of 1in
        Percentage = 2,

        // Length (1)
        M  = 10, // metre 
        Mm = 11, // millimeters	     1mm = 1/10th of 1cm
        Cm = 12, // centimeters	     1cm = 96px/2.54

        Pt = 13, // points

        // Mass (2)
        Kg = 20, // kilogram
        Mg = 21,
        G  = 22,

        S  = 30, // second
        Ns = 31,
        Ms = 32,

        // Angles
        Deg = 50,
        Rad = 51,

        // Frequency
        Hz  = 60,
        Khz = 61,

        // Resolution
        X = 70
    }
}
