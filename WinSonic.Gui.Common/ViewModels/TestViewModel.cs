using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WinSonic.Core.Models;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels;

public partial class TestViewModel : ViewModelBase
{
    private readonly IPlaylistService _playlistService;
    
    public TestViewModel(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    [ObservableProperty] private ObservableCollection<PlaylistInfo> _playlists;
    
    [RelayCommand]
    public async Task LoadDataAsync(CancellationToken token)
    {
        var playlists = await _playlistService.GetPlaylistsAsync();
        Playlists = new ObservableCollection<PlaylistInfo>(playlists);
    }
    
}
