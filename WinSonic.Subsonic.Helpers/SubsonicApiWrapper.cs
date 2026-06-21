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

    public AdditionApi Addition
    {
        get { return field ??= new AdditionApi(_configuration); }
    }
    public BookmarksApi Bookmarks
    {
        get { return field ??= new BookmarksApi(_configuration); }
    }
    public BrowsingApi Browsing
    {
        get { return field ??= new BrowsingApi(_configuration); }
    }
    public ChangeApi Change
    {
        get { return field ??= new ChangeApi(_configuration); }
    }
    public ChatApi Chat
    {
        get { return field ??= new ChatApi(_configuration); }
    }
    public ClarificationApi Clarification
    {
        get { return field ??= new ClarificationApi(_configuration); }
    }
    public ExtensionApi Extension
    {
        get { return field ??= new ExtensionApi(_configuration); }
    }
    public InternetRadioApi InternetRadio
    {
        get { return field ??= new InternetRadioApi(_configuration); }
    }
    public JukeboxApi Jukebox
    {
        get { return field ??= new JukeboxApi(_configuration); }
    }
    public ListsApi Lists
    {
        get { return field ??= new ListsApi(_configuration); }
    }
    public MediaAnnotationApi MediaAnnotation
    {
        get { return field ??= new MediaAnnotationApi(_configuration); }
    }
    public MediaLibraryScanningApi MediaLibraryScanning
    {
        get { return field ??= new MediaLibraryScanningApi(_configuration); }
    }
    public MediaRetrievalApi MediaRetrieval
    {
        get { return field ??= new MediaRetrievalApi(_configuration); }
    }
    public PlaylistsApi Playlists
    {
        get { return field ??= new PlaylistsApi(_configuration); }
    }
    public PodcastApi Podcast
    {
        get { return field ??= new PodcastApi(_configuration); }
    }
    public SearchingApi Searching
    {
        get { return field ??= new SearchingApi(_configuration); }
    }
    public SharingApi Sharing
    {
        get { return field ??= new SharingApi(_configuration); }
    }
    public SystemApi System
    {
        get { return field ??= new SystemApi(_configuration); }
    }
    public TranscodingApi Transcoding
    {
        get { return field ??= new TranscodingApi(_configuration); }
    }
    public UserManagementApi UserManagement
    {
        get { return field ??= new UserManagementApi(_configuration); }
    }
}
