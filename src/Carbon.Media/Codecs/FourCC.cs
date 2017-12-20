namespace Carbon.Media
{
    public readonly struct FourCC
    {
        public FourCC(CodecId id)
        {
            CodecId = id;
        }

        public readonly CodecId CodecId;

        // int Value

        // Create from ####

        public static readonly FourCC AASC = new FourCC(CodecId.Aasc);
        public static readonly FourCC ACDV = new FourCC(CodecId.Acdv);
        public static readonly FourCC APCH = new FourCC(CodecId.ProRes);
        public static readonly FourCC APCN = new FourCC(CodecId.ProRes);    // Apple ProRes 422 Standard Definition
        public static readonly FourCC APCS = new FourCC(CodecId.ProRes);    // Apple ProRes 422 LT:
        public static readonly FourCC ASV1 = new FourCC(CodecId.Asv1);
        public static readonly FourCC ASV2 = new FourCC(CodecId.Asv2);
        public static readonly FourCC AUR2 = new FourCC(CodecId.Aura2);     // AuraVision Aura 2: YUV 422
        public static readonly FourCC AURA = new FourCC(CodecId.Aura);      //AuraVision Aura 1: YUV 411 
        public static readonly FourCC AVRn = new FourCC(CodecId.Avrn);
        public static readonly FourCC CDVC = new FourCC(CodecId.DV);
        public static readonly FourCC CFHD = new FourCC(CodecId.Cfhd);
        public static readonly FourCC CLJR = new FourCC(CodecId.Cljr);      // Cirrus Logic AccuPak
        public static readonly FourCC CLLC = new FourCC(CodecId.Cllc);      // Canopus Lossless
        public static readonly FourCC CSCD = new FourCC(CodecId.Cscd);
        public static readonly FourCC CVID = new FourCC(CodecId.Cinepak);
        public static readonly FourCC CYUV = new FourCC(CodecId.Cyuv);      // Creative Labs YUV
        public static readonly FourCC DUCK = new FourCC(CodecId.Duck);
        // public static readonly FourCC DV25 = new FourCC();               // DVCPRO 25 
        // public static readonly FourCC DV50 = new FourCC();               // DVCPRO 50 
        // public static readonly FourCC DXT1 = new FourCC();               // DirectX Texture Compression Format 1
        // public static readonly FourCC DXT2 = new FourCC();               // DirectX Texture Compression Format 2
        // public static readonly FourCC DXT3 = new FourCC();               // DirectX Texture Compression Format 3
        // public static readonly FourCC DXT4 = new FourCC();               // DirectX Texture Compression Format 4
        // public static readonly FourCC DXT5 = new FourCC();               // DirectX Texture Compression Format 5
        public static readonly FourCC FFV1 = new FourCC(CodecId.Ffv1);
        public static readonly FourCC FLIC = new FourCC(CodecId.Flic);
        public static readonly FourCC FPS1 = new FourCC(CodecId.Fraps);
        public static readonly FourCC G2M2 = new FourCC(CodecId.G2m);
        public static readonly FourCC H263 = new FourCC(CodecId.H263);
        public static readonly FourCC H264 = new FourCC(CodecId.H264);
        public static readonly FourCC HCPA = new FourCC(CodecId.ProRes);    // Apple ProRes 422 High Quality: 'apch' ('hcpa' in little-endian)
        public static readonly FourCC ICOD = new FourCC(CodecId.Aic);
        // public static readonly FourCC IV31 = new FourCC();               // Indeo 3.1
        // public static readonly FourCC IV32 = new FourCC();               // Indeo 3.2
        public static readonly FourCC IV40 = new FourCC(CodecId.Indeo4);
        public static readonly FourCC IV50 = new FourCC(CodecId.Indeo5);
        public static readonly FourCC JPEG = new FourCC(CodecId.Jpeg);
        public static readonly FourCC KGV1 = new FourCC(CodecId.Kgv1);
        public static readonly FourCC KMVC = new FourCC(CodecId.Kmvc);
        public static readonly FourCC LAGS = new FourCC(CodecId.Lagarith);
        public static readonly FourCC LOCO = new FourCC(CodecId.Loco);
        public static readonly FourCC MJPG = new FourCC(CodecId.Mjpeg);
        public static readonly FourCC ML20 = new FourCC(CodecId.Mimic);
        public static readonly FourCC MMES = new FourCC(CodecId.M101);
        public static readonly FourCC MSS1 = new FourCC(CodecId.Mss1);
        public static readonly FourCC MSS2 = new FourCC(CodecId.Mss2);
        public static readonly FourCC MSZH = new FourCC(CodecId.Mszh);
        public static readonly FourCC MTS2 = new FourCC(CodecId.Mts2);
        public static readonly FourCC MVI1 = new FourCC(CodecId.MotionPixels);
        public static readonly FourCC PXLT = new FourCC(CodecId.Pixlet);
        public static readonly FourCC Q_10 = new FourCC(CodecId.Qpeg);
        public static readonly FourCC QDRW = new FourCC(CodecId.Qdraw);
        public static readonly FourCC QPEG = new FourCC(CodecId.Qpeg);
        public static readonly FourCC R10k = new FourCC(CodecId.R10k);
        public static readonly FourCC R210 = new FourCC(CodecId.R210);
        public static readonly FourCC RPZA = new FourCC(CodecId.Rpza);
        public static readonly FourCC RT21 = new FourCC(CodecId.Indeo2);
        public static readonly FourCC RV10 = new FourCC(CodecId.Rv10);
        public static readonly FourCC RV20 = new FourCC(CodecId.Rv20);
        public static readonly FourCC RV30 = new FourCC(CodecId.Rv30);
        public static readonly FourCC RV40 = new FourCC(CodecId.Rv40);
        public static readonly FourCC SMC  = new FourCC(CodecId.Smc);
        public static readonly FourCC SVQ1 = new FourCC(CodecId.Svq1);
        public static readonly FourCC SVQ3 = new FourCC(CodecId.Svq3);
        public static readonly FourCC TM20 = new FourCC(CodecId.Tm20);
        public static readonly FourCC TSCC = new FourCC(CodecId.Tscc);
        public static readonly FourCC UCOD = new FourCC(CodecId.ClearVideo);
        public static readonly FourCC ULRA = new FourCC(CodecId.UtVideo);
        public static readonly FourCC ULRG = new FourCC(CodecId.UtVideo);
        public static readonly FourCC ULTI = new FourCC(CodecId.Ulti);      // Ultimotion
        public static readonly FourCC ULY0 = new FourCC(CodecId.UtVideo);
        public static readonly FourCC ULY2 = new FourCC(CodecId.UtVideo);
        public static readonly FourCC V210 = new FourCC(CodecId.V210);
        public static readonly FourCC VBLE = new FourCC(CodecId.Vble);
        public static readonly FourCC VCR1 = new FourCC(CodecId.Vcr1);
        public static readonly FourCC WVC1 = new FourCC(CodecId.Vc1);
    }
}
