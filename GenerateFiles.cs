namespace Dirgen
{
    public class GenerateFiles
    {
        public static void Execute()
        {
            var where = Prompt.Input<string>("Where do you want to generate these files? Insert a path.", defaultValue: "./");

            try
            {
                Directory.SetCurrentDirectory(where);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified directory does not exist.");
            }

            var filesToCreate = Prompt.List<string>("Enter filenames, including extensions");
            uint filesCreatedCount = 0;

            foreach (var filename in filesToCreate)
            {
                if (!File.Exists(filename))
                {
                    File.Create(filename);
                    filesCreatedCount += 1;
                }
                else
                {
                    Console.WriteLine($"File \"{filename}\" already exists!");
                    continue;
                }
            }

            Console.WriteLine($"Created {filesCreatedCount} file(s) in \"{Directory.GetCurrentDirectory()}\"!");
        }
    }
}