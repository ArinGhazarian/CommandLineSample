using System.CommandLine;
using CommandLineSample.Commands;
using CommandLineSample.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineSample;

public static class Program
{
    private static async Task<int> Main(string[] arguments)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSingleton<Logger>()
            .AddHttpClient();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        
        var readCommand = new ReadCommand();
        readCommand.SetHandler(async (args, logger, client) => await new ReadCommandHandler(logger, client).Handle(args),
            new GenericArgsBinder<ReadCommandOptions, ReadCommandArgs>(readCommand.Options),
            new GenericServiceBinder<Logger>(serviceProvider), 
            new GithubClientBinder(serviceProvider, readCommand.Options.ApiUrl, readCommand.Options.GithubPat));
        
        rootCommand.AddCommand(readCommand);
        
        return await rootCommand.InvokeAsync(arguments);
    }
}