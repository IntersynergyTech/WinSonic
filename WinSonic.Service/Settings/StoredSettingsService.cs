using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WinSonic.Data;
using WinSonic.Service.SecureData;

namespace WinSonic.Service.Settings;

public class StoredSettingsService : ISettingsService
{
    private const int SettingsRowId = 1;

    private readonly BaseDataContext _dataContext;
    private readonly ISecureDataService _secureDataService;

    public StoredSettingsService(BaseDataContext dataContext, ISecureDataService secureDataService)
    {
        _dataContext = dataContext;
        _secureDataService = secureDataService;
    }

    public async Task<Core.Models.Settings> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        var settings = await _dataContext.Settings.SingleOrDefaultAsync(s => s.Id == SettingsRowId, cancellationToken);

        if (settings is null)
        {
            var initial = SettingsMapper.DomainToDb(CreateDefaultSettings());
            _dataContext.Settings.Add(initial);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return SettingsMapper.DbToDomain(initial);
        }

        var normalisedServerAddress = settings.ServerAddress.Trim();
        var normalisedUsername = settings.Username.Trim();
        var expectedPasswordCredentialKey = BuildPasswordCredentialKey(normalisedServerAddress, normalisedUsername);

        if (settings.ServerAddress != normalisedServerAddress ||
            settings.Username != normalisedUsername ||
            settings.PasswordCredentialKey != expectedPasswordCredentialKey)
        {
            settings.ServerAddress = normalisedServerAddress;
            settings.Username = normalisedUsername;
            settings.PasswordCredentialKey = expectedPasswordCredentialKey;
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        return SettingsMapper.DbToDomain(settings);
    }

    public async Task SaveSettingsAsync(Core.Models.Settings settings, string? serverPassword = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(settings);

        Validate(settings);

        settings.Id = SettingsRowId;
        settings.ThemeKey = NullIfWhitespace(settings.ThemeKey);
        settings.ServerAddress = settings.ServerAddress.Trim();
        settings.Username = settings.Username.Trim();
        settings.PasswordCredentialKey = BuildPasswordCredentialKey(settings.ServerAddress, settings.Username);

        var existing = await _dataContext.Settings.SingleOrDefaultAsync(s => s.Id == SettingsRowId, cancellationToken);
        var mapped = SettingsMapper.DomainToDb(settings);

        if (existing is null)
        {
            _dataContext.Settings.Add(mapped);
        }
        else
        {
            _dataContext.Entry(existing).CurrentValues.SetValues(mapped);
        }

        if (!string.IsNullOrWhiteSpace(serverPassword))
        {
            if (string.IsNullOrWhiteSpace(settings.PasswordCredentialKey))
            {
                throw new InvalidOperationException("ServerAddress and Username are required to store a server password.");
            }

            _secureDataService.SetValueByKey(settings.PasswordCredentialKey, serverPassword);
        }

        await _dataContext.SaveChangesAsync(cancellationToken);
    }

    public string? GetServerPassword(Core.Models.Settings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);
        if (string.IsNullOrWhiteSpace(settings.PasswordCredentialKey))
        {
            return null;
        }

        return _secureDataService.GetValueByKey(settings.PasswordCredentialKey);
    }

    private static Core.Models.Settings CreateDefaultSettings()
    {
        return new Core.Models.Settings
        {
            Id = SettingsRowId,
            CheckForUpdates = true,
            LanguageIetf = "en-GB",
            ThemeKey = null,
            SyncLyrics = true,
            OutputDevice = null,
            ReplayGainMode = Core.Models.ReplayGainMode.Album,
            ClippingPrevention = Core.Models.ReplayGainClippingPrevention.Off,
            Preamp = null,
            ServerAddress = string.Empty,
            Username = string.Empty,
            IgnoreSslErrors = false,
            ScrobbleToServer = true,
            ScrobbleMinimumPercentage = null,
            ScrobbleMinimumSeconds = null,
            SyncPlayQueue = false
        };
    }

    private static void Validate(Core.Models.Settings settings)
    {
        if (!string.IsNullOrWhiteSpace(settings.ServerAddress) &&
            !Uri.TryCreate(settings.ServerAddress, UriKind.Absolute, out _))
        {
            throw new ArgumentException("ServerAddress must be a valid absolute URI.", nameof(settings));
        }

        if (settings.Preamp is < -50 or > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(settings), "Preamp must be between -50 and 50.");
        }

        if (settings.ScrobbleMinimumPercentage is < 0 or > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(settings), "ScrobbleMinimumPercentage must be between 0 and 1.");
        }
    }

    private static string? NullIfWhitespace(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    private static string BuildPasswordCredentialKey(string serverAddress, string username)
    {
        if (string.IsNullOrWhiteSpace(serverAddress) || string.IsNullOrWhiteSpace(username))
        {
            return string.Empty;
        }

        var canonicalValue = $"{serverAddress.Trim().ToLowerInvariant()}|{username.Trim().ToLowerInvariant()}";
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(canonicalValue))).ToLowerInvariant();
        return $"subsonic-server-password-{hash}";
    }
}
