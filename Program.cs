using Sharprompt;
using Dirgen;

var toCreate = Prompt.Input<string>("What do you want to create?");

switch (toCreate) 
{
    case "files":
        break;
    case "directories" or "folders":
        break;
    default:
        throw new ArgumentOutOfRangeException();
}