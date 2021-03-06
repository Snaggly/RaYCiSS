namespace RaYCiSS
{
    public class SsPirate1_parts : ISpriteData
    {
        private readonly static byte[] lSPRTData = { 0x40, 0x0, 0x0, 0x0, 0x1E, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x3F, 0x0, 0x0, 0x0, 0x1D, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x70, 0x41, 0x0, 0x0, 0x0, 0x0 };

        private readonly static byte[,] lTPAGData = {
                { 0x99, 0x6, 0x11, 0x1, 0x1C, 0x0, 0x19, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1C, 0x0, 0x19, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x5F, 0x2, 0x26, 0x1, 0x1C, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1C, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xAA, 0x1, 0xBC, 0x7, 0x1D, 0x0, 0x1A, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1D, 0x0, 0x1A, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA2, 0x4, 0x28, 0x1, 0x20, 0x0, 0x15, 0x0, 0x0, 0x0, 0x0, 0x0, 0x20, 0x0, 0x15, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x20, 0x5, 0x1E, 0x1, 0x1B, 0x0, 0x19, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1B, 0x0, 0x19, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC5, 0x2, 0x41, 0x1, 0x17, 0x0, 0x1B, 0x0, 0x0, 0x0, 0x0, 0x0, 0x17, 0x0, 0x1B, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC0, 0x1, 0xE3, 0x1, 0x18, 0x0, 0x1E, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0x1E, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x40, 0x2, 0x9C, 0x4, 0x18, 0x0, 0x15, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0x15, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x56, 0x2, 0xD, 0x5, 0x13, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x68, 0x2, 0xFB, 0x5, 0x13, 0x0, 0x16, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0x16, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xCC, 0x6, 0x30, 0x1, 0x1B, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1B, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x54, 0x2, 0xC2, 0x2, 0x13, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x47, 0x3, 0xEA, 0x0, 0x24, 0x0, 0x1B, 0x0, 0x0, 0x0, 0x0, 0x0, 0x24, 0x0, 0x1B, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x1A, 0x7, 0xDD, 0x1, 0x15, 0x0, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x15, 0x0, 0x12, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x69, 0x2, 0xBC, 0x7, 0x16, 0x0, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x16, 0x0, 0x12, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x81, 0x5, 0xBC, 0x1, 0x18, 0x0, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0x12, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC2, 0x2, 0xA2, 0x3, 0xF, 0x0, 0x13, 0x0, 0x0, 0x0, 0x0, 0x0, 0xF, 0x0, 0x13, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xE8, 0x2, 0x3C, 0x7, 0xE, 0x0, 0x11, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x11, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xF5, 0x4, 0xD, 0x2, 0x15, 0x0, 0xE, 0x0, 0x0, 0x0, 0x0, 0x0, 0x15, 0x0, 0xE, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC5, 0x2, 0xC7, 0x7, 0xE, 0x0, 0x14, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x14, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x18, 0x5, 0x20, 0x2, 0xE, 0x0, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x12, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xCB, 0x2, 0xC4, 0x5, 0xE, 0x0, 0x13, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x13, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xEB, 0x2, 0x65, 0x5, 0xE, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x10, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA4, 0x2, 0xB4, 0x6, 0xE, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xF0, 0x7, 0xEE, 0x5, 0xE, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0xC7, 0x2, 0xB9, 0x4, 0x12, 0x0, 0xF, 0x0, 0x0, 0x0, 0x0, 0x0, 0x12, 0x0, 0xF, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xB1, 0x4, 0x14, 0x2, 0x13, 0x0, 0xF, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0xF, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xFA, 0x2, 0x35, 0x7, 0xC, 0x0, 0x11, 0x0, 0x0, 0x0, 0x0, 0x0, 0xC, 0x0, 0x11, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA0, 0x7, 0x2E, 0x2, 0x13, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC9, 0x2, 0x9A, 0x6, 0xF, 0x0, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0xF, 0x0, 0x12, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xED, 0x2, 0x7, 0x5, 0xD, 0x0, 0x11, 0x0, 0x0, 0x0, 0x0, 0x0, 0xD, 0x0, 0x11, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xC5, 0x2, 0x8C, 0x4, 0xE, 0x0, 0x14, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x14, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x36, 0x5, 0x56, 0x2, 0xD, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0xD, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xD6, 0x2, 0xA6, 0x2, 0x10, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x10, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xE, 0x6, 0xF1, 0x1, 0x14, 0x0, 0x11, 0x0, 0x0, 0x0, 0x0, 0x0, 0x14, 0x0, 0x11, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x8A, 0x5, 0x14, 0x2, 0x13, 0x0, 0xF, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0xF, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xF7, 0x1, 0xE3, 0x5, 0x18, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x48, 0x3, 0xD1, 0x1, 0x10, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x18, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA9, 0x0, 0xE8, 0x0, 0x17, 0x0, 0xD, 0x0, 0x0, 0x0, 0x0, 0x0, 0x17, 0x0, 0xD, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x72, 0x3, 0x5, 0x2, 0x18, 0x0, 0xD, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0xD, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x40, 0x7, 0x26, 0x2, 0x15, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0x15, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xBD, 0x2, 0x64, 0x4, 0x16, 0x0, 0xD, 0x0, 0x0, 0x0, 0x0, 0x0, 0x16, 0x0, 0xD, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xCC, 0x2, 0xD3, 0x2, 0xD, 0x0, 0x14, 0x0, 0x0, 0x0, 0x0, 0x0, 0xD, 0x0, 0x14, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA, 0x7, 0x42, 0x1, 0x1B, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1B, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xCF, 0x3, 0x14, 0x2, 0x13, 0x0, 0xF, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0xF, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x3B, 0x3, 0x2D, 0x2, 0x12, 0x0, 0xD, 0x0, 0x0, 0x0, 0x0, 0x0, 0x12, 0x0, 0xD, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xB2, 0x2, 0xFE, 0x5, 0x10, 0x0, 0x13, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x13, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xF3, 0x2, 0xF4, 0x1, 0x18, 0x0, 0xE, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0xE, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x95, 0x6, 0xF4, 0x1, 0x18, 0x0, 0xE, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0xE, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x6, 0x2, 0xF6, 0x2, 0x13, 0x0, 0xB, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0x0, 0xB, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xBA, 0x1, 0xEA, 0x2, 0x14, 0x0, 0xB, 0x0, 0x0, 0x0, 0x0, 0x0, 0x14, 0x0, 0xB, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xE6, 0x6, 0x37, 0x2, 0x12, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0x12, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x7, 0x2, 0xC7, 0x2, 0x14, 0x0, 0xD, 0x0, 0x0, 0x0, 0x0, 0x0, 0x14, 0x0, 0xD, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x76, 0x0, 0x5B, 0x1, 0xF, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0xF, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xA3, 0x7, 0xA3, 0x5, 0x10, 0x0, 0x19, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x19, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0xF1, 0x7, 0x35, 0x7, 0xD, 0x0, 0x1C, 0x0, 0x0, 0x0, 0x0, 0x0, 0xD, 0x0, 0x1C, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0xB4, 0x2, 0x16, 0x4, 0x19, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0x19, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0xB6, 0x2, 0xBB, 0x6, 0x18, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0x18, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x4D, 0x2, 0xD, 0x4, 0x17, 0x0, 0x14, 0x0, 0x0, 0x0, 0x0, 0x0, 0x17, 0x0, 0x14, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x7C, 0x5, 0x94, 0x4, 0xE, 0x0, 0x19, 0x0, 0x0, 0x0, 0x0, 0x0, 0xE, 0x0, 0x19, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0x3F, 0x2, 0x3F, 0x5, 0x16, 0x0, 0x17, 0x0, 0x0, 0x0, 0x0, 0x0, 0x16, 0x0, 0x17, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x37, 0x1, 0xD3, 0x7, 0x1D, 0x0, 0xC, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1D, 0x0, 0xC, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x96, 0x2, 0x3D, 0x3, 0x15, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x15, 0x0, 0x10, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xB4, 0x6, 0xB3, 0x1, 0x16, 0x0, 0x14, 0x0, 0x0, 0x0, 0x0, 0x0, 0x16, 0x0, 0x14, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xDB, 0x2, 0x77, 0x0, 0x40, 0x0, 0x15, 0x0, 0x0, 0x0, 0x0, 0x0, 0x40, 0x0, 0x15, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0xCB, 0x5, 0xF5, 0x7, 0x17, 0x0, 0x9, 0x0, 0x0, 0x0, 0x0, 0x0, 0x17, 0x0, 0x9, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0xD1, 0x0, 0x47, 0x6, 0x17, 0x0, 0xA, 0x0, 0x0, 0x0, 0x0, 0x0, 0x17, 0x0, 0xA, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x5, 0x0 },
                { 0x2B, 0x4, 0xA1, 0x7, 0x8, 0x0, 0xA, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0xA, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
                { 0x1C, 0x2, 0x4, 0x5, 0x8, 0x0, 0xB, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0xB, 0x0, 0x40, 0x0, 0x1E, 0x0, 0x4, 0x0 },
           };

        public byte[] SPRTData { get => lSPRTData; }
        public byte[,] TPAGData { get => lTPAGData; }

        public static ISpriteData GetSpriteData { get; } = new SsPirate1_parts();
    }
}
