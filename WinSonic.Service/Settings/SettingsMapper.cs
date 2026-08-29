using WinSonic.Data.DbModels;

namespace WinSonic.Service.Settings;

internal static class SettingsMapper
{
    public static Core.Models.Settings DbToDomain(DbSettings source)
    {
        return new Core.Models.Settings
        {
            Id = source.Id,
            CheckForUpdates = source.CheckForUpdates,
            LanguageIetf = source.LanguageIetf,
            ThemeKey = source.ThemeKey,
            SyncLyrics = source.SyncLyrics,
            OutputDevice = source.OutputDevice,
            ReplayGainMode = (Core.Models.ReplayGainMode) source.ReplayGainMode,
            ClippingPrevention = (Core.Models.ReplayGainClippingPrevention) source.ClippingPrevention,
            Preamp = source.Preamp,
            RequestOriginalFiles = source.RequestOriginalFiles,
            TranscodeFormat = (Core.Models.TranscodeFormat) source.TranscodeFormat,
            TranscodeBitrate = source.TranscodeBitrate,
            ServerAddress = source.ServerAddress,
            Username = source.Username,
            PasswordCredentialKey = source.PasswordCredentialKey,
            IgnoreSslErrors = source.IgnoreSslErrors,
            ScrobbleToServer = source.ScrobbleToServer,
            ScrobbleMinimumPercentage = source.ScrobbleMinimumPercentage,
            ScrobbleMinimumSeconds = source.ScrobbleMinimumSeconds,
            ScrobbleOnCompletion = source.ScrobbleOnCompletion,
            SyncPlayQueue = source.SyncPlayQueue
        };
    }

    public static DbSettings DomainToDb(Core.Models.Settings source)
    {
        return new DbSettings
        {
            Id = source.Id,
            CheckForUpdates = source.CheckForUpdates,
            LanguageIetf = source.LanguageIetf,
            ThemeKey = source.ThemeKey,
            SyncLyrics = source.SyncLyrics,
            OutputDevice = source.OutputDevice,
            ReplayGainMode = (Data.Enums.ReplayGainMode) source.ReplayGainMode,
            ClippingPrevention = (Data.Enums.ReplayGainClippingPrevention) source.ClippingPrevention,
            Preamp = source.Preamp,
            RequestOriginalFiles = source.RequestOriginalFiles,
            TranscodeFormat = (Data.Enums.TranscodeFormat) source.TranscodeFormat,
            TranscodeBitrate = source.TranscodeBitrate,
            ServerAddress = source.ServerAddress,
            Username = source.Username,
            PasswordCredentialKey = source.PasswordCredentialKey,
            IgnoreSslErrors = source.IgnoreSslErrors,
            ScrobbleToServer = source.ScrobbleToServer,
            ScrobbleMinimumPercentage = source.ScrobbleMinimumPercentage,
            ScrobbleMinimumSeconds = source.ScrobbleMinimumSeconds,
            ScrobbleOnCompletion = source.ScrobbleOnCompletion,
            SyncPlayQueue = source.SyncPlayQueue
        };
    }
}
