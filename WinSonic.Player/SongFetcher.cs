using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Service.Settings;
using WinSonic.Service.Song;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Player;

public class SongFetcher
{
    private readonly ILogger<SongFetcher> _logger;
    private readonly ISongService _songService;
    private readonly ISettingsService _settingsService;

    public SongFetcher(SubsonicApiWrapper api, StorageManager storage, ILogger<SongFetcher> logger, ISongService songService, ISettingsService settingsService)
    {
        _logger = logger;
        _songService = songService;
        _settingsService = settingsService;
    }
    
    private SongRequest GetTranscodeSettings()
    {
        var settings = _settingsService.GetSettingsAsync().GetAwaiter().GetResult();

        if (settings.RequestOriginalFiles)
        {
            return SongRequest.OriginalSource();
        }

        return new SongRequest
        {
            RequestOriginalSource = false,
            Format = settings.TranscodeFormat switch
            {
                TranscodeFormat.Ogg => "ogg",
                TranscodeFormat.Mp3 => "mp3",
                TranscodeFormat.Opus => "opus",
                TranscodeFormat.M4aAac => "aac",
                _ => throw new ArgumentOutOfRangeException(nameof(settings.TranscodeFormat), settings.TranscodeFormat, "Unsupported transcode format.")
            },
            MaxBitRate = settings.TranscodeBitrate
        };
    }

    public Stream FetchSong(Song song)
    {
        return FetchSong(song, GetTranscodeSettings(), acceptAnyCached: true);
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
        PrefetchSong(song, GetTranscodeSettings(), acceptAnyCached: true);
    }

    public void PrefetchSong(Song song, SongRequest? request, bool acceptAnyCached = true)
    {
        var songId = song.Id;
        _logger.LogInformation(
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

        _logger.LogInformation("Prefetch complete for song {SongId}.", songId);
    }
}
