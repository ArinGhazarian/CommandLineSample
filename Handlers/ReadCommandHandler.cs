using CommandLineSample.Commands;

namespace CommandLineSample.Handlers;

public class ReadCommandHandler : ICommandHandler<ReadCommandArgs>
{
    private readonly Logger _logger;
    private readonly GithubClient _githubClient;

    public ReadCommandHandler(Logger logger, GithubClient githubClient)
    {
        _logger = logger;
        _githubClient = githubClient;
    }

    public async Task Handle(ReadCommandArgs args)
    {
        _logger.LogInfo(args.LightMode.ToString());
        _logger.LogInfo(args.ForegroundColor.ToString());
        _logger.LogInfo(args.File?.FullName ?? "");
        
        await _githubClient.GetAll("id");
    }
}