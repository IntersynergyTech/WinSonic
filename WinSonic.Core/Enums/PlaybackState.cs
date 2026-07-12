namespace WinSonic.Core.Enums;

[Flags]
public enum PlaybackState
{
    Stopped = 1,
    Playing = 2,
    Paused = 4,
    Ended = 8,
}
