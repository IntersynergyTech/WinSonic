using System.Configuration;
using System.Data;
using System.Windows;
using WinSonic.Core;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
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
        
        var player = AudioPlayerBuilder.Default().Build();
        GlobalContext.WaveAudioPlayer = player;

        Console.WriteLine("Initialised.");
    }
}


