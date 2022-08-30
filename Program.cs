global using Sharprompt;
using Dirgen;

var toGenerate = Prompt.Input<string>("What do you want to generate?");

switch (toGenerate)
{
    case "files" or "file":
        GenerateFiles.Execute();
        break;
    case "directories" or "folders" or "directory" or "folder":
        GenerateDirectories.Execute();
        break;
    default:
        throw new ArgumentOutOfRangeException();
}