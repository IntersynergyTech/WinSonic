using System.Diagnostics;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Enums;
using WinSonic.Core.Models;
using WinSonic.Playback.Platform;
using WinSonic.Player;
using WinSonic.Service.History;

namespace WinSonic.Playback;

public class AutoPlaybackManager
{
    private readonly IPlaybackHistoryService _playbackHistoryService;
    private readonly ILogger<AutoPlaybackManager> _logger;
    private readonly ISystemMediaBroadcastService _systemMediaBroadcastService;

    public PlayQueue Queue { get; }
    public SongFetcher Fetcher { get; }
    public ISoundFlowPlayer Player { get; }

    public Song? NowPlaying { get; private set; }


    public AutoPlaybackManager(
        PlayQueue queue,
        SongFetcher fetcher,
        ISoundFlowPlayer player,
        IPlaybackHistoryService playbackHistoryService,
        ISystemMediaBroadcastService systemMediaBroadcastService,
        ILogger<AutoPlaybackManager> logger
    )
    {
        Queue = queue;
        Fetcher = fetcher;
        Player = player;
        _playbackHistoryService = playbackHistoryService;
        _systemMediaBroadcastService = systemMediaBroadcastService;
        _logger = logger;

        Player.PlaybackStateChanged += OnPlaybackStateChanged;

        _systemMediaBroadcastService.PauseRequested += (sender, args) => Player.Pause();
        _systemMediaBroadcastService.PlayRequested += (sender, args) => Player.Play();
        _systemMediaBroadcastService.NextRequested += (sender, args) => NextSong();
        _systemMediaBroadcastService.SetVolumeRequested += (sender, volume) => SetVolume((float)volume);
    }

    private void UpdateNowPlaying(Song? song)
    {
        NowPlaying = song;

        if (song != null)
        {
            _systemMediaBroadcastService.BroadcastMediaInfo(song.Title, song.Artist, song.Album.Title);
            Task.Run(async () =>
            {
                try
                {
                    await _playbackHistoryService.ScrobbleNowPlaying(song);
                    _logger.LogDebug("Scrobbled now playing track: {songTitle}", song.Title);
                }
                catch (Exception ex)
                {
                    _logger.LogDebug("Error scrobbling now playing track: {errorMessage}", ex.Message);
                }
            });
        }

        NowPlayingChanged?.Invoke(this, song);
    }

    public event EventHandler<Song?> NowPlayingChanged;

    public void StartPlayback()
    {
        PlayNextSongIfAvailable();
    }

    private void OnPlaybackStateChanged(object? sender, PlaybackState e)
    {
        _logger.LogDebug("Playback state change reported: {playbackState}", e);
        if (e == PlaybackState.Ended)
        {
            ScrobbleTrack(NowPlaying);
            UpdateNowPlaying(null);
            PlayNextSongIfAvailable();
        }
        else  if (e == PlaybackState.Stopped)
        {
            UpdateNowPlaying(null);
        }

        if (NowPlaying?.Id != Player.NowPlaying?.Id)
        {
            UpdateNowPlaying(Player.NowPlaying);

        }
    }

    private void ScrobbleTrack(Song song)
    {
        Task.Run(async () =>
        {
            try
            {
                var playTime = DateTime.UtcNow.AddSeconds(-song.Duration.TotalSeconds);
                await _playbackHistoryService.ScrobbleCompleted(song, playTime);
                _logger.LogDebug("Scrobbled completed track: {songTitle} started at {playTime}", song.Title, playTime);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error scrobbling completed track: {errorMessage}", ex.Message);
            }
        });
    }

    private void PlayNextSongIfAvailable()
    {
        var queuedSong = Queue.Dequeue();
        if (queuedSong != null)
        {
            _logger.LogDebug("Playing next song: {songTitle}", queuedSong.Title);
            var stream = Fetcher.FetchSong(queuedSong);
            Player.LoadStream(stream, queuedSong);
            Player.Play();
            UpdateNowPlaying(queuedSong);

            Task.Run(
                (() =>
                {
                    var nextUp = Queue.PeekNext();

                    if (nextUp != null)
                    {
                        _systemMediaBroadcastService.SetCanGoNext(true);
                        _logger.LogDebug("Async prefetch next song: {songTitle}", nextUp.Title);
                        Fetcher.PrefetchSong(nextUp);
                    }
                    else
                    {
                        _systemMediaBroadcastService.SetCanGoNext(false);
                        _logger.LogDebug("No next song to prefetch.");
                    }
                })
            );

        }
    }

    public void NextSong()
    {
        Player.Stop();
        PlayNextSongIfAvailable();
    }

    public void SetVolume(float volume)
    {
        Player.Volume = volume;
        _systemMediaBroadcastService.BroadcastVolume(volume);
    }
}
