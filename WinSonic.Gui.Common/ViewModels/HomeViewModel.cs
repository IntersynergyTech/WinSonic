using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Playback;
using WinSonic.Service.Album;

namespace WinSonic.Gui.Common.ViewModels;

public partial class HomeViewModel : PageModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia! - Home";

    [ObservableProperty] public partial CoverArtViewModel CoverArtModel { get; set; }
    private readonly AutoPlaybackManager _playbackManager;
    private readonly IAlbumService _albumService;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(PlayQueue))] public partial Song? NowPlaying { get; set; }

    [ObservableProperty] public partial ObservableCollection<PlayQueueItem> PlayQueue { get; set; } = new();
    
    public HomeViewModel(
        CoverArtViewModel coverArtModel,
        AutoPlaybackManager playbackManager,
        IAlbumService albumService
    )
    {
        CoverArtModel = coverArtModel;
        _playbackManager = playbackManager;
        _albumService = albumService;
    }

    public HomeViewModel()
    {
        CoverArtModel = DependencyService.Services.GetService<CoverArtViewModel>()!;
        _playbackManager = DependencyService.Services.GetService<AutoPlaybackManager>()!;
        _albumService = DependencyService.Services.GetService<IAlbumService>()!;
    }

    [RelayCommand]
    private void SettingsViaNavMessenger()
    {
        var settingsModel = DependencyService.Services.GetService<SettingsViewModel>();
        NavigationService.NavigateTo(settingsModel);
    }

    [RelayCommand]
    private void SettingsResolvedViaNav()
    {
        var settingsModel = DependencyService.Services.GetService<SettingsViewModel>();
        NavigationService.NavigateTo(settingsModel);
    }

    private void UpdateNowPlaying(Song? song)
    {
        NowPlaying = song;
        CoverArtModel.CoverArtId = song?.CoverArtId;
        
        var observableQueue = new ObservableCollection<PlayQueueItem>(_playbackManager.Queue.EnumerateQueue());
        PlayQueue = observableQueue;
    }

    public override void OnLoaded()
    {
        _playbackManager.NowPlayingChanged += PlaybackManagerOnNowPlayingChanged;
        UpdateNowPlaying(_playbackManager.NowPlaying);
    }

    public void OnUnloaded()
    {
        _playbackManager.NowPlayingChanged -= PlaybackManagerOnNowPlayingChanged;
    }

    [RelayCommand]
    public void GoToAlbum()
    {
        var albumsViewModel = DependencyService.Services.GetService<SingleAlbumViewModel>();
        albumsViewModel!.SetAlbum(NowPlaying.Album);
        NavigationService.NavigateTo(albumsViewModel);
    }

    private void PlaybackManagerOnNowPlayingChanged(object? sender, Song? e)
    {
        UpdateNowPlaying(e);
    }
}
