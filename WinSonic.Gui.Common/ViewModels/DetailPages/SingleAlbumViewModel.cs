using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Playback;
using WinSonic.Service.Album;

namespace WinSonic.Gui.Common.ViewModels.DetailPages;

public partial class SingleAlbumViewModel : PageModelBase
{
    private readonly IAlbumService _albumService;
    private readonly AutoPlaybackManager _autoPlaybackManager;
    private readonly ILogger<SingleAlbumViewModel> _logger;
    [ObservableProperty] public partial CoverArtViewModel CoverArt { get; set; }
    [ObservableProperty] public partial AlbumInfo? AlbumInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<Song> Songs { get; set; } = new();

    public SingleAlbumViewModel(IAlbumService albumService, AutoPlaybackManager autoPlaybackManager, CoverArtViewModel coverArtViewModel, ILogger<SingleAlbumViewModel> logger)
    {
        _albumService = albumService;
        _autoPlaybackManager = autoPlaybackManager;
        _logger = logger;
        CoverArt = coverArtViewModel;
    }

    public void SetAlbum(AlbumInfo albumInfo)
    {
        AlbumInfo = albumInfo;
        CoverArt.CoverArtId = albumInfo.CoverArtId;
        _logger.LogDebug($"Loading album: {albumInfo.Title}");
    }

    public override void OnLoaded()
    {
        Task.Run(async () =>
        {
            if (AlbumInfo == null)
            {
                return;
            }

            var fullAlbum = await _albumService.GetAlbumByIdAsync(AlbumInfo.Id);
            Songs = new ObservableCollection<Song>(fullAlbum.Songs);
        });
    }

    [RelayCommand]
    public void PlayAlbum(bool shuffle = false)
    {
        if (AlbumInfo == null) return;

        _autoPlaybackManager.Queue.ResetAndEnqueueFromSource(Songs, shuffle);
        _autoPlaybackManager.StartPlayback();
    }
}
