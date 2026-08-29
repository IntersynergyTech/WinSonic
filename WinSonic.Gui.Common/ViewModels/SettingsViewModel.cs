using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using SoundFlow.Structs;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Player;
using WinSonic.Resources.Localisation;
using WinSonic.Service.Settings;
using CoreSettings = WinSonic.Core.Models.Settings;

namespace WinSonic.Gui.Common.ViewModels;

public partial class SettingsViewModel : PageModelBase
{
    private const string SystemThemeKey = "system";
    private const string LightThemeKey = "fluent-light";
    private const string DarkThemeKey = "fluent-dark";
    private static readonly int[] SupportedTranscodeBitrates = [48, 96, 128, 192, 256, 320];

    private readonly ISettingsService? _settingsService;
    private readonly ISoundFlowPlayer _player;
    private int _id;
    private bool _hasLoaded;

    [ObservableProperty] public partial bool CheckForUpdates { get; set; }
    [ObservableProperty] public partial string LanguageIetf { get; set; } = SupportedLanguages.DefaultLanguageIetf;
    [ObservableProperty] public partial OptionItem<string>? SelectedLanguageOption { get; set; }
    [ObservableProperty] public partial string ThemeKey { get; set; } = SystemThemeKey;
    [ObservableProperty] public partial OptionItem<string>? SelectedThemeOption { get; set; }
    [ObservableProperty] public partial bool SyncLyrics { get; set; }
    [ObservableProperty] public partial string? OutputDevice { get; set; }
    [ObservableProperty] public partial OptionItem<DeviceInfo?>? SelectedOutputDeviceOption { get; set; }
    [ObservableProperty] public partial ReplayGainMode ReplayGainMode { get; set; } = ReplayGainMode.Album;
    [ObservableProperty] public partial OptionItem<ReplayGainMode>? SelectedReplayGainModeOption { get; set; }
    [ObservableProperty]
    public partial ReplayGainClippingPrevention ClippingPrevention { get; set; } = ReplayGainClippingPrevention.Off;
    [ObservableProperty]
    public partial OptionItem<ReplayGainClippingPrevention>? SelectedClippingPreventionOption { get; set; }
    [ObservableProperty] public partial bool RequestOriginalFiles { get; set; } = true;
    [ObservableProperty] public partial TranscodeFormat TranscodeFormat { get; set; } = TranscodeFormat.Mp3;
    [ObservableProperty] public partial OptionItem<TranscodeFormat>? SelectedTranscodeFormatOption { get; set; }
    [ObservableProperty] public partial int TranscodeBitrate { get; set; } = 320;
    [ObservableProperty] public partial OptionItem<int>? SelectedTranscodeBitrateOption { get; set; }
    [NotifyDataErrorInfo]
    [Range(
        typeof(decimal),
        "-50",
        "50",
        ErrorMessageResourceType = typeof(Strings),
        ErrorMessageResourceName = nameof(Strings._SettingsValidationPreampRange)
    )]
    [ObservableProperty]
    public partial decimal? Preamp { get; set; }
    [NotifyDataErrorInfo]
    [CustomValidation(typeof(SettingsViewModel), nameof(ValidateServerAddress))]
    [ObservableProperty]
    public partial string ServerAddress { get; set; } = string.Empty;
    [ObservableProperty] public partial string Username { get; set; } = string.Empty;
    [ObservableProperty] public partial string ServerPasswordInput { get; set; } = string.Empty;
    [ObservableProperty] public partial bool IgnoreSslErrors { get; set; }
    [ObservableProperty] public partial bool ScrobbleToServer { get; set; }
    [NotifyDataErrorInfo]
    [Range(
        typeof(decimal),
        "0",
        "100",
        ErrorMessageResourceType = typeof(Strings),
        ErrorMessageResourceName = nameof(Strings._SettingsValidationScrobblePercentRange)
    )]
    [ObservableProperty]
    public partial decimal? ScrobbleMinimumPercentage { get; set; }
    [ObservableProperty] public partial decimal? ScrobbleMinimumSeconds { get; set; }
    [ObservableProperty] public partial bool ScrobbleOnCompletion { get; set; }
    [ObservableProperty] public partial bool SyncPlayQueue { get; set; }
    [ObservableProperty] public partial string? ErrorMessage { get; set; }
    [ObservableProperty] public partial string? InfoMessage { get; set; }

