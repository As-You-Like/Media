namespace Carbon.Media
{
    public interface IProcessor
    {
        string Canonicalize();

    }
}

// crop
// scale(x,y)



/*
resize                   (padding, ...)         500x500(fit:pad)
composite

crop
blur(5px);
brightness(0.4);
contrast(200%);
drop-shadow(16px 16px 20px blue);
grayscale(50%);
hue-rotate(90deg);
invert(75%);
opacity(25%);
saturate(30%);
sepia(60%);
*/