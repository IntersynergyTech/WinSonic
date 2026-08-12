using WinSonic.Data.DbModels;
using WinSonic.Data.Utilities;
using WinSonic.Subsonic.Client.Model;
using Playlist = WinSonic.Data.DbModels.Playlist;

namespace WinSonic.Data.Sync.Mappers;

public static class PlaylistMapper
{
    public static Playlist CreateDbPlaylist(this PlaylistWithSongs source, Dictionary<string, Song> existingSongs)
    {
        var playlist = new Playlist
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

        Song GetSongForId(string Id)
        {
            if (existingSongs.TryGetValue(Id, out var song))
            {
                return song;
            }
            else
            {
                var newSong =  new Song { Id = Id };
                existingSongs.Add(Id, newSong);
                return newSong;
            }
        }
    }

}
