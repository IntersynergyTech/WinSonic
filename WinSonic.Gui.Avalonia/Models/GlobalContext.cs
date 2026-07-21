using WinSonic.Core;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui.Avalonia.Models;

public class GlobalContext
{
    public static ISoundFlowPlayer AudioPlayer { get; set; }
    public static PlayQueue PlayQueue { get; set; }
    public static StorageManager StorageManager { get; set; }
    public static SongFetcher SongFetcher { get; set; }
    public static SubsonicApiWrapper Subsonic { get; set; }
}
