using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using WinSonic.Core;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnLoadCompleted(NavigationEventArgs e)
    {
        base.OnLoadCompleted(e);
        InitGlobalContext();
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

        Console.WriteLine("Initialised.");
    }
}


