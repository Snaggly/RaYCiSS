using System.Text;
using System.IO;
using System.Collections.Generic;

namespace RaYCiSS
{
    public static class FileChecker
    {
        public static bool CheckFORM(string IFFfile)
        {
            byte[] readBuffer = new byte[4];
            using (FileStream fileStream = new FileStream(IFFfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fileStream.Read(readBuffer, 0, readBuffer.Length);
            }

            return Encoding.ASCII.GetString(readBuffer) == "FORM";
        }

        public static bool CheckRaymanRedemption(string IFFFile, long GEN8Offset)
        {
            string GameName = "";
            using (BinaryReader fileStream = new BinaryReader(new FileStream(IFFFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite) { Position = GEN8Offset }))
            {
                fileStream.BaseStream.Seek(8, SeekOrigin.Current);
                fileStream.BaseStream.Position = fileStream.ReadInt32();
                char c;
                while ((c = fileStream.ReadChar()) != 0)
                    GameName += c;
            }

            return GameName == "RaymanRedemption";
        }
    }
}
