using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using WinSonic.Core.Models;
using WinSonic.Service.Playlist;
using Wpf.Ui.Abstractions.Controls;

namespace WinSonic.Gui.Pages;

public partial class ServiceTest : Page, INavigationAware
{
    private readonly IPlaylistService _playlistService;
    private readonly ILogger<ServiceTest> _logger;

    public ObservableCollection<PlaylistInfo> Playlists { get; set; } = new ();

    public ServiceTest(IPlaylistService playlistService, ILogger<ServiceTest> logger)
    {
        DataContext = this;
        InitializeComponent();
        _playlistService = playlistService;
        _logger = logger;
    }

    private async void ServiceTest_OnLoaded(object sender, RoutedEventArgs e)
    {
        var playlists = await _playlistService.GetPlaylistsAsync();
        Playlists.Clear();
        foreach (var playlist in playlists)
        {
            Playlists.Add(playlist);
        }
        _logger.LogDebug("ServiceTest page loaded. Playlists retrieved: {Count}", Playlists.Count);
    }

    public Task OnNavigatedToAsync()
    {
        _logger.LogDebug($"Navigated to ServiceTest page. TAG {Tag}");
        return Task.CompletedTask;
    }

    public Task OnNavigatedFromAsync()
    {
        _logger.LogDebug($"Navigating from ServiceTest page. TAG {Tag}");
        return Task.CompletedTask;
    }
}

