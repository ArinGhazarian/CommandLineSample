namespace CommandLineSample;

public class GithubClient
{
    private readonly string? _apiUrl;
    private readonly string? _pat;
    private readonly Logger _log;
    private readonly HttpClient _httpClient;

    public GithubClient(Logger log, HttpClient httpClient, string? apiUrl, string? pat)
    {
        _httpClient = httpClient;
        _apiUrl = apiUrl;
        _pat = pat;
        _log = log;
    }

    public async Task GetAll(string id)
    {
        _log.LogInfo($"ID: {id}");
        _log.LogInfo($"API URL: {_apiUrl}");
        _log.LogInfo($"PAT: {_pat}");
        _log.LogInfo($"HTTP CLIENT: {_httpClient}");
        
        await Task.Delay(1);
    }
}