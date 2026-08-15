using WinSonic.Data.DbModels;
using WinSonic.Data.Utilities;
using WinSonic.Subsonic.Client.Model;

namespace WinSonic.Data.Sync.Mappers;

public static class PlaylistMapper
{
    public static DbPlaylist CreateDbPlaylist(this PlaylistWithSongs source, Dictionary<string, DbSong> existingSongs)
    {
        var playlist = new DbPlaylist
        {
            Id = source.Id,
            Title = source.Name,
            Owner = source.Owner,
            IsPublic = source.Public,
            SongCount = source.SongCount,
            Duration = source.Duration,
            CreatedAt = source.Created,
            UpdatedAt = source.Changed
        };

        playlist.AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);
        
        var songs = source.Entry.Select(x => GetSongForId(x.Id)).ToList();

        playlist.Songs = songs;

        return playlist;

        DbSong GetSongForId(string Id)
        {
            if (existingSongs.TryGetValue(Id, out var song))
            {
                return song;
            }
            else
            {
                var newSong =  new DbSong { Id = Id };
                existingSongs.Add(Id, newSong);
                return newSong;
            }
        }
    }

}
