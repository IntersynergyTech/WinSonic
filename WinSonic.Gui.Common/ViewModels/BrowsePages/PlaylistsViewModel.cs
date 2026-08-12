using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels.BrowsePages;

public partial class PlaylistsViewModel : PageModelBase
{
    private readonly IPlaylistService _playlistService;

    [ObservableProperty] public partial ObservableCollection<PlaylistInfo> Playlists { get; set; } = new ();
    
    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(NavigateToPlaylistDetailCommand))]
    public partial PlaylistInfo? SelectedPlaylist { get; set; }

    [RelayCommand(CanExecute = nameof(PlaylistIsSelected))]
    public async Task NavigateToPlaylistDetailAsync(CancellationToken token)
    {
        if (SelectedPlaylist == null) return;

        var detailViewModel = DependencyService.Services.GetService<SinglePlaylistViewModel>();
        detailViewModel!.SetPlaylist(SelectedPlaylist);
        NavigationService.NavigateTo(detailViewModel);
    }

    private bool PlaylistIsSelected() => SelectedPlaylist != null;

    public PlaylistsViewModel(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    public override void OnLoaded()
    {
        Task.Run(async () =>
            {
                var playlists = await _playlistService.GetPlaylistsAsync();
                Playlists = new ObservableCollection<PlaylistInfo>(playlists);
            }
        );
    }

}
