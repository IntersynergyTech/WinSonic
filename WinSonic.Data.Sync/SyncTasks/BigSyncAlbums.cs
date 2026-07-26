using WinSonic.Data.Sync.Mappers;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync.SyncTasks;

public static class BigSyncAlbums
{
    public static void SyncAlbums(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api,
        BaseDataContext database
    )
    {
        var downloadedalbums = DownloadAllAlbums(cancellationToken, itemsPerRequest, api);
        Log($"Processing {downloadedalbums.Count} albums to cache DB...");
        ProcessDownloadedAlbums(cancellationToken, database, downloadedalbums);
    }

    private static void Log(string message)
    {
        Console.WriteLine($"[BIGSYNC]: {message}");
    }

    private static void ProcessDownloadedAlbums(
        CancellationToken cancellationToken,
        BaseDataContext database,
        List<AlbumID3> downloadedAlbums
    )
    {
        var downloadedDictionary = downloadedAlbums.ToDictionary(x => x.Id);

        var allDownloadedIds = downloadedDictionary.Keys.ToHashSet();
        var allCachedIds = database.Albums.Select(x => x.Id).ToHashSet();

        var updateIds = allDownloadedIds.Where(allCachedIds.Contains).ToList();
        var removeIds = allCachedIds.Except(updateIds).ToList();
        var addIds = allDownloadedIds.Except(updateIds).ToList();
        Log($"Change summary: Add {addIds.Count}, Update {updateIds.Count}, Remove {removeIds.Count}");
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Removing albums which no longer exist...");
        database.Albums.RemoveRange(database.Albums.Where(x => removeIds.Contains(x.Id)));
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Adding new entries");
        var newAlbums = downloadedAlbums.Where(x => addIds.Contains(x.Id)).ToHashSet();
        AddNewAlbumsToCache(cancellationToken, database, newAlbums);
    }

    private static void AddNewAlbumsToCache(
        CancellationToken cancellationToken,
        BaseDataContext database,
        HashSet<AlbumID3> downloadedAlbums
    )
    {
        var existingArtists = database.Artists.ToDictionary(x => x.Id);

        var addCounter = 0;

        foreach (var downloadedAlbum in downloadedAlbums)
        {
            if (cancellationToken.IsCancellationRequested) break;

            var albumExistingArtist = existingArtists.GetValueOrDefault(downloadedAlbum.ArtistId);

            var album = downloadedAlbum.CreateDbAlbum(albumExistingArtist, existingArtists);

            database.Albums.Add(album);
            addCounter++;
        }

        Log($"Added {addCounter} new albums");

        database.SaveChanges();
    }

    private static List<AlbumID3> DownloadAllAlbums(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api
    )
    {
        var previousOffset = 0;
        var previousQueryResultCount = 0;
        bool continueQuery = true;

        var returnedalbums = new List<AlbumID3>();

        do
        {
            if (cancellationToken.IsCancellationRequested) break;

            Log($"Querying albums: OS {previousOffset}");

            var queryResponse = api.Searching.Search3(
                "",
                songCount: 0,
                artistCount: 0,
                albumCount: itemsPerRequest,
                albumOffset: previousOffset
            );

            try
            {
                var success = queryResponse.SubsonicResponse.GetSearch3SuccessResponse();
                var thisReturnedAlbums = success.SearchResult3.Album;

                if (thisReturnedAlbums?.Count > 0)
                {
                    returnedalbums.AddRange(thisReturnedAlbums);
                    previousQueryResultCount = thisReturnedAlbums.Count;
                    previousOffset += thisReturnedAlbums.Count;
                    Log($"Retrieved {thisReturnedAlbums.Count} albums. Continuing...");
                }
                else
                {
                    continueQuery = false;
                    Log($"No more albums available.");
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

        return returnedalbums;
    }
}
