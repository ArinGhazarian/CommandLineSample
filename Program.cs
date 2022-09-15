using System.CommandLine;
using System.CommandLine.Binding;
using CommandLineSample.Commands;
using CommandLineSample.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineSample;

public static class Program
{
    private static async Task<int> Main(string[] arguments)
    {
        var serviceCollection = new ServiceCollection();
        _ = serviceCollection
            .AddSingleton<Logger>()
            .AddHttpClient();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        
        //var readCommand = new ReadCommand();
        //readCommand.SetHandler(async (args, logger, client) => await new ReadCommandHandler(logger, client).Handle(args),
        //    new GenericArgsBinder<ReadCommandOptions, ReadCommandArgs>(readCommand.Options),
        //    new GenericServiceBinder<Logger>(serviceProvider), 
        //    new GithubClientBinder(serviceProvider, readCommand.Options.ApiUrl, readCommand.Options.GithubPat));

        
        // *************************************
        var commands = FindAllCommands();
        
        foreach (var command in commands)
        {
            var argsBinder = CreateArgsBinder(command);  // e.g. new GenericArgsBinder<ReadCommand, ReadCommandArgs>(command);

            command.SetHandler(async args => await command.BuildHandler(args, serviceProvider).Handle(args), argsBinder);

            rootCommand.AddCommand(command);
        }
        // *************************************

        return await rootCommand.InvokeAsync(arguments);
    }

    private static BinderBase<ICommandArgs> CreateArgsBinder(BaseCommand<ICommandArgs, ICommandHandler<ICommandArgs>> command)
    {
        Activator.CreateInstance
    }

    private static IEnumerable<BaseCommand<ICommandArgs, ICommandHandler<ICommandArgs>>> FindAllCommands()
    {
        throw new NotImplementedException();
    }
}