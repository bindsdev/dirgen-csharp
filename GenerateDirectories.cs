using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace Dirgen
{
    public class GenerateDirectories
    {
        public static void Execute()
        {
            var where = Prompt.Input<string>("Where do you want to generate these directories? Insert a path", defaultValue: "./");

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

            var mode = Prompt.Select<GenerationMode>("How would you like to generate these directories?", defaultValue: GenerationMode.Normal);

            switch (mode)
            {
                case GenerationMode.Normal:
                    GenerateNormally();
                    return;
                case GenerationMode.Recursive:
                    GenerateRecursively();
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        static void GenerateNormally()
        {
            var dirsToGenerate = Prompt.List<string>("Enter directory names");
            uint dirsGeneratedCount = 0;

            foreach (var dir in dirsToGenerate)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    dirsGeneratedCount += 1;
                }
                else
                {
                    Console.WriteLine($"Directory \"{dir}\" already exists!");
                    continue;
                }
            }

            Console.WriteLine($"Generated {dirsGeneratedCount} {(dirsGeneratedCount > 1 ? "directories" : "directory")} in \"{Directory.GetCurrentDirectory()}\"!");
        }

        static void GenerateRecursively()
        {
            var dirsToGenerate = Prompt.List<string>("Enter directory names");
            uint dirsGeneratedCount = 0;

            // implement here

            Console.WriteLine($"Generated {dirsGeneratedCount} directories in \"{Directory.GetCurrentDirectory()}\"!");
        }

        enum GenerationMode
        {
            [Display(Name = "Normal")]
            Normal,
            [Display(Name = "Recursive")]
            Recursive
        }
    }
}