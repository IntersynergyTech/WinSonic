using System.Windows;
using System.Windows.Threading;
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
        InitGlobalContext();
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
        ServiceProvider = _serviceProvider;
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

    private static void InitGlobalContext()
    {
        Console.WriteLine("Initialising Global Context...");

        GlobalContext.PlayQueue = new PlayQueue();

        GlobalContext.StorageManager = new StorageManager();
        GlobalContext.StorageManager.EnsureDirectoriesExist();

        var builder = new SubsonicConnectionBuilder().WithDefaultUserCredentials();
        var client = builder.Build();
        GlobalContext.Subsonic = client;

        GlobalContext.SongFetcher = new SongFetcher(GlobalContext.Subsonic, GlobalContext.StorageManager);

        var player = new SoundFlowMultiPlayer();
        GlobalContext.AudioPlayer = player;

        GlobalContext.AutoPlaybackManager = new AutoPlaybackManager(
            GlobalContext.PlayQueue,
            GlobalContext.SongFetcher,
            GlobalContext.AudioPlayer
        );

        GlobalContext.DbContextFactory = new SqliteDataContextFactory(storageManager: GlobalContext.StorageManager);

        GlobalContext.SyncManager = new SyncManager(client, GlobalContext.DbContextFactory);

        Console.WriteLine("Initialised.");
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception);
        throw e.Exception;
    }
}