    [ObservableProperty] public partial IReadOnlyList<OptionItem<string>> LanguageOptions { get; set; }
    [ObservableProperty] public partial IReadOnlyList<OptionItem<string>> ThemeOptions { get; set; }
    [ObservableProperty] public partial IReadOnlyList<OptionItem<ReplayGainMode>> ReplayGainModeOptions { get; set; }
    [ObservableProperty]
    public partial IReadOnlyList<OptionItem<ReplayGainClippingPrevention>> ClippingPreventionOptions { get; set; }
    [ObservableProperty] public partial IReadOnlyList<OptionItem<TranscodeFormat>> TranscodeFormatOptions { get; set; }
    [ObservableProperty] public partial IReadOnlyList<OptionItem<int>> TranscodeBitrateOptions { get; set; }
    [ObservableProperty] public partial IReadOnlyList<OptionItem<DeviceInfo?>> OutputDeviceOptions { get; set; }

    public SettingsViewModel(ISettingsService settingsService, ISoundFlowPlayer player)
    {
        _settingsService = settingsService;
        _player = player;
    }

    public override void OnLoaded()
    {
        LanguageOptions = BuildLanguageOptions();
        ThemeOptions = BuildThemeOptions();
        ReplayGainModeOptions = BuildReplayGainModeOptions();
        ClippingPreventionOptions = BuildClippingPreventionOptions();
        TranscodeFormatOptions = BuildTranscodeFormatOptions();
        TranscodeBitrateOptions = BuildTranscodeBitrateOptions();
        OutputDeviceOptions = BuildOutputDeviceOptions(_player);
        _ = LoadSettingsAsync();
    }

    [RelayCommand]
    private async Task SaveSettingsAsync(CancellationToken cancellationToken)
    {
        ErrorMessage = null;
        InfoMessage = null;

        if (_settingsService is null)
        {
            throw new InvalidOperationException("Settings service is unavailable.");
        }

        ValidateAllProperties();

        if (HasErrors)
        {
            ErrorMessage = GetErrors()
                .OfType<ValidationResult>()
                .Select(result => result.ErrorMessage)
                .FirstOrDefault(message => !string.IsNullOrWhiteSpace(message));

            return;
        }

        var normalisedServerAddress = NormaliseServerAddress(ServerAddress);

        var model = new CoreSettings
        {
            Id = _id,
            CheckForUpdates = CheckForUpdates,
            LanguageIetf = LanguageIetf,
            ThemeKey = ThemeKey == SystemThemeKey ? null : ThemeKey,
            SyncLyrics = SyncLyrics,
            OutputDevice = NullIfWhitespace(OutputDevice),
            ReplayGainMode = ReplayGainMode,
            ClippingPrevention = ClippingPrevention,
            Preamp = Preamp.HasValue ? (double?) Preamp.Value : null,
            RequestOriginalFiles = RequestOriginalFiles,
            TranscodeFormat = TranscodeFormat,
            TranscodeBitrate = TranscodeBitrate,
            ServerAddress = normalisedServerAddress,
            Username = Username.Trim(),
            IgnoreSslErrors = IgnoreSslErrors,
            ScrobbleToServer = ScrobbleToServer,
            ScrobbleMinimumPercentage = ToStoredScrobbleMinPercentage(ScrobbleMinimumPercentage),
            ScrobbleMinimumSeconds = ScrobbleMinimumSeconds.HasValue ? (double?) ScrobbleMinimumSeconds.Value : null,
            ScrobbleOnCompletion = ScrobbleOnCompletion,
            SyncPlayQueue = SyncPlayQueue
        };

        var passwordToSave = string.IsNullOrWhiteSpace(ServerPasswordInput) ? null : ServerPasswordInput;
        await _settingsService.SaveSettingsAsync(model, passwordToSave, cancellationToken);
        ServerPasswordInput = string.Empty;
        InfoMessage = Strings._SettingsSaved;
    }

