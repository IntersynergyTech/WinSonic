using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class DbSettings
{
    public int Id { get; set; }
    
    // General settings
    public bool CheckForUpdates { get; set; }
    public string LanguageIetf { get; set; }
    public string? ThemeKey { get; set; }
    public bool SyncLyrics { get; set; }
    
    // Playback settings
    public string? OutputDevice { get; set; }
    public ReplayGainMode ReplayGainMode { get; set; }
    public ReplayGainClippingPrevention ClippingPrevention { get; set; }
    public double? Preamp { get; set; }
    public bool RequestOriginalFiles { get; set; }
    public TranscodeFormat TranscodeFormat { get; set; }
    public int TranscodeBitrate { get; set; }
    
    // Server settings
    public string ServerAddress { get; set; }
    public string Username { get; set; }
    public string PasswordCredentialKey { get; set; }
    public bool IgnoreSslErrors { get; set; }
    public bool ScrobbleToServer { get; set; }
    public double? ScrobbleMinimumPercentage { get; set; }
    public double? ScrobbleMinimumSeconds { get; set; }
    public bool ScrobbleOnCompletion { get; set; }
    public bool SyncPlayQueue { get; set; }
    
}
