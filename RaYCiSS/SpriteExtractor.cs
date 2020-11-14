using System;
using System.Collections.Generic;
using System.IO;

namespace RaYCiSS
{
    public static class SpriteExtractor
    {
        public static void Extract(Dictionary<string, long> ChunksList, BinaryReader fileStream)
        {
            byte[] readBuffer = new byte[4];
            fileStream.BaseStream.Position = ChunksList["TXTR"];
            int TXTRChunkSize = fileStream.ReadInt32();
            /*Extracting SPRT and TPAG Data*/
            if (ChunksList.TryGetValue("SPRT", out long sprtOffset))
            {
                fileStream.BaseStream.Position = sprtOffset;
                int SpriteChunkSize = fileStream.ReadInt32();
                int SpritesCount = fileStream.ReadInt32();
                int[] SpritesOffsets = new int[SpritesCount];
                for (int i=0; i<SpritesCount; i++)
                {
                    fileStream.Read(readBuffer, 0, readBuffer.Length);
                    SpritesOffsets[i] = BitConverter.ToInt32(readBuffer,0);
                }
                foreach (int pos in SpritesOffsets)
                {
                    fileStream.BaseStream.Position = pos;
                    int SpriteNameOffset = fileStream.ReadInt32();
                    fileStream.BaseStream.Position = SpriteNameOffset;
                    string SpriteName = "";
                    char res;
                    while ((res = fileStream.ReadChar()) != 0x00)
                        SpriteName += res;
                    if (SpriteName == "sStatue" || SpriteName == "sSpaceflyerEditor" || SpriteName == "sSpacedashEditor" || SpriteName == "sSpacepirateParts"
                        || SpriteName == "sPirate2_parts" || SpriteName == "sPirate1_parts" || SpriteName == "sBackEnding" || SpriteName == "sGamemaster_parts"
                        || SpriteName == "sHoplite_parts" || SpriteName == "sHoplite_parts_hard")
                    {
                        Console.WriteLine("\nWriting Sprite Data");
                        Console.WriteLine(SpriteName);
                        StreamWriter fileOutS = new StreamWriter(new FileStream(SpriteName + ".cs", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
                        fileStream.BaseStream.Position = pos + 4;
                        fileOutS.Write("namespace RaYCiSS\n{\n    public class S" + SpriteName + " : ISpriteData\n    {\n        private readonly static byte[] lSPRTData = { ");
                        for (int i=0; i<71; i++)
                        {
                            fileOutS.Write("0x" + fileStream.ReadByte().ToString("X") + ", ");
                        }
                        fileOutS.Write("0x" + fileStream.ReadByte().ToString("X") + " };");
                        fileOutS.Write("\n\n");
                        int TxtPageCount = fileStream.ReadInt32();
                        int[] TxtPages = new int[TxtPageCount];
                        for (int i=0; i<TxtPageCount; i++)
                        {
                            TxtPages[i] = fileStream.ReadInt32();
                        }
                        fileOutS.Write("        private readonly static byte[,] lTPAGData = {");
                        foreach (int tpagpos in TxtPages)
                        {
                            fileOutS.Write("\n                { ");
                            fileStream.BaseStream.Position = tpagpos;
                            for (int j=0; j<21; j++)
                            {
                                fileOutS.Write("0x" + fileStream.ReadByte().ToString("X") + ", ");
                            }
                            fileOutS.Write("0x" + fileStream.ReadByte().ToString("X") + " },");
                        }
                        fileOutS.Write("\n           };");
                        fileOutS.Write("\n\n        public byte[] SPRTData {{ get => lSPRTData; }}\n        public byte[,] TPAGData {{ get => lTPAGData; }}");
                        fileOutS.Write($"\n\n        public static ISpriteData GetSpriteData {{ get => new S{SpriteName}(); }}");
                        fileOutS.Write("\n    }\n}\n");
                        fileOutS.Close();
                    }
                }
                /* Extracting Textures*/
                fileStream.BaseStream.Position = ChunksList["TXTR"];
                fileStream.Read(readBuffer, 0, readBuffer.Length);
                int chunks = fileStream.ReadInt32();
                int[] offsets = new int[chunks];
                fileStream.BaseStream.Seek(chunks * readBuffer.Length, SeekOrigin.Current);
                for (int i = 0; i < chunks; i++)
                {
                    fileStream.BaseStream.Seek(2 * readBuffer.Length, SeekOrigin.Current);
                    fileStream.Read(readBuffer, 0, readBuffer.Length);
                    offsets[i] = BitConverter.ToInt32(readBuffer, 0);
                    Console.WriteLine("[" + i + "] Adding offset to extract: " + offsets[i]);
                }
                FileStream fileOut;
                int size;
                byte[] buffer;
                for (int i=0; i<chunks-1; i++)
                {
                    fileOut = new FileStream(i.ToString() + ".png", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                    fileStream.BaseStream.Position = offsets[i];
                    size = offsets[i + 1] - offsets[i];
                    buffer = new byte[size];
                    Console.WriteLine("Writing " + i.ToString() + ".png");
                    fileStream.Read(buffer, 0, buffer.Length);
                    fileOut.Write(buffer, 0, buffer.Length);
                    fileOut.Close();
                }
                fileOut = new FileStream((chunks-1).ToString() + ".png", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                fileStream.BaseStream.Position = offsets[chunks - 1];
                size = (int)((TXTRChunkSize + ChunksList["TXTR"]) - offsets[chunks-1]);
                buffer = new byte[size];
                Console.WriteLine("Writing " + (chunks - 1).ToString() + ".png");
                fileStream.Read(buffer, 0, buffer.Length);
                fileOut.Write(buffer, 0, buffer.Length);
                fileOut.Close();
            }  /*Yet belongs to SPRT and TPAG extraction*/
            else
            {
                fileStream.Close();
                Console.WriteLine("TXTR chunk not found in file!");
                Console.WriteLine("Press a Key to exit....");
                Console.ReadKey();
                return;
            }

            fileStream.Close();
        }
    }
}
