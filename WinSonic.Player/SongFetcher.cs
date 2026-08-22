using System.Diagnostics;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Player;

public class SongFetcher
{
    private const string DOWNLOAD_FORMAT = "raw";

    public SubsonicApiWrapper _api { get; }
    public StorageManager _storage { get; }
    private readonly ILogger<SongFetcher> _logger;

    public SongFetcher(SubsonicApiWrapper api, StorageManager storage, ILogger<SongFetcher> logger)
    {
        _api = api;
        _storage = storage;
        _logger = logger;
    }

    public Stream FetchSong(Song song)
    {
        var songId = song.Id;
        _logger.LogDebug("Fetching song: " + songId);
        // Check if it exists
        var songFile = _storage.GetSongFileInfo(songId);

        // If we don't have it already we will have to stream on demand.
        if (!songFile.Exists)
        {
            _logger.LogDebug("Song not found in storage, streaming: " + songId);
            return StreamSong(song);
        }

        _logger.LogDebug($"[{songId}] Loading from local file");
        return _storage.OpenSongFile(songId);
    }

    public void PrefetchSong(Song song)
    {
        var songId = song.Id;
        _logger.LogDebug($"[{songId}] Prefetching");
        var songFile = _storage.GetSongFileInfo(songId);

        if (!songFile.Exists)
        {
            _logger.LogDebug($"[{songId}] Not available in storage. Downloading for next play.");
            DownloadSong(song);
            _logger.LogDebug($"[{songId}] Song downloaded.");
        }
        else
        {
            _logger.LogDebug($"[{songId}] Song already available locally.");
        }
    }

    private Stream StreamSong(Song song)
    {
        var download = _api.MediaRetrieval.StreamWithHttpInfo(song.Id, format: DOWNLOAD_FORMAT);

        try
        {
            var downloadStream = download.Data;
            var memoryStream = new MemoryStream();
            downloadStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"[{song.Id}] Error streaming song: {ex.Message}");
            throw;
        }
    }

    private void DownloadSong(Song song)
    {
        // We copy to a memory stream first to avoid partial downloads in case of errors or not being fast enough.
        var downloadStream = _api.MediaRetrieval.Stream(song.Id, format: DOWNLOAD_FORMAT);
        var memoryStream = new MemoryStream();
        downloadStream.CopyTo(memoryStream);
        memoryStream.Position = 0;
        _storage.SaveSongFile(song.Id, memoryStream);
    }
}
