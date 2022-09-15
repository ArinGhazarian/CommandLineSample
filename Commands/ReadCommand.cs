using System.CommandLine;
using CommandLineSample.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineSample.Commands;

public class ReadCommand : BaseCommand<ReadCommandArgs, ReadCommandHandler>
{
    public ReadCommand() : base("read", "Read and display the file.")
    {
        AddOption(File);
        AddOption(Delay);
        AddOption(ForegroundColor);
        AddOption(LightMode);
    }

    public Option<FileInfo> File { get; } = new(
        name: "--file",
        description: "The file to read and display on the console.");

    public Option<int> Delay { get; } = new(
        name: "--delay",
        description: "Delay between lines, specified as milliseconds per character in a line.",
        getDefaultValue: () => 42);

    public Option<ConsoleColor> ForegroundColor { get; } = new(
        name: "--fgcolor",
        description: "Foreground color of text displayed on the console.",
        getDefaultValue: () => ConsoleColor.White);

    public Option<bool> LightMode { get; } = new(
        name: "--light-mode",
        description: "Background color of text displayed on the console: default is black, light mode is white.");

    public Option<string> ApiUrl { get; } = new("--api-url") { IsRequired = false };

    public Option<string> GithubPat { get; } = new("--github-pat") { IsRequired = false };

    public ReadCommandHandler BuildHandler(ReadCommandArgs args, ServiceProvider sp)
    {
        // this is the replacement for factories/custom-binders
        return new ReadCommandHandler(sp.GetService<Logger>(), new GithubClient(sp.GetService<Logger>(), sp.GetService<HttpClient>(), args.ApiUrl, args.GithubPat));
    }
}

public class ReadCommandArgs : ICommandArgs
{
    public FileInfo File { get; set; }
    public int Delay { get; set; }
    public ConsoleColor ForegroundColor { get; set; }
    public bool LightMode { get; set; }
    public string ApiUrl { get; set; }
    public string GithubPat { get; set; }
}