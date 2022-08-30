namespace Dirgen
{
    public class GenerateFiles
    {
        public static void Execute()
        {
            var filesToCreate = Prompt.Input<List<string>>("Enter filenames here, including extensions");

            foreach (var filename in filesToCreate)
            {
                if (!File.Exists(filename))
                {
                    File.Create(filename);
                }
                else
                {
                    Console.WriteLine($"File \"{filename}\" already exists!");
                    continue;
                }
            }
        }
    }
}