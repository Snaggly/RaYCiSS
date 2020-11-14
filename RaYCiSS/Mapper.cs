using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RaYCiSS
{
    public static class Mapper
    {
        public static Dictionary<string, long> GetDictionary(string IFFFile)
        {
            string currentChunk = "";
            int chunckSize = 0;
            byte[] readBuffer = new byte[4];
            BinaryReader fileStream = new BinaryReader(new FileStream(IFFFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            fileStream.BaseStream.Seek(8, SeekOrigin.Begin);
            Dictionary<string, long> ChunksList = new Dictionary<string, long>();
            while (fileStream.BaseStream.Position < fileStream.BaseStream.Length)
            {
                fileStream.Read(readBuffer, 0, readBuffer.Length);
                currentChunk = Encoding.ASCII.GetString(readBuffer);
                ChunksList.Add(currentChunk, fileStream.BaseStream.Position);
                chunckSize = fileStream.ReadInt32();
                fileStream.BaseStream.Seek(chunckSize, SeekOrigin.Current);
            }
            fileStream.Close();
            return ChunksList;
        }

        public static int GetTextureAmount(string IFFfile, Dictionary<string, long> dictionary)
        {
            byte[] readBuffer = new byte[4];
            BinaryReader fileStream = new BinaryReader(new FileStream(IFFfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            {
                Position = dictionary["TXTR"] + 4
            });

            int TXTRAmount = fileStream.ReadInt32();
            fileStream.Close();
            return TXTRAmount;
        }
    }
}