    private async Task LoadSettingsAsync()
    {
        _hasLoaded = false;
        
        if (_settingsService is null)
        {
            return;
        }

        var settings = await _settingsService.GetSettingsAsync();

        _id = settings.Id;
        CheckForUpdates = settings.CheckForUpdates;

        LanguageIetf = string.IsNullOrWhiteSpace(settings.LanguageIetf)
            ? SupportedLanguages.DefaultLanguageIetf
            : settings.LanguageIetf;

        SelectedLanguageOption =
            LanguageOptions.FirstOrDefault(x => x.Value == LanguageIetf) ?? LanguageOptions.First();

        ThemeKey = string.IsNullOrWhiteSpace(settings.ThemeKey) ? SystemThemeKey : settings.ThemeKey!;
        SelectedThemeOption = ThemeOptions.FirstOrDefault(x => x.Value == ThemeKey) ?? ThemeOptions.First();
        SyncLyrics = settings.SyncLyrics;
        OutputDevice = settings.OutputDevice;
        ReplayGainMode = settings.ReplayGainMode;

        SelectedReplayGainModeOption = ReplayGainModeOptions.FirstOrDefault(x => x.Value == ReplayGainMode)
            ?? ReplayGainModeOptions.First();

        ClippingPrevention = settings.ClippingPrevention;

        SelectedClippingPreventionOption = ClippingPreventionOptions.FirstOrDefault(x => x.Value == ClippingPrevention)
            ?? ClippingPreventionOptions.First();

        RequestOriginalFiles = settings.RequestOriginalFiles;
        TranscodeFormat = settings.TranscodeFormat;
        SelectedTranscodeFormatOption = TranscodeFormatOptions.FirstOrDefault(x => x.Value == TranscodeFormat)
            ?? TranscodeFormatOptions.First();
        TranscodeBitrate = settings.TranscodeBitrate;
        SelectedTranscodeBitrateOption = TranscodeBitrateOptions.FirstOrDefault(x => x.Value == TranscodeBitrate)
            ?? TranscodeBitrateOptions.First();

        SelectedOutputDeviceOption = OutputDeviceOptions.FirstOrDefault(x => x.Value?.Name == OutputDevice)
            ?? OutputDeviceOptions.First();

        Preamp = settings.Preamp.HasValue ? (decimal?) settings.Preamp.Value : null;
        ServerAddress = settings.ServerAddress;
        Username = settings.Username;
        ServerPasswordInput = string.Empty;
        IgnoreSslErrors = settings.IgnoreSslErrors;
        ScrobbleToServer = settings.ScrobbleToServer;
        ScrobbleMinimumPercentage = ToPercentageDisplayValue(settings.ScrobbleMinimumPercentage);
        ScrobbleOnCompletion = settings.ScrobbleOnCompletion;

        ScrobbleMinimumSeconds = settings.ScrobbleMinimumSeconds.HasValue
            ? (decimal?) settings.ScrobbleMinimumSeconds.Value
            : null;

        SyncPlayQueue = settings.SyncPlayQueue;

        _hasLoaded = true;
    }

    private static double? ToStoredScrobbleMinPercentage(decimal? percentDisplayValue)
    {
        return percentDisplayValue.HasValue ? (double?) (percentDisplayValue.Value / 100m) : null;
    }

    private static decimal? ToPercentageDisplayValue(double? storedValue)
    {
        return storedValue.HasValue ? (decimal) (storedValue.Value * 100d) : null;
    }

