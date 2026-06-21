using WinSonic.Subsonic.Client.Client;

namespace WinSonic.Subsonic.Helpers;

public class SubsonicConnectionBuilder
{
    private Configuration config = new();
    private const string SUBSONIC_API_VERSION = "1.16.1";
    private const string API_CLIENT_NAME = "winsonic";
    private const string API_FORMAT = "json";
    private const string ENV_SUBSONIC_URL = "SUBSONIC_URL";

    public SubsonicConnectionBuilder()
    {
        ApplyCommon();
    }
    
    public SubsonicConnectionBuilder WithServerUrl(string url)
    {
        config.BasePath = url;
        return this;
    }

    public SubsonicConnectionBuilder WithUsernameAndPassword(string username, string password)
    {
        config.ApiKey["p"] = password;
        config.ApiKey["u"] = username;
        return this;
    }

    public SubsonicConnectionBuilder WithDefaultUserCredentials()
    {
        var defaultUrl = Environment.GetEnvironmentVariable(ENV_SUBSONIC_URL) ?? "http://localhost:4040";
        return WithUsernameAndPassword("winsonic", "winsonic").WithServerUrl(defaultUrl);
    }

    private void ApplyCommon()
    {
        config.ApiKey["v"] = SUBSONIC_API_VERSION;
        config.ApiKey["c"] = API_CLIENT_NAME;
        config.ApiKey["f"] = API_FORMAT;
    }
    
    public SubsonicApiWrapper Build()
    {
        
        
        var instance = new SubsonicApiWrapper(config);
        return instance;
    }
}
