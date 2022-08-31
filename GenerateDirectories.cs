using System.ComponentModel.DataAnnotations;

namespace Dirgen
{
    public class GenerateDirectories
    {
        public static void Execute()
        {
            var where = Prompt.Input<string>("Where do you want to generate these directories? Insert a path.", defaultValue: "./");

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

            var dirsToCreate = Prompt.List<string>("Enter directory names");
            uint dirsCreatedCount = 0;

            var mode = Prompt.Input<CreationMode>("How would you like to create these directories? If you want to create nested directories, specify recursive mode.", defaultValue: CreationMode.Normal);

            // implement here

            Console.WriteLine($"Created {dirsCreatedCount} directories in \"{Directory.GetCurrentDirectory()}\"!");
        }

        enum CreationMode
        {
            [Display(Name = "Normal")]
            Normal,
            [Display(Name = "Recursive")]
            Recursive
        }
    }
}