namespace WinSonic.Player.ReplayGain;

public class ReplayGainConfiguration
{
    public ReplayGainMode Mode { get; set; }
    public bool PreampEnabled { get; set; }
    public float PreampAdjustment { get; set; }
    public ClippingPreventionMode ClippingPrevention { get; set; }

    public static ReplayGainConfiguration Default =>
        new ReplayGainConfiguration
        {
            //todo: make these defaults sensible when we have a way to configure
            Mode = ReplayGainMode.Album,
            PreampEnabled = true,
            PreampAdjustment = 4.0f,
            ClippingPrevention = ClippingPreventionMode.Off
        };
}