    private static string? NullIfWhitespace(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    private static IReadOnlyList<OptionItem<string>> BuildLanguageOptions()
    {
        return SupportedLanguages.All
            .Select(language => new OptionItem<string>(language.IetfTag, language.DisplayName))
            .ToArray();
    }

    private static IReadOnlyList<OptionItem<string>> BuildThemeOptions()
    {
        return
        [
            new OptionItem<string>(SystemThemeKey, Strings._ThemeSystem),
            new OptionItem<string>(LightThemeKey, Strings._ThemeLight),
            new OptionItem<string>(DarkThemeKey, Strings._ThemeDark)
        ];
    }

    private static IReadOnlyList<OptionItem<ReplayGainMode>> BuildReplayGainModeOptions()
    {
        return
        [
            new OptionItem<ReplayGainMode>(ReplayGainMode.None, Strings._ReplayGainModeNone),
            new OptionItem<ReplayGainMode>(ReplayGainMode.Auto, Strings._ReplayGainModeAuto),
            new OptionItem<ReplayGainMode>(ReplayGainMode.Album, Strings._ReplayGainModeAlbum),
            new OptionItem<ReplayGainMode>(ReplayGainMode.Track, Strings._ReplayGainModeTrack)
        ];
    }

    private static IReadOnlyList<OptionItem<ReplayGainClippingPrevention>> BuildClippingPreventionOptions()
    {
        return
        [
            new OptionItem<ReplayGainClippingPrevention>(
                ReplayGainClippingPrevention.Off,
                Strings._ReplayGainClippingOff
            ),
            new OptionItem<ReplayGainClippingPrevention>(
                ReplayGainClippingPrevention.ReduceGain,
                Strings._ReplayGainClippingReduceGain
            )
        ];
    }

    private static IReadOnlyList<OptionItem<TranscodeFormat>> BuildTranscodeFormatOptions()
    {
        return
        [
            new OptionItem<TranscodeFormat>(TranscodeFormat.Mp3, Strings._TranscodeFormatMp3)
        ];
    }

    private static IReadOnlyList<OptionItem<int>> BuildTranscodeBitrateOptions()
    {
        return SupportedTranscodeBitrates
            .Select(bitrate => new OptionItem<int>(bitrate, bitrate.ToString()))
            .ToArray();
    }

    private static IReadOnlyList<OptionItem<DeviceInfo?>> BuildOutputDeviceOptions(ISoundFlowPlayer player)
    {
        var devices = player.GetAvailableDevices().OrderBy(device => device.Name).ToList();

        // Apparently there can be multiple default devices, so we just take the first one if there are multiple.
        DeviceInfo? defaultDevice = devices.FirstOrDefault(x => x.IsDefault);

        var mappedDevices = devices.Select(device => new OptionItem<DeviceInfo?>(device, device.Name)).ToList();

        var defaultDeviceOption = new OptionItem<DeviceInfo?>(
            null,
            Strings._SystemDefaultAudioDevice.Replace("{{device}}", defaultDevice?.Name ?? Strings._Unavailable)
        );

        mappedDevices.Insert(0, defaultDeviceOption);
        return mappedDevices;
    }

    public static ValidationResult? ValidateServerAddress(string serverAddress, ValidationContext _context)
    {
        var normalisedServerAddress = NormaliseServerAddress(serverAddress);

        if (string.IsNullOrWhiteSpace(normalisedServerAddress)
            || Uri.TryCreate(normalisedServerAddress, UriKind.Absolute, out _))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(Strings._SettingsValidationServerUri);
    }

    private static string NormaliseServerAddress(string? serverAddress)
    {
        if (string.IsNullOrWhiteSpace(serverAddress))
        {
            return string.Empty;
        }

        var trimmedServerAddress = serverAddress.Trim();

        if (trimmedServerAddress.Contains("://", StringComparison.OrdinalIgnoreCase))
        {
            return trimmedServerAddress;
        }

        return $"https://{trimmedServerAddress.TrimStart('/')}";
    }

    partial void OnSelectedLanguageOptionChanged(OptionItem<string>? value)
    {
        if (value is not null)
        {
            LanguageIetf = value.Value;
        }
    }

    partial void OnSelectedThemeOptionChanged(OptionItem<string>? value)
    {
        if (value is not null)
        {
            ThemeKey = value.Value;
        }
    }

    public void ApplyServerAddressNormalization()
    {
        var normalisedServerAddress = NormaliseServerAddress(ServerAddress);

        if (!string.Equals(ServerAddress, normalisedServerAddress, StringComparison.Ordinal))
        {
            ServerAddress = normalisedServerAddress;
        }
    }

    partial void OnSelectedReplayGainModeOptionChanged(OptionItem<ReplayGainMode>? value)
    {
        if (value is not null)
        {
            ReplayGainMode = value.Value;
        }
    }

    partial void OnSelectedOutputDeviceOptionChanged(OptionItem<DeviceInfo?>? value)
    {
        if (value is not null)
        {
            OutputDevice = value.Value?.Name;

            if (_hasLoaded)
            {
                _player.SetOutputDevice(value.Value.Value.Id);
            }
        }
    }

    partial void OnSelectedTranscodeFormatOptionChanged(OptionItem<TranscodeFormat>? value)
    {
        if (value is not null)
        {
            TranscodeFormat = value.Value;
        }
    }

    partial void OnSelectedTranscodeBitrateOptionChanged(OptionItem<int>? value)
    {
        if (value is not null)
        {
            TranscodeBitrate = value.Value;
        }
    }

    partial void OnSelectedClippingPreventionOptionChanged(OptionItem<ReplayGainClippingPrevention>? value)
    {
        if (value is not null)
        {
            ClippingPrevention = value.Value;
        }
    }
}

public record OptionItem<T>(T Value, string DisplayName);
