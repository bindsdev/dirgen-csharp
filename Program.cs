using Dirgen;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

Prompt.ThrowExceptionOnCancel = true;

try
{
    var toGenerate = Prompt.Select<GenerateOptions>("What do you want to generate?");

    switch (toGenerate)
    {
        case GenerateOptions.Files:
            GenerateFiles.Execute();
            break;
        case GenerateOptions.Directories:
            GenerateDirectories.Execute();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}
catch (PromptCanceledException)
{
    Console.WriteLine("Prompt cancelled.");
}

enum GenerateOptions
{
    [Display(Name = "Files")]
    Files,
    [Display(Name = "Directories")]
    Directories,
}