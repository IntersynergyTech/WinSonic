using System.Diagnostics;
using WinSonic.Core;
using WinSonic.Core.Enums;
using WinSonic.Core.Models;
using WinSonic.Player;

namespace WinSonic.Playback;

public class AutoPlaybackManager
{
    public PlayQueue Queue { get; }
    public SongFetcher Fetcher { get; }
    public ISoundFlowPlayer Player { get; }
    public Song? NowPlaying { get; private set; }
    
    private void UpdateNowPlaying(Song? song)
    {
        NowPlaying = song;
        NowPlayingChanged?.Invoke(this, song);
    }
    
    public event EventHandler<Song?> NowPlayingChanged;

    public AutoPlaybackManager(
        PlayQueue queue,
        SongFetcher fetcher,
        ISoundFlowPlayer player
    )
    {
        Queue = queue;
        Fetcher = fetcher;
        Player = player;

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
            UpdateNowPlaying(null);
            PlayNextSongIfAvailable();
        }
        else  if (e == PlaybackState.Stopped)
        {
            UpdateNowPlaying(null);
        }
    }

    private void PlayNextSongIfAvailable()
    {
        var queuedSong = Queue.Dequeue();
        if (queuedSong != null)
        {
            Debug.WriteLine($"Playing next song: {queuedSong.Title}");
            var stream = Fetcher.FetchSong(queuedSong);
            Player.LoadStream(stream);
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
