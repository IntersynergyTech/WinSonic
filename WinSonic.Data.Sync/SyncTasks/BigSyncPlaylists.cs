using WinSonic.Data.DbModels;
using WinSonic.Data.Sync.Mappers;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync.SyncTasks;

public static class BigSyncPlaylists
{
    public static void SyncPlaylists(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api,
        BaseDataContext database
    )
    {
        var downloadedplaylists = DownloadAllPlaylists(cancellationToken, itemsPerRequest, api);
        Log($"Processing {downloadedplaylists.Count} playlists to cache DB...");
        ProcessDownloadedPlaylists(cancellationToken, database, downloadedplaylists);
    }
    
    private static void Log(string message)
    {
        Console.WriteLine($"[BIGSYNC]: {message}");
    }
    
    private static void ProcessDownloadedPlaylists(
        CancellationToken cancellationToken,
        BaseDataContext database,
        List<PlaylistWithSongs> downloadedPlaylists
    )
    {
        var downloadedDictionary = downloadedPlaylists.ToDictionary(x => x.Id);

        var allDownloadedIds = downloadedDictionary.Keys.ToHashSet();
        var allCachedIds = database.Playlists.Select(x => x.Id).ToHashSet();

        var updateIds = allDownloadedIds.Where(allCachedIds.Contains).ToList();
        var removeIds = allCachedIds.Except(updateIds).ToList();
        var addIds = allDownloadedIds.Except(updateIds).ToList();
        Log($"Change summary: Add {addIds.Count}, Update {updateIds.Count}, Remove {removeIds.Count}");
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Removing playlists which no longer exist...");
        database.Playlists.RemoveRange(database.Playlists.Where(x => removeIds.Contains(x.Id)));
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Adding new entries");
        var newPlaylists = downloadedPlaylists.Where(x => addIds.Contains(x.Id)).ToHashSet();
        AddNewPlaylistsToCache(cancellationToken, database, newPlaylists);
    }
    
    private static void AddNewPlaylistsToCache(
        CancellationToken cancellationToken,
        BaseDataContext database,
        HashSet<PlaylistWithSongs> downloadedPlaylists
    )
    {
        var addCounter = 0;
        var addedPlaylists = new List<DbPlaylist>();
        var addedSongEntities = new Dictionary<string, DbSong>();

        foreach (var downloadedPlaylist in downloadedPlaylists)
        {
            Log($"Saving playlist {downloadedPlaylist.Name} ({downloadedPlaylist.Id})");
            if (cancellationToken.IsCancellationRequested) break;

            try
            {
                var playlist = downloadedPlaylist.CreateDbPlaylist(addedSongEntities);
                Log($"SavingGen");
                database.AttachRange(playlist.Songs);
                Log($"SavingAttached");
                database.Playlists.Add(playlist);
                Log($"SavingAdded");
                addedPlaylists.Add(playlist);
                Log($"SavingDone");
                addCounter++;
            }catch(Exception e)
            {
                Log($"DIED Error saving playlist {downloadedPlaylist.Name} ({downloadedPlaylist.Id}): {e.Message}");
                continue;
            }
            
        }

        Log($"Added {addCounter} new playlists");
        
        var allSongs = addedPlaylists.SelectMany(x => x.Songs).ToList();
        //database.AttachRange(allSongs);
        database.SaveChanges();
        Log("Saved");
    }

    private static List<PlaylistWithSongs> DownloadAllPlaylists(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api
    )
    {
        var previousOffset = 0;
        var previousQueryResultCount = 0;
        bool continueQuery = true;

        Log($"Querying playlists:");
        var playlistsResponse = api.Playlists.GetPlaylists();
        var originalPlaylists = playlistsResponse.SubsonicResponse.GetGetPlaylistsSuccessResponse().Playlists.Playlist;
        
        var returnedplaylists = new List<PlaylistWithSongs>();
        

        foreach (var originalPlaylist in originalPlaylists)
        {
            if (cancellationToken.IsCancellationRequested) break;
            Log($"Downloading playlist: {originalPlaylist.Name} [{originalPlaylist.Id}]");

            var queryResponse = api.Playlists.GetPlaylist(originalPlaylist.Id);
            
            try
            {
                var success = queryResponse.SubsonicResponse.GetGetPlaylistSuccessResponse();
                var thisReturnedPlaylist = success.Playlist;

                if (thisReturnedPlaylist != null)
                {
                    returnedplaylists.Add(thisReturnedPlaylist);
                    Log($"Retrieved playlist: {thisReturnedPlaylist.Name} [{thisReturnedPlaylist.Id}]");
                }
                else
                {
                    Log($"No playlist returned for ID: {originalPlaylist.Id}");
                }
            }
            catch (Exception e)
            {
                var failure = queryResponse.SubsonicResponse.GetSubsonicFailureResponse();
                Log($"Failed to query: [{failure.Error.Code}]: {failure.Error.Message}");
                break;
            }
        }
        
        return returnedplaylists;
    }
}
