using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.Sqlite;
using WinSonic.Data.Sync;
using WinSonic.Gui.Common;
using WinSonic.Gui.Pages;
using WinSonic.Gui.Windows;
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Service.Artist;
using WinSonic.Service.Playlist;
using WinSonic.Subsonic.Helpers;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.DependencyInjection;
using NavigationService = Wpf.Ui.NavigationService;

namespace WinSonic.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    public static App Instance { get; private set; }

    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        Instance = this;
        base.OnStartup(e);
        GlobalContext.Dispatcher = Dispatcher.CurrentDispatcher;
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
        ServiceProvider = _serviceProvider;
        InitGlobalContext(_serviceProvider);
        var mainWindow = _serviceProvider.GetRequiredService<PlayerWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddCommonGuiServices();

        // UI Stuff
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<INavigationViewPageProvider, DependencyInjectionNavigationViewPageProvider>();
        services.AddNavigationViewPageProvider();
        
        //Window
        services.AddSingleton<PlayerWindow>();
        
        // Core bits
        services.AddSingleton<StorageManager>();
        services.AddSingleton<SyncManager>();
        services.AddSingleton<AutoPlaybackManager>();
        services.AddSingleton<SongFetcher>();

        //Data services
        services.AddScoped<IArtistService, CachedArtistService>();
        services.AddScoped<IPlaylistService, CachedPlaylistService>();

        services.ConfigurePages();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }

        base.OnExit(e);
    }

    private static void InitGlobalContext(IServiceProvider serviceProvider)
    {
        Console.WriteLine("Initialising Global Context...");
        GlobalContext.StorageManager = serviceProvider.GetRequiredService<StorageManager>();
        GlobalContext.PlayQueue = serviceProvider.GetRequiredService<PlayQueue>();
        GlobalContext.Subsonic = serviceProvider.GetRequiredService<SubsonicApiWrapper>();
        GlobalContext.SongFetcher = serviceProvider.GetRequiredService<SongFetcher>();
        GlobalContext.AudioPlayer = serviceProvider.GetRequiredService<ISoundFlowPlayer>();
        GlobalContext.AutoPlaybackManager = serviceProvider.GetRequiredService<AutoPlaybackManager>();
        GlobalContext.SyncManager = serviceProvider.GetRequiredService<SyncManager>();
        GlobalContext.DbContextFactory = (SqliteDataContextFactory)serviceProvider.GetRequiredService<IDbContextFactory<BaseDataContext>>();

        Console.WriteLine("Initialised.");
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception);
        throw e.Exception;
    }
}
