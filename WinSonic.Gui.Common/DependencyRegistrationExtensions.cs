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
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Service.Album;
using WinSonic.Service.Artist;
using WinSonic.Service.Artwork;
using WinSonic.Service.Playlist;
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
        services.AddScoped<AlbumsViewModel>();
        services.AddScoped<PlaylistsViewModel>();
        services.AddScoped<ArtistsViewModel>();
        
        // Detail
        services.AddScoped<SingleAlbumViewModel>();
        services.AddScoped<SinglePlaylistViewModel>();
        services.AddScoped<SingleArtistViewModel>();
        
        // Components
        services.AddScoped<PlaybackControlsViewModel>();
        services.AddScoped<CoverArtViewModel>();
        
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
        services.AddScoped<IArtworkService, CachedArtworkService>();
        
        // Extra data services
        services.AddScoped<LiveArtworkService>();
        
        //Playback services
        services.AddSingleton<PlayQueue>();
        services.AddSingleton<StorageManager>();
        services.AddSingleton<AutoPlaybackManager>();
        services.AddSingleton<ISoundFlowPlayer, SoundFlowMultiPlayer>();
        
        //Api services
        services.AddSingleton<SubsonicApiWrapper>(provider =>
        {
            //Temporary until we have a proper login flow
            var builder = new SubsonicConnectionBuilder().WithDefaultUserCredentials();
            var client = builder.Build();
            return client;
        });
        services.AddSingleton<SongFetcher>();
        
        //Sync services
        services.AddSingleton<SyncManager>();

        return services;
    }

    public static void InitialiseServices(this IServiceProvider serviceProvider)
    {
        var storageManager = serviceProvider.GetRequiredService<StorageManager>();
        storageManager.EnsureDirectoriesExist();
    }
}
