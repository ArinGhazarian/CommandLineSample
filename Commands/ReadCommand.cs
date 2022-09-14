using System.CommandLine;

namespace CommandLineSample.Commands;

public class ReadCommand : Command
{
    public ReadCommand() : base("read", "Read and display the file.")
    {
        AddOption(Options.File);
        AddOption(Options.Delay);
        AddOption(Options.ForegroundColor);
        AddOption(Options.LightMode);
    }
    
    public new ReadCommandOptions Options { get; } = new();
}

public class ReadCommandOptions
{
    public Option<FileInfo?> File { get; } = new(
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

    public Option<string?> ApiUrl { get; } = new("--api-url") { IsRequired = false };

    public Option<string?> GithubPat { get; } = new("--github-pat") { IsRequired = false };
}

public class ReadCommandArgs
{
    public FileInfo? File { get; set; }
    public int Delay { get; set; }
    public ConsoleColor ForegroundColor { get; set; }
    public bool LightMode { get; set; }
    public string? ApiUrl { get; set; }
    public string? GithubPat { get; set; }
}