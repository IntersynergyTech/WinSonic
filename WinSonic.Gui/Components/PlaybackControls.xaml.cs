using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WinSonic.Core.Enums;
using WinSonic.Core.Models;
using WinSonic.Gui.Misc;
using WinSonic.Gui.Misc.Commands;
using Timer = System.Timers.Timer;

namespace WinSonic.Gui.Components;

public partial class PlaybackControls : UserControl, INotifyPropertyChanged
{
    private readonly Timer _updateTimer = new Timer();
    private readonly CommandDebouncer _debouncer = new CommandDebouncer(1000);
    
    public PlaybackControls()
    {
        InitializeComponent();

        DataContext = this;
    }

    public void Init()
    {
        _updateTimer.Interval = 500;
        _updateTimer.Elapsed += UpdateTimerOnElapsed;
        _updateTimer.Enabled = true;

        GlobalContext.AutoPlaybackManager.NowPlayingChanged += AutoPlaybackManagerOnNowPlayingChanged;
    }
    
    void UpdateTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        UpdateViewProperties();
    }
    
    void AutoPlaybackManagerOnNowPlayingChanged(object? sender, Song? e)
    {
        UpdateViewProperties();
    }

    private bool _suppressUpdates = false;

    private void UpdateViewProperties()
    {
        _suppressUpdates = true;
        var apm = GlobalContext.AutoPlaybackManager;

        Position = apm.Player.CurrentPosition;
        Duration = apm.Player.NowPlayingDuration;

        SliderCurrent = (int?) Position?.TotalSeconds;
        SliderDuration = (int?) Duration?.TotalSeconds;

        Title = apm.NowPlaying?.Title;
        Artist = apm.NowPlaying?.Artist;

        PlaybackState = apm.Player.PlaybackState;

        PlayPauseCommand.Executable =
            (PlaybackState is Core.Enums.PlaybackState.Playing or Core.Enums.PlaybackState.Paused);
        
        
        _suppressUpdates = false;

    }

    public int? SliderDuration { get; private set; }
    private double? _sliderCurrent;
    public double? SliderCurrent
    {
        get => _sliderCurrent;
        set
        {
            _sliderCurrent = value;

            if (!_suppressUpdates)
            {
                GlobalContext.AutoPlaybackManager.Player.CurrentPosition = TimeSpan.FromSeconds(value.Value);
            }
        }
    }

    public TimeSpan? Position { get; private set; }
    public TimeSpan? Duration { get; private set; }

    public string? Title { get; private set; }
    public string? Artist { get; private set; }

    public PlaybackState? PlaybackState { get; private set; }

    public ToggleableCommand PreviousCommand { get; } = new ();
    public ToggleableCommand NextCommand { get; } = new ();
    public ToggleableCommand PlayPauseCommand { get; } = new ();
    public ToggleableCommand ShuffleCommand { get; } = new ();
    public ToggleableCommand RepeatCommand { get; } = new ();

    private void PlaybackControls_OnLoaded(object sender, RoutedEventArgs e)
    {
        //todo: implement these.
        ShuffleCommand.Executable = false;
        PreviousCommand.Executable = false;
        RepeatCommand.Executable = false;
    }

    private void Thumb_OnDragCompleted(object sender, DragCompletedEventArgs e)
    {
        Console.WriteLine($"Thumb complete changed{e.HorizontalChange} cancelled {e.Canceled} vert {e.VerticalChange}");
    }

    private void PlayPauseCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        Debug.WriteLine($"PlayPause command invoked while currently {GlobalContext.AudioPlayer.PlaybackState}");
        if (GlobalContext.AudioPlayer.PlaybackState == Core.Enums.PlaybackState.Playing)
        {
            GlobalContext.AudioPlayer.Pause();
        }
        else
        {
            GlobalContext.AudioPlayer.Play();
        }
    }

    private void NextCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        _debouncer.MaybeInvoke(() =>
        {
            Debug.WriteLine($"Next track command invoked: {e.OriginalSource} {e.Source} ");
            GlobalContext.AutoPlaybackManager.NextSong();    
        });
    }

    private void PrevCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}

