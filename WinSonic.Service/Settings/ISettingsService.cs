using WinSonic.Core.Models;

namespace WinSonic.Service.Settings;

public interface ISettingsService
{
    Task<Core.Models.Settings> GetSettingsAsync(CancellationToken cancellationToken = default);
    Task SaveSettingsAsync(Core.Models.Settings settings, string? serverPassword = null, CancellationToken cancellationToken = default);
    string? GetServerPassword(Core.Models.Settings settings);
}
