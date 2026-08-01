using WinSonic.Core.Models;
using Song = WinSonic.Data.DbModels.Song;

namespace WinSonic.Data.Sync.Mappers;

public static class ServiceMappers
{
    public static Core.Models.Song ToSong(Song song)
    {
        return new Core.Models.Song(
            song.Id,
            song.Album?.Title,
            "",
            song.Artist?.Title,
            Array.Empty<Core.Models.Artist>(),
            song.CoverArt?.Id,
            TimeSpan.FromSeconds(song.Duration ?? 0),
            song.IsExplicit,
            new ReplayGain(song.RgAlbumGain, song.RgAlbumPeak, song.RgTrackGain, song.RgTrackPeak),
            song.Title
        );
    }
}
