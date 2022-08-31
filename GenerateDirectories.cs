namespace Dirgen
{
    public class GenerateDirectories
    {
        public static void Execute()
        {
            var where = Prompt.Input<string>("Where do you want to generate these directories? Insert a path.", defaultValue: "./");

            try
            {
                Directory.SetCurrentDirectory(where);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified directory does not exist.");
            }

            var dirsToCreate = Prompt.List<string>("Enter directory names");
            uint dirsCreatedCount = 0;

            // implement here

            Console.WriteLine($"Created {dirsCreatedCount} directories in \"{Directory.GetCurrentDirectory()}\"!");
        }
    }
}