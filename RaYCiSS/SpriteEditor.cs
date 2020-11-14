using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RaYCiSS
{
    public static class SpriteEditor
    {
        public static void AlterAllSprites(string IFFfile, Dictionary<string, long> dictionary, int PrevTextureAmount)
        {
            List<Sprite> sprites = new List<Sprite>();

            //Get all Sprites first
            using (BinaryReader fileStream = new BinaryReader(new FileStream(IFFfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                fileStream.BaseStream.Position = dictionary["SPRT"];
                int ChunkSize = fileStream.ReadInt32();
                int ChunkAmount = fileStream.ReadInt32();
                int[] ChunksOffs = new int[ChunkAmount];
                for (int i=0; i<ChunkAmount; i++)
                {
                    ChunksOffs[i] = fileStream.ReadInt32();
                }

                foreach (int chunoff in ChunksOffs)
                {
                    fileStream.BaseStream.Position = chunoff;
                    int stringOff = fileStream.ReadInt32();
                    fileStream.BaseStream.Seek(72, SeekOrigin.Current);
                    int[] tpagoffs = new int[fileStream.ReadInt32()];
                    for (int i = 0; i < tpagoffs.Length; i++)
                        tpagoffs[i] = fileStream.ReadInt32();
                    fileStream.BaseStream.Position = stringOff;
                    string spritename = "";
                    char spritechar;
                    while ((spritechar = fileStream.ReadChar()) != 0)
                        spritename += spritechar;
                    sprites.Add(new Sprite(chunoff, spritename, tpagoffs));
                }
            }

            //Find the to patch Sprites
            sprites = sprites.OrderBy((s) => s.SpriteName).ToList();
            string missingSprites = "";
            Sprite sBackEnding = null;
            Sprite sGamemaster_parts = null;
            Sprite sHoplite_parts = null;
            Sprite sHoplite_parts_hard = null;
            Sprite sPirate1_parts = null;
            Sprite sPirate2_parts = null;
            Sprite sSpacedashEditor = null;
            Sprite sSpaceflyerEditor = null;
            Sprite sSpacepirateParts = null;
            Sprite sStatue = null;

            try
            {
                sBackEnding = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sBackEnding", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sBackEnding ";
            }

            try
            {
                sGamemaster_parts = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sGamemaster_parts", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sGamemaster_parts ";
            }

            try
            {
                sHoplite_parts = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sHoplite_parts", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sHoplite_parts ";
            }

            try
            {
                sHoplite_parts_hard = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sHoplite_parts_hard", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sHoplite_parts_hard ";
            }

            try
            {
                sPirate1_parts = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sPirate1_parts", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sPirate1_parts ";
            }

            try
            {
                sPirate2_parts = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sPirate2_parts", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sPirate2_parts ";
            }

            try
            {
                sSpacedashEditor = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sSpacedashEditor", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sSpacedashEditor ";
            }

            try
            {
                sSpaceflyerEditor = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sSpaceflyerEditor", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sSpaceflyerEditor ";
            }

            try
            {
                sSpacepirateParts = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sSpacepirateParts", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sSpacepirateParts ";
            }

            try
            {
                sStatue = sprites.ElementAt(sprites.BinarySearch(new Sprite(0, "sStatue", null), new SpriteComparer()));
            }
            catch (Exception)
            {
                missingSprites += " sStatue ";
            }

            if (missingSprites != "")
                throw new Exception($"One or more sprites are missing: {missingSprites}");

            //Start altering sprites from older version
            using (FileStream fileStream = new FileStream(IFFfile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                EditSprite(SsBackEnding.GetSpriteData, sBackEnding, fileStream, PrevTextureAmount);
                EditSprite(SsGamemaster_parts.GetSpriteData, sGamemaster_parts, fileStream, PrevTextureAmount);
                EditSprite(SsHoplite_parts.GetSpriteData, sHoplite_parts, fileStream, PrevTextureAmount);
                EditSprite(SsHoplite_parts_hard.GetSpriteData, sHoplite_parts_hard, fileStream, PrevTextureAmount);
                EditSprite(SsPirate1_parts.GetSpriteData, sPirate1_parts, fileStream, PrevTextureAmount);
                EditSprite(SsPirate2_parts.GetSpriteData, sPirate2_parts, fileStream, PrevTextureAmount);
                EditSprite(SsSpacedashEditor.GetSpriteData, sSpacedashEditor, fileStream, PrevTextureAmount);
                EditSprite(SsSpaceflyerEditor.GetSpriteData, sSpaceflyerEditor, fileStream, PrevTextureAmount);
                EditSprite(SsSpacepirateParts.GetSpriteData, sSpacepirateParts, fileStream, PrevTextureAmount);
                EditSprite(SsStatue.GetSpriteData, sStatue, fileStream, PrevTextureAmount);
            }
        }

        private static void EditSprite(ISpriteData newSprite, Sprite origSprite, FileStream fileStream, int PrevTextureAmount)
        {
            fileStream.Position = origSprite.Offset + 4;
            fileStream.Write(newSprite.SPRTData, 0, newSprite.SPRTData.Length);
            for (int i = 0; i < origSprite.TPAGAmount; i++)
            {
                fileStream.Position = origSprite.TPAGOffsets[i];
                for (int j = 0; j < newSprite.TPAGData.GetLength(1) - 2; j++)
                    fileStream.WriteByte(newSprite.TPAGData[i, j]);
                fileStream.WriteByte((byte)((newSprite.TPAGData[i, 20] - 4) + PrevTextureAmount));
            }
        }

        internal class SpriteComparer : IComparer<Sprite>
        {
            public int Compare(Sprite x, Sprite y)
            {
                return string.Compare(x.SpriteName, y.SpriteName);
            }
        }

        internal class Sprite
        {
            public int Offset { get; }
            public string SpriteName { get; }
            public int TPAGAmount { get; }
            public int[] TPAGOffsets { get; }

            public Sprite(int Offset, string SpriteName, int[] TPAGOffsets)
            {
                this.Offset = Offset; this.SpriteName = SpriteName;
                TPAGAmount = (TPAGOffsets != null) ? TPAGOffsets.Length : 0;
                this.TPAGOffsets = TPAGOffsets;
            }
        }
    }
}
