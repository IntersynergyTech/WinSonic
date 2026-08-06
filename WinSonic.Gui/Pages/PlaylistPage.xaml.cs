using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using WinSonic.Core.Models;
using WinSonic.Service.Playlist;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;

namespace WinSonic.Gui.Pages;

public partial class PlaylistPage : Page, INavigationAware
{
    public PlaylistFull PlaylistFull { get; set; }
    public PlaylistInfo PlaylistInfo { get; set; }

    private readonly IPlaylistService _playlistService;
    private readonly ILogger<PlaylistPage> _logger;
    private readonly INavigationService _navigationService;

    public PlaylistPage(IPlaylistService playlistService, ILogger<PlaylistPage> logger, INavigationService navigationService)
    {
        _playlistService = playlistService;
        _logger = logger;
        _navigationService = navigationService;
        DataContext = this;
        InitializeComponent();
    }
    
    public void LoadPlaylist(PlaylistInfo  playlistInfo)
    {
        _logger.LogDebug("Will load playlist {PlaylistId} - {PlaylistName} after nav", playlistInfo.Id, playlistInfo.Name);
        PlaylistInfo = playlistInfo;
    }

    public async Task OnNavigatedToAsync()
    {
        if (PlaylistInfo != null)
        {
            _logger.LogDebug("OnNavigated - Loading playlist {PlaylistId} - {PlaylistName} after nav", PlaylistInfo.Id, PlaylistInfo.Name);
            PlaylistFull = await _playlistService.GetPlaylistByIdAsync(PlaylistInfo.Id);
            _logger.LogDebug("OnNavigated - Loaded playlist");
        }
        else
        {
            var navControl = _navigationService.GetNavigationControl();
            _logger.LogWarning("OnNavigated - PlaylistInfo is null, cannot load playlist");
        }
    }

    public Task OnNavigatedFromAsync()
    {
        return Task.CompletedTask;
    }
}

