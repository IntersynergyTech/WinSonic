using System.Diagnostics;
using WinSonic.Core;
using WinSonic.Core.Enums;
using WinSonic.Core.Models;
using WinSonic.Player;
using WinSonic.Service.History;

namespace WinSonic.Playback;

public class AutoPlaybackManager
{
    public PlayQueue Queue { get; }
    public SongFetcher Fetcher { get; }
    public ISoundFlowPlayer Player { get; }
    private readonly IPlaybackHistoryService _playbackHistoryService;
    
    public Song? NowPlaying { get; private set; }
    
    private void UpdateNowPlaying(Song? song)
    {
        NowPlaying = song;
        
        if (song != null)
        {
            Task.Run(async () =>
            {
                try
                {
                    await _playbackHistoryService.ScrobbleNowPlaying(song);
                    Debug.WriteLine($"Scrobbled now playing track: {song.Title}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error scrobbling now playing track: {ex.Message}");
                }
            });
        }
        
        NowPlayingChanged?.Invoke(this, song);
    }
    
    public event EventHandler<Song?> NowPlayingChanged;

    public AutoPlaybackManager(
        PlayQueue queue,
        SongFetcher fetcher,
        ISoundFlowPlayer player,
        IPlaybackHistoryService playbackHistoryService
    )
    {
        Queue = queue;
        Fetcher = fetcher;
        Player = player;
        _playbackHistoryService = playbackHistoryService;

        Player.PlaybackStateChanged += OnPlaybackStateChanged;
    }

    public void StartPlayback()
    {
        PlayNextSongIfAvailable();
    }
    
    private void OnPlaybackStateChanged(object? sender, PlaybackState e)
    {
        Debug.WriteLine($"Playback state change reported: {e}");
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
                await _playbackHistoryService.ScrobbleCompleted(song);
                Debug.WriteLine($"Scrobbled completed track: {song.Title}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error scrobbling completed track: {ex.Message}");
            }
        });
    }

    private void PlayNextSongIfAvailable()
    {
        var queuedSong = Queue.Dequeue();
        if (queuedSong != null)
        {
            Debug.WriteLine($"Playing next song: {queuedSong.Title}");
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
                        Debug.WriteLine($"Async prefretch next song {nextUp.Title}:");
                        Fetcher.PrefetchSong(nextUp);
                    }
                    else
                    {
                        Debug.WriteLine("No next song to prefetch.");
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
}
