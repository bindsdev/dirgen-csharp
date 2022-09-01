using Sharprompt;

namespace Dirgen
{
    public class GenerateFiles
    {
        public static void Execute()
        {
            var where = Prompt.Input<string>("Where do you want to generate these file(s)? Insert a path", defaultValue: "./");

            if (!where.Equals("./"))
            {
                try
                {
                    Directory.SetCurrentDirectory(where);
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("The specified directory does not exist.");
                    return;
                }
            }

            var filesToGenerate = Prompt.List<string>("Enter filenames, including extensions");
            uint filesGeneratedCount = 0;

            foreach (var filename in filesToGenerate)
            {
                if (!File.Exists(filename))
                {
                    File.Create(filename);
                    filesGeneratedCount += 1;
                }
                else
                {
                    Console.WriteLine($"File \"{filename}\" already exists!");
                    continue;
                }
            }

            Console.WriteLine($"Generated {filesGeneratedCount} file(s) in \"{Directory.GetCurrentDirectory()}\"!");
        }
    }
}