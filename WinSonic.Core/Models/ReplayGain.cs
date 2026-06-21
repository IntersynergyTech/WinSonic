namespace WinSonic.Core.Models;

public class ReplayGain
{
    public decimal AlbumGain { get; }
    public decimal AlbumPeak { get; }
    public decimal TrackGain { get; }
    public decimal TrackPeak { get; }

    public ReplayGain(
        decimal albumGain,
        decimal albumPeak,
        decimal trackGain,
        decimal trackPeak
    )
    {
        AlbumGain = albumGain;
        AlbumPeak = albumPeak;
        TrackGain = trackGain;
        TrackPeak = trackPeak;
    }
}
