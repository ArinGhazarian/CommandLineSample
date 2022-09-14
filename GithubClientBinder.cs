using System.CommandLine;
using System.CommandLine.Binding;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineSample;

public class GithubClientBinder : BinderBase<GithubClient>
{
    private readonly ServiceProvider _sp;
    private readonly Option<string?> _githubPatOption;
    private readonly Option<string?> _apiUrlOption;

    public GithubClientBinder(ServiceProvider sp, Option<string?> apiUrlOption, Option<string?> githubPatOption)
    {
        _sp = sp;
        _apiUrlOption = apiUrlOption;
        _githubPatOption = githubPatOption;
    }
    
    protected override GithubClient GetBoundValue(BindingContext bindingContext)
    {
        var apiUrl = bindingContext.ParseResult.GetValueForOption(_apiUrlOption);
        var githubPat = bindingContext.ParseResult.GetValueForOption(_githubPatOption);
        var httpClient = _sp.GetRequiredService<HttpClient>();
        var logger = _sp.GetRequiredService<Logger>();
        return new GithubClient(logger, httpClient, apiUrl, githubPat);
    }
    
}