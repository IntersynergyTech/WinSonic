using Microsoft.Extensions.Logging;
using WinSonic.Data.Sync.Mappers;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync.SyncTasks;

public static class BigSyncArtists
{
    public static void SyncArtists(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api,
        BaseDataContext database,
        ILogger<BigSync> logger
    )
    {
        _logger = logger;
        var downloadedartists = DownloadAllArtists(cancellationToken, itemsPerRequest, api);
        Log($"Processing {downloadedartists.Count} artists to cache DB...");
        ProcessDownloadedArtists(cancellationToken, database, downloadedartists);
    }

    private static ILogger<BigSync> _logger;

    private static void Log(string message)
    {
        _logger.LogInformation(message);
    }

    private static void ProcessDownloadedArtists(
        CancellationToken cancellationToken,
        BaseDataContext database,
        List<ArtistID3> downloadedArtists
    )
    {
        var downloadedDictionary = downloadedArtists.ToDictionary(x => x.Id);

        var allDownloadedIds = downloadedDictionary.Keys.ToHashSet();
        var allCachedIds = database.Artists.Select(x => x.Id).ToHashSet();

        var updateIds = allDownloadedIds.Where(allCachedIds.Contains).ToList();
        var removeIds = allCachedIds.Except(updateIds).ToList();
        var addIds = allDownloadedIds.Except(updateIds).ToList();
        Log($"Change summary: Add {addIds.Count}, Update {updateIds.Count}, Remove {removeIds.Count}");
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Removing artists which no longer exist...");
        database.Artists.RemoveRange(database.Artists.Where(x => removeIds.Contains(x.Id)));
        if (cancellationToken.IsCancellationRequested) return;

        Log($"Adding new entries");
        var newArtists = downloadedArtists.Where(x => addIds.Contains(x.Id)).ToHashSet();
        AddNewArtistsToCache(cancellationToken, database, newArtists);
    }

    private static void AddNewArtistsToCache(
        CancellationToken cancellationToken,
        BaseDataContext database,
        HashSet<ArtistID3> downloadedArtists
    )
    {
        var addCounter = 0;

        foreach (var downloadedArtist in downloadedArtists)
        {
            if (cancellationToken.IsCancellationRequested) break;

            var artist = downloadedArtist.CreateDbArtist();

            database.Artists.Add(artist);
            addCounter++;
        }

        Log($"Added {addCounter} new artists");

        database.SaveChanges();
    }

    private static List<ArtistID3> DownloadAllArtists(
        CancellationToken cancellationToken,
        int itemsPerRequest,
        SubsonicApiWrapper api
    )
    {
        var previousOffset = 0;
        var previousQueryResultCount = 0;
        bool continueQuery = true;

        var returnedartists = new List<ArtistID3>();

        do
        {
            if (cancellationToken.IsCancellationRequested) break;

            Log($"Querying artists: OS {previousOffset}");

            var queryResponse = api.Searching.Search3(
                "",
                songCount: 0,
                albumCount: 0,
                artistCount: itemsPerRequest,
                artistOffset: previousOffset
            );

            try
            {
                var success = queryResponse.SubsonicResponse.GetSearch3SuccessResponse();
                var thisReturnedArtists = success.SearchResult3.Artist;

                if (thisReturnedArtists?.Count > 0)
                {
                    returnedartists.AddRange(thisReturnedArtists);
                    previousQueryResultCount = thisReturnedArtists.Count;
                    previousOffset += thisReturnedArtists.Count;
                    Log($"Retrieved {thisReturnedArtists.Count} artists. Continuing...");
                }
                else
                {
                    continueQuery = false;
                    Log($"No more artists available.");
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

        return returnedartists;
    }
}
