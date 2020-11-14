using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RaYCiSS
{
    public class TXTRInjector
    {
        readonly long TXTRoffset;
        readonly string IFFfile;
        readonly Dictionary<string, long> successorChunks = new Dictionary<string, long>();

        public TXTRInjector(string IFFfile, Dictionary<string, long> keyValues)
        {
            int count = 0;
            foreach (KeyValuePair<string, long> pair in keyValues)
            {
                if (pair.Key == "TXTR") { TXTRoffset = pair.Value; count++; }
                else if (count > 0) successorChunks.Add(pair.Key, pair.Value);
            }

            if (TXTRoffset == 0)
            {
                throw new InvalidDataException("TXTR chunk offset not found!");
            }

            this.IFFfile = IFFfile;
        }

        public void InjectDatasFromResource(string[] ResourcePath)
        {
            if (ResourcePath == null)
                throw new FileNotFoundException("No Resources loaded!");

            int NewTotalFileSize = 0;

            using (var origStream = new BinaryReader(new FileStream(IFFfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //Saving base data
                origStream.BaseStream.Position = 4;
                int totalFileSize = origStream.ReadInt32();
                origStream.BaseStream.Position = TXTRoffset;
                int ChunkSize = origStream.ReadInt32();
                if (ChunkSize < 1)
                {
                    throw new InvalidDataException("TXTR chunk size smaller than 1");
                }
                int ChunkAmount = origStream.ReadInt32();
                if (ChunkAmount < 1)
                {
                    throw new InvalidDataException("TXTR chunk amount smaller than 1");
                }
                int[] OrigTXTOffs = new int[ChunkAmount];

                //Generating new header - Pointer to Pointer
                LinkedList<int> OffsetsShort = new LinkedList<int>();
                for (int i = 0; i < ChunkAmount; i++)
                    OffsetsShort.AddLast(origStream.ReadInt32() + (ResourcePath.Length * 4));
                foreach (string str in ResourcePath)
                    OffsetsShort.AddLast(OffsetsShort.Last.Value + 12);

                //Pointer to PNG, Previous fix
                LinkedList<int> OffsetsLong = new LinkedList<int>();
                long HeadEndPos = TXTRoffset + 8 + (OffsetsShort.Count * 16);
                int PaddingFix = (0x80 - ((int)HeadEndPos % 0x80)) % 0x80;
                origStream.BaseStream.Seek(8, SeekOrigin.Current);
                OrigTXTOffs[0] = origStream.ReadInt32();
                int DatDelta = (int)((HeadEndPos + PaddingFix) - OrigTXTOffs[0]);
                OffsetsLong.AddLast(OrigTXTOffs[0] + DatDelta);
                for (int i = 1; i < ChunkAmount; i++)
                {
                    origStream.BaseStream.Seek(8, SeekOrigin.Current);
                    OrigTXTOffs[i] = origStream.ReadInt32();
                    OffsetsLong.AddLast(OrigTXTOffs[i] + DatDelta);
                }

                //Pointer to PNG new fix
                PaddingFix = 0;
                int lastPos = (int)TXTRoffset + ChunkSize + DatDelta;
                PaddingFix = (0x80 - (lastPos % 0x80)) % 0x80;
                OffsetsLong.AddLast(PaddingFix + lastPos);
                for (int i = 0; i < ResourcePath.Length - 1; i++)
                {
                    PaddingFix = (0x80 - ((OffsetsLong.Last.Value + (int)ResourceManager.GetStream(ResourcePath[i]).Length) % 0x80)) % 0x80;
                    OffsetsLong.AddLast(PaddingFix + OffsetsLong.Last.Value + (int)ResourceManager.GetStream(ResourcePath[i]).Length);
                }
                int chunkSizeIncrease = (int)((OffsetsLong.Last.Value + ResourceManager.GetStream(ResourcePath[ResourcePath.Length - 1]).Length) - (TXTRoffset + ChunkSize + 4));
                PaddingFix = (4 - ((ChunkSize + chunkSizeIncrease) % 4)) % 4;
                chunkSizeIncrease += PaddingFix;
                NewTotalFileSize = totalFileSize + chunkSizeIncrease;

                int[] offsetsShort = OffsetsShort.ToArray();
                int[] offsetsLong = OffsetsLong.ToArray();

                //Preparing data
                if (File.Exists("tmp.dat"))
                    File.Delete("tmp.dat");

                //Writing new Header to TempFile
                using (BinaryWriter fileStream = new BinaryWriter(new FileStream("tmp.dat", FileMode.CreateNew, FileAccess.Write, FileShare.Read)))
                {
                    //Writing updated Meta
                    fileStream.Write(ChunkSize + chunkSizeIncrease);
                    fileStream.Write(ChunkAmount + ResourcePath.Length);

                    //Writing new Pointer2Pointer
                    foreach (int addr in offsetsShort)
                    {
                        fileStream.Write(addr);
                    }

                    //Writing new Pointer2PNG
                    fileStream.Write(0);
                    fileStream.Write(0);
                    fileStream.Write(offsetsLong[0]);
                    foreach (int addr in offsetsLong.Skip(1))
                    {
                        fileStream.Write(1);
                        fileStream.Write(0);
                        fileStream.Write(addr);
                    }

                    //Copy original PNGs to TempFile in pos
                    origStream.BaseStream.Position = OrigTXTOffs[0];
                    fileStream.BaseStream.Position = offsetsLong[0] - TXTRoffset;
                    int remainingChunkSize = (int)(origStream.BaseStream.Position - TXTRoffset);
                    byte[] bigBuffer = new byte[ChunkSize - remainingChunkSize]; //Lets hope that there isn't too much...
                    origStream.BaseStream.Read(bigBuffer, 0, bigBuffer.Length);
                    fileStream.Write(bigBuffer);

                    //Copy new PNGs from Resource to TempFile in pos
                    for (int i = 0; i < ResourcePath.Length; i++)
                    {
                        fileStream.BaseStream.Position = offsetsLong[i + ChunkAmount] - TXTRoffset;
                        fileStream.Write(ResourceManager.GetBytes(ResourcePath[i]));
                    }

                    //Pading fix for successor chunks
                    for (int i = 0; i < PaddingFix; i++)
                        fileStream.BaseStream.WriteByte(0);

                    //Reading, realloc pointers, and writing following Chunks (AUDO)
                    foreach (KeyValuePair<string, long> successorOffs in successorChunks)
                    {
                        fileStream.Write(Encoding.ASCII.GetBytes(successorOffs.Key));
                        origStream.BaseStream.Position = successorOffs.Value;
                        int successorSize = origStream.ReadInt32();
                        int successorChunkAmount = origStream.ReadInt32();
                        fileStream.Write(successorSize);
                        fileStream.Write(successorChunkAmount);
                        for (int i = 0; i < successorChunkAmount; i++)
                        {
                            fileStream.Write(origStream.ReadInt32() + chunkSizeIncrease);
                        }
                        bigBuffer = new byte[successorSize - (4 + (successorChunkAmount * 4))];
                        origStream.Read(bigBuffer, 0, bigBuffer.Length);
                        fileStream.Write(bigBuffer);
                    }
                }
            }

            if (!File.Exists("tmp.dat"))
                throw new FileNotFoundException("tmp.dat not found!");

            //Pushing new chunks to original file
            using (BinaryWriter finalWinStream = new BinaryWriter(new FileStream(IFFfile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None) { Position = TXTRoffset }))
            using (FileStream tmpStream = new FileStream("tmp.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                tmpStream.CopyTo(finalWinStream.BaseStream);
                File.Delete("tmp.dat");
                finalWinStream.BaseStream.Position = 4;
                finalWinStream.Write(NewTotalFileSize);
            }
        }
    }
}
