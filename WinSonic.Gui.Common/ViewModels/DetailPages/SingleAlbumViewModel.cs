using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WinSonic.Core.Models;
using WinSonic.Playback;
using WinSonic.Service.Album;

namespace WinSonic.Gui.Common.ViewModels.DetailPages;

public partial class SingleAlbumViewModel : PageModelBase
{
    private readonly IAlbumService _albumService;
    private readonly AutoPlaybackManager _autoPlaybackManager;

    [ObservableProperty] public partial AlbumInfo? AlbumInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<Song> Songs { get; set; } = new();

    public SingleAlbumViewModel(IAlbumService albumService, AutoPlaybackManager autoPlaybackManager)
    {
        _albumService = albumService;
        _autoPlaybackManager = autoPlaybackManager;
    }

    public void SetAlbum(AlbumInfo albumInfo)
    {
        AlbumInfo = albumInfo;
        Console.WriteLine($"Loading album: {albumInfo.Title}");
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
