using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Enums;
using WinSonic.Data.DbModels;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.Utility;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Playback;
using WinSonic.Service.Album;
using Song = WinSonic.Core.Models.Song;
using Timer = System.Timers.Timer;

namespace WinSonic.Gui.Common.ViewModels.Components;

public partial class PlaybackControlsViewModel : ViewModelBase
{
    private readonly AutoPlaybackManager _autoPlaybackManager;
    private readonly IAlbumService _albumService;
    private bool _suppressUpdates;

    private readonly Timer _updateTimer = new Timer();
    private readonly CommandDebouncer _debouncer = new CommandDebouncer(1000);
    [ObservableProperty] public partial TimeSpan? Position { get; private set; }
    [ObservableProperty] public partial TimeSpan? Duration { get; private set; }

    [ObservableProperty] public partial string? Title { get; private set; }
    [ObservableProperty] public partial string? Artist { get; private set; }
    [ObservableProperty] public partial bool ShowExplicitFlag { get; private set; }

    [ObservableProperty] public partial CoverArtViewModel CoverArt { get; private set; }

    [ObservableProperty] public partial PlaybackState? PlaybackState { get; private set; }

    [ObservableProperty] public partial double? SliderDuration { get; private set; }
    private double? _sliderCurrent;

    public double? SliderCurrent
    {
        get => _sliderCurrent;
        set
        {
            SetProperty(ref _sliderCurrent, value);

            if (!_suppressUpdates)
            {
                _autoPlaybackManager.Player.CurrentPosition = TimeSpan.FromSeconds(value.Value);
            }
        }
    }

    public float Volume
    {
        get => _autoPlaybackManager.Player.Volume;
        set
        {
            _autoPlaybackManager.SetVolume(value);
            OnPropertyChanged();
        }
    }

    public bool IsMuted
    {
        get => _autoPlaybackManager.Player.IsMuted;
        set
        {
            _autoPlaybackManager.Player.IsMuted = value;
            OnPropertyChanged();
        }
    }

    public PlaybackControlsViewModel(AutoPlaybackManager autoPlaybackManager, IAlbumService albumService)
    {
        _autoPlaybackManager = autoPlaybackManager;
        _albumService = albumService;
    }

    public void Init()
    {
        _updateTimer.Interval = 500;
        _updateTimer.Elapsed += UpdateTimerOnElapsed;
        _updateTimer.Enabled = true;

        _autoPlaybackManager.NowPlayingChanged += AutoPlaybackManagerOnNowPlayingChanged;

        CoverArt = DependencyService.Services.GetService<CoverArtViewModel>();
        CoverArt.Dimensions = 160;
    }

    private void AutoPlaybackManagerOnNowPlayingChanged(object? sender, Song? e)
    {
        UpdateViewProperties();
    }

    [RelayCommand]
    public void TogglePlayPause()
    {
        if (PlaybackState is Core.Enums.PlaybackState.Playing)
        {
            _autoPlaybackManager.Player.Pause();
        }
        else
        {
            _autoPlaybackManager.Player.Play();
        }
    }

    [RelayCommand]
    public void NextTrack()
    {
        _autoPlaybackManager.NextSong();
    }

    [RelayCommand]
    public void PreviousTrack()
    {
    }

    [RelayCommand]
    public void ToggleShuffle()
    {
    }

    [RelayCommand]
    public void ToggleRepeat()
    {
    }

    [RelayCommand]
    public void GoToAlbum()
    {
        if (_autoPlaybackManager.NowPlaying?.AlbumId == null) return;

        var albumVm = DependencyService.Services.GetService<SingleAlbumViewModel>();
        albumVm!.SetAlbum(_autoPlaybackManager.NowPlaying.Album!);

        NavigationService.NavigateTo(albumVm);
    }

    void UpdateTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        UpdateViewProperties();
    }

    private void UpdateViewProperties()
    {
        _suppressUpdates = true;
        var apm = _autoPlaybackManager;

        Position = apm.Player.CurrentPosition;
        Duration = apm.Player.NowPlayingDuration;

        SliderCurrent = (int?) Position?.TotalSeconds;
        SliderDuration = (int?) Duration?.TotalSeconds;

        Title = apm.NowPlaying?.Title;
        Artist = apm.NowPlaying?.Artist;
        ShowExplicitFlag = apm.NowPlaying?.IsExplicit ?? false;
        PlaybackState = apm.Player.PlaybackState;

        CoverArt.CoverArtId = apm.NowPlaying?.CoverArtId;

        //PlayPauseCommand.Executable = (PlaybackState is Core.Enums.PlaybackState.Playing or Core.Enums.PlaybackState.Paused);

        _suppressUpdates = false;
    }
}
