namespace RaYCiSS
{
    public class SsSpaceflyerEditor : ISpriteData
    {
        private readonly static byte[] lSPRTData = { 0x60, 0x0, 0x0, 0x0, 0x55, 0x0, 0x0, 0x0, 0x2D, 0x0, 0x0, 0x0, 0x44, 0x0, 0x0, 0x0, 0x45, 0x0, 0x0, 0x0, 0x7, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x3C, 0x0, 0x0, 0x0, 0x49, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xF0, 0x41, 0x0, 0x0, 0x0, 0x0 };

        private readonly static byte[,] lTPAGData = {
                { 0x10, 0x4, 0x1, 0x1, 0x57, 0x0, 0x49, 0x0, 0x1, 0x0, 0x5, 0x0, 0x57, 0x0, 0x49, 0x0, 0x60, 0x0, 0x55, 0x0, 0x4, 0x0 },
           };

        public byte[] SPRTData { get => lSPRTData; }
        public byte[,] TPAGData { get => lTPAGData; }

        public static ISpriteData GetSpriteData { get; } = new SsSpaceflyerEditor();
    }
}