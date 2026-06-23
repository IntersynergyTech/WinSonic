using WinSonic.Core;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui;

public static class GlobalContext
{
    public static WaveAudioPlayer WaveAudioPlayer { get; set; }
    public static PlayQueue PlayQueue { get; set; }
    public static StorageManager StorageManager { get; set; }
    public static SongFetcher SongFetcher { get; set; }
    public static SubsonicApiWrapper Subsonic { get; set; }
}
