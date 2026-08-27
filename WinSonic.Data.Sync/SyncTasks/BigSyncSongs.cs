using Microsoft.Extensions.Logging;
using WinSonic.Data.Sync.Mappers;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync.SyncTasks;

public static class BigSyncSongs
{
    public static void SyncSongs(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api,
        BaseDataContext database,
        ILogger<BigSync> logger
    )
    {
        _logger = logger;
        var downloadedSongs = DownloadAllSongs(cancellationToken, itemsPerRequest, api);
        Log($"Processing {downloadedSongs.Count} songs to cache DB...");
        ProcessDownloadedSongs(cancellationToken, database, downloadedSongs);
    }

    private static ILogger<BigSync> _logger;

    private static void Log(string message)
    {
        _logger.LogInformation(message);
    }


    private static void ProcessDownloadedSongs(
        CancellationToken cancellationToken,
        BaseDataContext database,
        List<Child> downloadedSongs
    )
    {
        var downloadedDictionary = downloadedSongs.ToDictionary(x => x.Id);

        var allDownloadedIds = downloadedDictionary.Keys.ToHashSet();
        var allCachedIds = database.Songs.Select(x => x.Id).ToHashSet();

        var updateIds = allDownloadedIds.Where(allCachedIds.Contains).ToList();
        var removeIds = allCachedIds.Except(updateIds).ToList();
        var addIds = allDownloadedIds.Except(updateIds).ToList();
        Log($"Change summary: Add {addIds.Count}, Update {updateIds.Count}, Remove {removeIds.Count}");
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Removing songs which no longer exist...");
        database.Songs.RemoveRange(database.Songs.Where(x => removeIds.Contains(x.Id)));
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Adding new entries");
        var newSongs = downloadedSongs.Where(x => addIds.Contains(x.Id)).ToHashSet();
        AddNewSongsToCache(cancellationToken, database, newSongs);
    }

    private static void AddNewSongsToCache(
        CancellationToken cancellationToken,
        BaseDataContext database,
        HashSet<Child> downloadedSongs
    )
    {
        var existingArtists = database.Artists.ToDictionary(x => x.Id);
        var existingAlbums = database.Albums.ToDictionary(x => x.Id);
        var existingCoverArt = database.CoverArt.ToDictionary(x => x.Id);
        
        var addCounter = 0;

        foreach (var downloadedSong in downloadedSongs)
        {
            if (cancellationToken.IsCancellationRequested) break;
            var songExistingAlbum = existingAlbums.GetValueOrDefault(downloadedSong.AlbumId) ?? database.Albums.Local.FirstOrDefault(x => x.Id == downloadedSong.AlbumId);
            var songExistingArtist = existingArtists.GetValueOrDefault(downloadedSong.ArtistId) ?? database.Artists.Local.FirstOrDefault(x => x.Id == downloadedSong.ArtistId);
            var songExistingCoverArt = existingCoverArt.GetValueOrDefault(downloadedSong.CoverArt) ?? database.CoverArt.Local.FirstOrDefault(x => x.Id == downloadedSong.CoverArt);

            var song = downloadedSong.CreateDbSong(
                songExistingAlbum,
                songExistingArtist,
                songExistingCoverArt,
                existingArtists
            );

            database.Songs.Add(song);
            addCounter++;
        }

        Log($"Added {addCounter} new songs");

        database.SaveChanges();
    }

    private static List<Child> DownloadAllSongs(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api
    )
    {
        var previousOffset = 0;
        var previousQueryResultCount = 0;
        bool continueQuery = true;

        var returnedSongs = new List<Child>();

        do
        {
            if (cancellationToken.IsCancellationRequested) break;

            Log($"Querying songs: OS {previousOffset}");

            var queryResponse = api.Searching.Search3(
                "",
                artistCount: 0,
                albumCount: 0,
                songCount: itemsPerRequest,
                songOffset: previousOffset
            );

            try
            {
                var success = queryResponse.SubsonicResponse.GetSearch3SuccessResponse();
                var thisReturnedSongs = success.SearchResult3.Song;

                if (thisReturnedSongs?.Count > 0)
                {
                    returnedSongs.AddRange(thisReturnedSongs);
                    previousQueryResultCount = thisReturnedSongs.Count;
                    previousOffset += thisReturnedSongs.Count;
                    Log($"Retrieved {thisReturnedSongs.Count} songs. Continuing...");
                }
                else
                {
                    continueQuery = false;
                    Log($"No more songs available.");
                }
            }
            catch (Exception e)
            {
                var failure = queryResponse.SubsonicResponse.GetSubsonicFailureResponse();
                Log($"Failed to query: [{failure.Error.Code}]: {failure.Error.Message}");
                continueQuery = false;
                break;
            }
        } while (previousQueryResultCount > 0 && continueQuery && !cancellationToken.IsCancellationRequested);

        return returnedSongs;
    }
}
