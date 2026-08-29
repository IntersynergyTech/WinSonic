namespace WinSonic.Core.Models;

public class Settings
{
    public int Id { get; set; }

    // General settings
    public bool CheckForUpdates { get; set; }
    public string LanguageIetf { get; set; } = "en-GB";
    public string? ThemeKey { get; set; }
    public bool SyncLyrics { get; set; }

    // Playback settings
    public string? OutputDevice { get; set; }
    public ReplayGainMode ReplayGainMode { get; set; }
    public ReplayGainClippingPrevention ClippingPrevention { get; set; }
    public double? Preamp { get; set; }

    // Server settings
    public string ServerAddress { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordCredentialKey { get; set; }
    public bool IgnoreSslErrors { get; set; }
    public bool ScrobbleToServer { get; set; }
    public double? ScrobbleMinimumPercentage { get; set; }
    public double? ScrobbleMinimumSeconds { get; set; }
    public bool ScrobbleOnCompletion { get; set; }
    public bool SyncPlayQueue { get; set; }
}

public enum ReplayGainMode
{
    None,
    Auto,
    Album,
    Track
}

public enum ReplayGainClippingPrevention
{
    Off,
    ReduceGain
}
