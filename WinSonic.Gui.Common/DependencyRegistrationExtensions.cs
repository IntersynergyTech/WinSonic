using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.Sqlite;
using WinSonic.Data.Sync;
using WinSonic.Gui.Common.ViewModels;
using WinSonic.Gui.Common.ViewModels.BrowsePages;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Misc.ImageTools;
using WinSonic.Playback;
using WinSonic.Playback.Platform;
using WinSonic.Player;
using WinSonic.Service.Album;
using WinSonic.Service.Artist;
using WinSonic.Service.Artwork;
using WinSonic.Service.History;
using WinSonic.Service.Misc;
using WinSonic.Service.Playlist;
using WinSonic.Service.SecureData;
using WinSonic.Service.Song;
using WinSonic.Service.Settings;
using WinSonic.Subsonic.Helpers;

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

        // Misc other bits
        services.AddScoped<IImageResizer, ImageSharpResizer>();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<MainViewModel>();
        services.AddScoped<SettingsViewModel>();
        services.AddScoped<SettingsWizardViewModel>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped<TestViewModel>();
        services.AddScoped<PlayerWindowViewModel>();

        // Browse
        services.AddTransient<AlbumsViewModel>();
        services.AddTransient<PlaylistsViewModel>();
        services.AddTransient<ArtistsViewModel>();

        // Detail
        services.AddTransient<SingleAlbumViewModel>();
        services.AddTransient<SinglePlaylistViewModel>();
        services.AddTransient<SingleArtistViewModel>();

        // Components
        services.AddTransient<PlaybackControlsViewModel>();
        services.AddTransient<CoverArtViewModel>();

        return services;
    }

    private static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        //Data services
        services.AddScoped<IAlbumService, CachedAlbumService>();
        services.AddScoped<IArtistService, CachedArtistService>();
        services.AddScoped<IPlaylistService, CachedPlaylistService>();
        services.AddTransient<IArtworkService, CachedArtworkService>();
        services.AddSingleton<ISongService, CachedSongService>();
        services.AddScoped<IPlaybackHistoryService, StoredPlaybackHistoryService>();
        services.AddScoped<ISettingsService, StoredSettingsService>();

        // Extra data services
        services.AddScoped<LiveArtworkService>();
        services.AddSingleton<LiveSongService>();
        services.AddScoped<ServerPlaybackHistoryService>();

        //Playback services
        services.AddSingleton<PlayQueue>();
        services.AddSingleton<StorageManager>();
        services.AddSingleton<AutoPlaybackManager>();
        services.AddSingleton<ISoundFlowPlayer, SoundFlowMultiPlayer>();

        //Api services
        services.AddSingleton<SubsonicApiWrapper>(CreateSubsonicApiWrapper);

        services.AddSingleton<SongFetcher>();

        //Sync services
        services.AddSingleton<SyncManager>();

        return services;
    }

    private static SubsonicApiWrapper CreateSubsonicApiWrapper(IServiceProvider provider)
    {
        var dbContext = provider.GetRequiredService<BaseDataContext>();
        var secureDataService = provider.GetRequiredService<ISecureDataService>();

        var settings = dbContext.Settings
            .AsNoTracking()
            .SingleOrDefault(s => s.Id == 1);

        var builder = new SubsonicConnectionBuilder();

        if (settings is not null && !string.IsNullOrWhiteSpace(settings.ServerAddress))
        {
            var password = string.IsNullOrWhiteSpace(settings.PasswordCredentialKey)
                ? string.Empty
                : secureDataService.GetValueByKey(settings.PasswordCredentialKey) ?? string.Empty;

            builder
                .WithServerUrl(settings.ServerAddress)
                .WithUsernameAndPassword(settings.Username, password)
                .WithIgnoreSslErrors(settings.IgnoreSslErrors);
        }

        return builder.Build();
    }

    public static void AddDebugDummies(this IServiceCollection services)
    {
#if DEBUG
        services.AddSingletonFallback<ISystemMediaBroadcastService, DummySystemMediaBroadcastService>();
#endif
    }

    static IServiceCollection AddSingletonFallback<TInterface, TImplementation>(this IServiceCollection services) where TImplementation : class, TInterface where TInterface : class
    {
        if (services.All(s => s.ServiceType != typeof(TInterface)))
        {
            services.AddSingleton<TInterface, TImplementation>();
        }

        return services;
    }

    public static void InitialiseServices(this IServiceProvider serviceProvider)
    {
        var storageManager = serviceProvider.GetRequiredService<StorageManager>();
        storageManager.EnsureDirectoriesExist();
    }


}
