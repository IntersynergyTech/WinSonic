using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;

namespace WinSonic.Subsonic.Helpers;

public class SubsonicApiWrapper
{
    private readonly Configuration _configuration;
    
    public SubsonicApiWrapper(Configuration configuration)
    {
        _configuration = configuration;
        Client.Client.GlobalConfiguration.Instance = configuration;
    }

    private AdditionApi? _addition;
    public AdditionApi Addition
    {
        get
        {
            return _addition ??= new AdditionApi(_configuration);
        }
    }
    
    private PlaylistsApi? _playlists;
    public PlaylistsApi Playlists
    {
        get
        {
            return _playlists ??= new PlaylistsApi(_configuration);
        }
    }
}
