using System.Diagnostics;
using NAudio.Wave;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Player;

public class SongFetcher
{
    private const string DOWNLOAD_FORMAT = "raw";

    public SubsonicApiWrapper _api { get; }
    public StorageManager _storage { get; }

    public SongFetcher(SubsonicApiWrapper api, StorageManager storage)
    {
        _api = api;
        _storage = storage;
    }

    public Stream FetchSong(Song song)
    {
        var songId = song.Id;
        Debug.WriteLine("Fetching song: " + songId);
        // Check if it exists
        var songFile = _storage.GetSongFileInfo(songId);

        // If we don't have it already we will have to stream on demand.
        if (!songFile.Exists)
        {
            Debug.WriteLine("Song not found in storage, streaming: " + songId);
            return StreamSong(song);
        }

        Debug.WriteLine($"[{songId}] Loading from local file");
        return _storage.OpenSongFile(songId);
    }

    public void PrefetchSong(Song song)
    {
        var songId = song.Id;
        Debug.WriteLine($"[{songId}] Prefetching");
        var songFile = _storage.GetSongFileInfo(songId);

        if (!songFile.Exists)
        {
            Debug.WriteLine($"[{songId}] Not available in storage. Downloading for next play.");
            DownloadSong(song);
            Debug.WriteLine($"[{songId}] Song downloaded.");
        }
        else
        {
            Debug.WriteLine($"[{songId}] Song already available locally.");
        }
    }

    private Stream StreamSong(Song song)
    {
        var downloadStream = _api.MediaRetrieval.Stream(song.Id, format: DOWNLOAD_FORMAT);
        var memoryStream = new MemoryStream();
        downloadStream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        return memoryStream;
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
