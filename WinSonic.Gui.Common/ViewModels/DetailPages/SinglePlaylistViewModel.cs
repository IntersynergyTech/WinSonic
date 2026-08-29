using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Playback;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels.DetailPages;

public partial class SinglePlaylistViewModel : PageModelBase
{
    private readonly IPlaylistService _playlistService;
    private readonly AutoPlaybackManager _autoPlaybackManager;
    private readonly ILogger<SinglePlaylistViewModel> _logger;

    [ObservableProperty] public partial PlaylistInfo PlaylistInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<Song> Songs { get; set; } = new ();
    [ObservableProperty] public partial CoverArtViewModel CoverArt { get; set; }


    public void SetPlaylist(PlaylistInfo playlistInfo)
    {
        PlaylistInfo = playlistInfo;
        CoverArt.CoverArtId = playlistInfo.CoverArtId;
        _logger.LogDebug("Loading playlist: {playlistName}", playlistInfo.Name);
    }

    public SinglePlaylistViewModel(IPlaylistService playlistService, AutoPlaybackManager autoPlaybackManager, CoverArtViewModel coverArtViewModel, ILogger<SinglePlaylistViewModel> logger)
    {
        _playlistService = playlistService;
        _autoPlaybackManager = autoPlaybackManager;
        CoverArt = coverArtViewModel;
        _logger = logger;
    }

    public override void OnLoaded()
    {
        _logger.LogTrace("SinglePlaylistViewModel OnLoadCommand called");
        Task.Run(async () =>
        {
            if (PlaylistInfo != null)
            {
                var fullPlaylist = await _playlistService.GetPlaylistByIdAsync(PlaylistInfo.Id);
                Songs = new ObservableCollection<Song>(fullPlaylist.Entries);
            }
        });
    }


    [RelayCommand]
    public void PlayPlaylist(bool shuffle = false)
    {
        if (PlaylistInfo == null) return;

        _logger.LogDebug("Playing playlist: {playlistName}, Shuffle: {shuffle}", PlaylistInfo.Name, shuffle);

        _autoPlaybackManager.Queue.ResetAndEnqueueFromSource(Songs, shuffle);
        _autoPlaybackManager.StartPlayback();
    }
}
