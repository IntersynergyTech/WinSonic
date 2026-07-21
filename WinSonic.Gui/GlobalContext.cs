using System.Windows.Threading;
using WinSonic.Core;
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui;

public static class GlobalContext
{
    public static ISoundFlowPlayer AudioPlayer { get; set; }
    public static PlayQueue PlayQueue { get; set; }
    public static StorageManager StorageManager { get; set; }
    public static SongFetcher SongFetcher { get; set; }
    public static SubsonicApiWrapper Subsonic { get; set; }
    public static AutoPlaybackManager AutoPlaybackManager { get; set; }
    
    public static Dispatcher Dispatcher { get; set; }

    public static void InvokeOnUi(Action action, bool swallowErrors = false)
    {
        try
        {
            Dispatcher.BeginInvoke(action);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            if (!swallowErrors)
            {
                throw ex;
            }
        }
    }
}
