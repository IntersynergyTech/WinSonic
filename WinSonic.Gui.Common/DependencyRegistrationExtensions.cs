using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.Sqlite;
using WinSonic.Data.Sync;
using WinSonic.Gui.Common.ViewModels;
using WinSonic.Gui.Common.ViewModels.BrowsePages;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common;

public static class DependencyRegistrationExtensions
{
    public static IServiceCollection AddCommonGuiServices(this IServiceCollection services)
    {
        services.AddViewModels().AddViews().AddDomainServices();

        // Basics
        services.AddDbContextFactory<BaseDataContext, SqliteDataContextFactory>();
        services.AddDbContext<BaseDataContext, SqliteDataContext>();
        services.AddLogging(builder => builder.AddDebug().SetMinimumLevel(LogLevel.Trace));

        // Core bits
        services.AddSingleton<StorageManager>();
        services.AddSingleton<SyncManager>();
        services.AddSingleton<AutoPlaybackManager>();
        services.AddSingleton<SongFetcher>();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<MainViewModel>();
        services.AddScoped<SettingsViewModel>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped<TestViewModel>();
        services.AddScoped<PlayerWindowViewModel>();
        
        // Browse
        services.AddScoped<PlaylistsViewModel>();
        
        // Detail
        services.AddScoped<SinglePlaylistViewModel>();
        
        return services;
    }

    private static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        //Data services
        services.AddScoped<IPlaylistService, CachedPlaylistService>();

        return services;
    }
}
