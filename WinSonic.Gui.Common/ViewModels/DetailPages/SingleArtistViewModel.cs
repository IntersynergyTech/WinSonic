using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Playback;
using WinSonic.Service.Artist;

namespace WinSonic.Gui.Common.ViewModels.DetailPages;

public partial class SingleArtistViewModel : PageModelBase
{
    private readonly IArtistService _artistService;
    private readonly AutoPlaybackManager _autoPlaybackManager;

    [ObservableProperty] public partial Artist? ArtistInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<AlbumInfo> Albums { get; set; } = new();
    [ObservableProperty] public partial ObservableCollection<Song> Songs { get; set; } = new();
    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(NavigateToAlbumDetailCommand))]
    public partial AlbumInfo? SelectedAlbum { get; set; }

    public SingleArtistViewModel(IArtistService artistService, AutoPlaybackManager autoPlaybackManager)
    {
        _artistService = artistService;
        _autoPlaybackManager = autoPlaybackManager;
    }

    public void SetArtist(Artist artistInfo)
    {
        ArtistInfo = artistInfo;
        Console.WriteLine($"Loading artist: {artistInfo.Name}");
    }

    public override void OnLoaded()
    {
        Task.Run(async () =>
        {
            if (ArtistInfo == null)
            {
                return;
            }

            var songsTask = _artistService.GetSongsByArtistAsync(ArtistInfo.Id);
            var albumsTask = _artistService.GetAlbumsByArtistAsync(ArtistInfo.Id);

            await Task.WhenAll(songsTask, albumsTask);

            Songs = new ObservableCollection<Song>(songsTask.Result);
            Albums = new ObservableCollection<AlbumInfo>(albumsTask.Result);
        });
    }

    [RelayCommand]
    public void PlayArtist(bool shuffle = false)
    {
        if (ArtistInfo == null) return;

        _autoPlaybackManager.Queue.ResetAndEnqueueFromSource(Songs, shuffle);
        _autoPlaybackManager.StartPlayback();
    }

    [RelayCommand(CanExecute = nameof(AlbumIsSelected))]
    public async Task NavigateToAlbumDetailAsync()
    {
        if (SelectedAlbum == null) return;

        var detailViewModel = DependencyService.Services.GetService<SingleAlbumViewModel>();
        detailViewModel!.SetAlbum(SelectedAlbum);
        NavigationService.NavigateTo(detailViewModel);
    }

    private bool AlbumIsSelected() => SelectedAlbum != null;
}
