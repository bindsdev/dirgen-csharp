namespace Dirgen
{
    public class GenerateDirectories
    {
        public static void Execute()
        {
            var dirsToCreate = Prompt.Input<List<string>>("Enter directory names here");
        }
    }
}