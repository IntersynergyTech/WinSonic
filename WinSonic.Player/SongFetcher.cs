using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Service.Song;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Player;

public class SongFetcher
{
    private readonly ILogger<SongFetcher> _logger;
    private readonly ISongService _songService;

    public SongFetcher(SubsonicApiWrapper api, StorageManager storage, ILogger<SongFetcher> logger, ISongService songService)
    {
        _logger = logger;
        _songService = songService;
    }

    public Stream FetchSong(Song song)
    {
        return FetchSong(song, SongRequest.OriginalSource(), acceptAnyCached: true);
    }

    public Stream FetchSong(Song song, SongRequest? request, bool acceptAnyCached = true)
    {
        var songId = song.Id;
        _logger.LogDebug(
            "Fetching song {SongId} via song service (format={Format}, maxBitRate={BitRate}, acceptAnyCached={AcceptAnyCached}, original={Original}).",
            songId,
            request?.Format,
            request?.MaxBitRate,
            acceptAnyCached,
            request?.RequestOriginalSource ?? false
        );

        return _songService
            .GetSongAsync(songId, request, acceptAnyCached)
            .GetAwaiter()
            .GetResult();
    }

    public void PrefetchSong(Song song)
    {
        PrefetchSong(song, SongRequest.OriginalSource(), acceptAnyCached: true);
    }

    public void PrefetchSong(Song song, SongRequest? request, bool acceptAnyCached = true)
    {
        var songId = song.Id;
        _logger.LogDebug(
            "Prefetching song {SongId} via song service (format={Format}, maxBitRate={BitRate}, acceptAnyCached={AcceptAnyCached}, original={Original}).",
            songId,
            request?.Format,
            request?.MaxBitRate,
            acceptAnyCached,
            request?.RequestOriginalSource ?? false
        );

        using var _ = _songService
            .GetSongAsync(songId, request, acceptAnyCached)
            .GetAwaiter()
            .GetResult();

        _logger.LogDebug("Prefetch complete for song {SongId}.", songId);
    }
}
