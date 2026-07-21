using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using WinSonic.Core;
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        GlobalContext.Dispatcher = Dispatcher.CurrentDispatcher;
        InitGlobalContext();
    }

    protected override void OnLoadCompleted(NavigationEventArgs e)
    {
        base.OnLoadCompleted(e);
        
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

        Console.WriteLine("Initialised.");
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception);
        throw e.Exception;
    }
}


