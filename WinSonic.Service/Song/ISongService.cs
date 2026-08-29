namespace WinSonic.Service.Song;

public interface ISongService
{
    Task<Stream> GetSongAsync(
        string songId,
        SongRequest? request = null,
        bool acceptAnyCached = true,
        CancellationToken cancellationToken = default
    );

    Task<Stream> CacheDownloadedSongAsync(
        string songId,
        Stream stream,
        SongRequest? request = null,
        CancellationToken cancellationToken = default
    );
}
