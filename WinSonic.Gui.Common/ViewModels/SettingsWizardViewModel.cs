using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Resources.Localisation;
using WinSonic.Service.Settings;
using CoreSettings = WinSonic.Core.Models.Settings;

namespace WinSonic.Gui.Common.ViewModels;

public partial class SettingsWizardViewModel : PageModelBase
{
    private const string SystemThemeKey = "system";
    private readonly ISettingsService? _settingsService;
    private readonly ILogger<SettingsWizardViewModel> _logger;

    [ObservableProperty]
    public partial int CurrentStep { get; set; }

    [ObservableProperty]
    public partial string LanguageIetf { get; set; } = DetermineDefaultLanguageIetf();

    [ObservableProperty]
    public partial OptionItem<string>? SelectedLanguageOption { get; set; }

    [ObservableProperty]
    public partial string ThemeKey { get; set; } = SystemThemeKey;

    [ObservableProperty]
    public partial OptionItem<string>? SelectedThemeOption { get; set; }

    [ObservableProperty]
    public partial string ServerAddress { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Username { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ServerPassword { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool IgnoreSslErrors { get; set; }

    [ObservableProperty]
    public partial bool CheckForUpdates { get; set; } = true;

    [ObservableProperty]
    public partial bool IsServerConnectionValidated { get; set; }

    [ObservableProperty]
    public partial string ConnectionStatusMessage { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ConnectionStatusColor { get; set; } = "#2e7d32";

    [ObservableProperty]
    public partial bool IsBusy { get; set; }

    public event Func<Task>? RequestCloseAsync;

    public IReadOnlyList<OptionItem<string>> LanguageOptions { get; }
    public IReadOnlyList<OptionItem<string>> ThemeOptions { get; }

    public SettingsWizardViewModel()
        : this(
            DependencyService.Services?.GetService<ISettingsService>(),
            DependencyService.Services?.GetService<ILogger<SettingsWizardViewModel>>() ?? NullLogger<SettingsWizardViewModel>.Instance)
    {
    }

    public SettingsWizardViewModel(ISettingsService? settingsService, ILogger<SettingsWizardViewModel>? logger = null)
    {
        _settingsService = settingsService;
        _logger = logger ?? NullLogger<SettingsWizardViewModel>.Instance;
        LanguageOptions = BuildLanguageOptions();
        ThemeOptions = BuildThemeOptions();
        SelectedLanguageOption = LanguageOptions.FirstOrDefault(x => x.Value == LanguageIetf) ?? LanguageOptions.First();
        SelectedThemeOption = ThemeOptions.FirstOrDefault(x => x.Value == ThemeKey) ?? ThemeOptions.First();
    }

    public override void OnLoaded()
    {
        CurrentStep = 0;
    }

    [RelayCommand]
    private void PreviousStep()
    {
        if (CurrentStep > 0)
        {
            CurrentStep--;
        }
    }

    [RelayCommand]
    private async Task NextStepAsync(CancellationToken cancellationToken)
    {
        if (CurrentStep == 2 && !IsServerConnectionValidated)
        {
            ConnectionStatusMessage = Strings._WizardConnectionRequired;
            ConnectionStatusColor = "#b00020";
            return;
        }

        if (CurrentStep == 0)
        {
            CurrentStep = 1;
            return;
        }

        if (CurrentStep == 1)
        {
            CurrentStep = 2;
            return;
        }

        if (CurrentStep == 2)
        {
            CurrentStep = 3;
            return;
        }

        if (CurrentStep == 3)
        {
            await FinishWizardAsync(cancellationToken);
        }
    }

    [RelayCommand]
    private async Task TestServerConnectionAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting server connection test for wizard. URL: {ServerAddress}, Username: {Username}, IgnoreSslErrors: {IgnoreSslErrors}", ServerAddress, Username, IgnoreSslErrors);

        IsBusy = true;
        ConnectionStatusColor = "#2e7d32";
        ConnectionStatusMessage = Strings._WizardConnectionTesting;
        IsServerConnectionValidated = false;

        try
        {
            var cleanedServerAddress = ServerAddress.Trim();
            var cleanedUsername = Username.Trim();
            var cleanedPassword = ServerPassword.Trim();

            if (string.IsNullOrWhiteSpace(cleanedServerAddress) ||
                string.IsNullOrWhiteSpace(cleanedUsername) ||
                string.IsNullOrWhiteSpace(cleanedPassword))
            {
                _logger.LogWarning("Server connection validation failed because required server details were missing.");
                IsServerConnectionValidated = false;
                ConnectionStatusColor = "#b00020";
                ConnectionStatusMessage = Strings._WizardConnectionMissingValues;
                return;
            }

            if (!Uri.TryCreate(cleanedServerAddress, UriKind.Absolute, out _))
            {
                _logger.LogWarning("Server connection validation failed because the server address was not a valid absolute URI: {ServerAddress}", cleanedServerAddress);
                IsServerConnectionValidated = false;
                ConnectionStatusColor = "#b00020";
                ConnectionStatusMessage = Strings._SettingsValidationServerUri;
                return;
            }

            var api = new WinSonic.Subsonic.Helpers.SubsonicConnectionBuilder()
                .WithServerUrl(cleanedServerAddress)
                .WithUsernameAndPassword(cleanedUsername, cleanedPassword)
                .WithIgnoreSslErrors(IgnoreSslErrors)
                .WithTimeout(TimeSpan.FromSeconds(5))
                .Build();

            _logger.LogDebug("Pinging Subsonic server at {ServerAddress} using username {Username}.", cleanedServerAddress, cleanedUsername);
            var pingTask = Task.Run(() => api.System.Ping(), cancellationToken);
            var response = await pingTask.WaitAsync(TimeSpan.FromSeconds(5), cancellationToken).ConfigureAwait(true);
            response.VarSubsonicResponse.GetSubsonicSuccessResponse();

            IsServerConnectionValidated = true;
            ConnectionStatusColor = "#2e7d32";
            ConnectionStatusMessage = Strings._WizardConnectionSuccess;
            _logger.LogInformation("Server connection test succeeded for {ServerAddress}.", cleanedServerAddress);
        }
        catch (TimeoutException)
        {
            _logger.LogWarning("Server connection test timed out after 5 seconds for wizard configuration.");
            IsServerConnectionValidated = false;
            ConnectionStatusColor = "#b00020";
            ConnectionStatusMessage = Strings._WizardConnectionFailed;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Server connection test failed for wizard configuration.");
            IsServerConnectionValidated = false;
            ConnectionStatusColor = "#b00020";
            ConnectionStatusMessage = string.IsNullOrWhiteSpace(ex.Message) ? Strings._WizardConnectionFailed : $"{Strings._WizardConnectionFailed} {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task FinishWizardAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Finalising startup wizard with language {LanguageIetf}, theme {ThemeKey}, server {ServerAddress}, username {Username}, checkForUpdates {CheckForUpdates}.", LanguageIetf, ThemeKey, ServerAddress, Username, CheckForUpdates);

        if (_settingsService is null)
        {
            _logger.LogCritical("Settings service unavailable while finalising startup wizard.");
            throw new InvalidOperationException("Settings service is unavailable.");
        }

        var normalisedServerAddress = NormaliseServerAddress(ServerAddress);
        var settings = new CoreSettings
        {
            Id = 1,
            CheckForUpdates = CheckForUpdates,
            LanguageIetf = LanguageIetf,
            ThemeKey = ThemeKey == SystemThemeKey ? null : ThemeKey,
            SyncLyrics = true,
            OutputDevice = null,
            ReplayGainMode = ReplayGainMode.Album,
            ClippingPrevention = ReplayGainClippingPrevention.Off,
            Preamp = 0,
            RequestOriginalFiles = true,
            TranscodeFormat = TranscodeFormat.Mp3,
            TranscodeBitrate = 320,
            ServerAddress = normalisedServerAddress,
            Username = Username.Trim(),
            IgnoreSslErrors = IgnoreSslErrors,
            ScrobbleToServer = true,
            ScrobbleMinimumPercentage = 0.75,
            ScrobbleMinimumSeconds = 60,
            ScrobbleOnCompletion = true,
            SyncPlayQueue = false
        };

        try
        {
            await _settingsService.SaveSettingsAsync(settings, ServerPassword.Trim(), cancellationToken);
            _logger.LogInformation("Startup wizard settings saved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save startup wizard settings.");
            throw;
        }

        if (RequestCloseAsync is not null)
        {
            _logger.LogInformation("Requesting wizard close and post-save sync/player launch.");
            await RequestCloseAsync.Invoke();
        }
    }

    public bool CanGoBack => CurrentStep > 0;
    public bool CanGoNext => CurrentStep != 2 || IsServerConnectionValidated;
    public bool IsOnServerStep => CurrentStep == 2;
    public bool IsOnCompleteStep => CurrentStep == 3;
    public string PrimaryActionText => CurrentStep == 3 ? Strings._SaveSettings : Strings._Next;

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
            new OptionItem<string>("fluent-light", Strings._ThemeLight),
            new OptionItem<string>("fluent-dark", Strings._ThemeDark)
        ];
    }

    private static string DetermineDefaultLanguageIetf()
    {
        var current = CultureInfo.CurrentUICulture.Name;
        if (string.IsNullOrWhiteSpace(current))
        {
            return SupportedLanguages.DefaultLanguageIetf;
        }

        var normalizedCurrent = current.Trim();
        var matchingLanguage = SupportedLanguages.All.FirstOrDefault(language =>
            string.Equals(language.IetfTag, normalizedCurrent, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(language.IetfTag.Split('-')[0], normalizedCurrent.Split('-')[0], StringComparison.OrdinalIgnoreCase));

        return matchingLanguage?.IetfTag ?? SupportedLanguages.DefaultLanguageIetf;
    }

    partial void OnCurrentStepChanged(int value)
    {
        OnPropertyChanged(nameof(CanGoBack));
        OnPropertyChanged(nameof(CanGoNext));
        OnPropertyChanged(nameof(IsOnServerStep));
        OnPropertyChanged(nameof(IsOnCompleteStep));
        OnPropertyChanged(nameof(PrimaryActionText));
    }

    partial void OnIsServerConnectionValidatedChanged(bool value)
    {
        OnPropertyChanged(nameof(CanGoNext));
    }

    public void ApplyServerAddressNormalization()
    {
        var normalisedServerAddress = NormaliseServerAddress(ServerAddress);
        if (!string.Equals(ServerAddress, normalisedServerAddress, StringComparison.Ordinal))
        {
            ServerAddress = normalisedServerAddress;
        }

        ClearConnectionStatus();
    }

    private static string NormaliseServerAddress(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        var trimmedValue = value.Trim();
        if (trimmedValue.Contains("://", StringComparison.OrdinalIgnoreCase))
        {
            return trimmedValue;
        }

        return $"https://{trimmedValue.TrimStart('/')}";
    }

    partial void OnUsernameChanged(string value)
    {
        ClearConnectionStatus();
    }

    partial void OnServerPasswordChanged(string value)
    {
        ClearConnectionStatus();
    }

    partial void OnIgnoreSslErrorsChanged(bool value)
    {
        ClearConnectionStatus();
    }

    private void ClearConnectionStatus()
    {
        if (!string.IsNullOrWhiteSpace(ConnectionStatusMessage))
        {
            ConnectionStatusMessage = string.Empty;
            ConnectionStatusColor = "#2e7d32";
            IsServerConnectionValidated = false;
        }
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
}
