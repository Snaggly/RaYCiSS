using System;
using System.IO;
using System.Text;

namespace RaYCiSS
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to RaYCiSS!");
            Console.WriteLine("This program will uncensor what is deemed as racist.\n\n\n");

            Console.WriteLine("==============================================================");
            Console.WriteLine("DISCLAMER: Racism is NOT ok! If you feel needing to harass,");
            Console.WriteLine("attack or discriminate people based purely on skin color or");
            Console.WriteLine("looks I advise you to contact your local authorities.\n");

            Console.WriteLine("This program only restores the original design of the space");
            Console.WriteLine("pirates in Rayman Redemption. The program itself has no racist");
            Console.WriteLine("motive!");
            Console.WriteLine("It is only for preservation of what has been previously available.\n");

            Console.WriteLine("Do NOT use this program if you feel offended by alienated");
            Console.WriteLine("limbless blue characters with big lips!");
            Console.WriteLine("==============================================================");
            Console.WriteLine("\n\n\n");

            string FilePath = "";
            if (args.Length <= 0)
            {
                Console.WriteLine("Drag and Drop your data.win file here and press Enter...");
                FilePath = Console.ReadLine();
            }
            else
            {
                FilePath = args[0];
            }

            if (!File.Exists(FilePath))
            {
                Console.WriteLine("File doesn't exist! Press a key to exit.....");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Will now handle " + FilePath);

            if (!FileChecker.CheckFORM(FilePath))
            {
                Console.WriteLine("FORM not found. Invalid file!");
                Console.WriteLine("Press a Key to exit....");
                Console.ReadKey();
            }

            Console.WriteLine("Mapping Chunks....");
            var ChunksList = Mapper.GetDictionary(FilePath);
            int PreviousTextureAmount = Mapper.GetTextureAmount(FilePath, ChunksList);

            if (!FileChecker.CheckRaymanRedemption(FilePath, ChunksList["GEN8"]))
            {
                Console.WriteLine("This doesn't seem to be a 'RaymanRedemption' data.win file!");
                Console.WriteLine("Press a Key to exit....");
                Console.ReadKey();
            }

            Console.WriteLine("Creating Backup....");
            int i = 0;
            for (; File.Exists("data_backup" + i.ToString() + ".win"); i++){}
            File.Copy(FilePath, "data_backup" + i.ToString() + ".win");

            Console.WriteLine("Injecting Textures....");
            try
            {
                TXTRInjector injector = new TXTRInjector(FilePath, ChunksList);
                injector.InjectDatasFromResource(ResourceManager.GetResources());
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occured: {e.Message}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Altering Sprites....");
            try
            {
                SpriteEditor.AlterAllSprites(FilePath, ChunksList, PreviousTextureAmount);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occured: {e.Message}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Done!\n\n");
            Console.WriteLine("Use the backed up file if you want to revert to the the");
            Console.WriteLine("new design or if something went wrong!");

            Console.ReadKey();
        }
    }
}
