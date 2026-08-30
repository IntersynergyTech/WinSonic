using System.Collections.Concurrent;
using WinSonic.Core.Models;

namespace WinSonic.Core;

public class PlayQueue
{
    public ConcurrentQueue<Song> UpcomingFromSource { get; } = new ConcurrentQueue<Song>();
    public LinkedList<Song> ManuallyEnqueued { get; } = new LinkedList<Song>();

    private bool _playFromManualQueue = true;

    public void Clear()
    {
        UpcomingFromSource.Clear();
        ManuallyEnqueued.Clear();
    }
    
    public Song? PeekNext()
    {
        if (_playFromManualQueue && ManuallyEnqueued.Count > 0)
        {
            return ManuallyEnqueued.First?.Value;
        }
        else if (UpcomingFromSource.TryPeek(out var nextSong))
        {
            return nextSong;
        }
        else
        {
            return null;
        }
    }

    public Song? Dequeue()
    {
        if (_playFromManualQueue && ManuallyEnqueued.Count > 0)
        {
            var first = ManuallyEnqueued.First?.Value;
            ManuallyEnqueued.RemoveFirst();
            return first;
        }
        else if (UpcomingFromSource.TryPeek(out var nextSong))
        {
            UpcomingFromSource.TryDequeue(out nextSong);
            return nextSong;
        }
        else
        {
            return null;
        }
    }

    public void ResetAndEnqueueFromSource(ICollection<Song> source, bool shuffle)
    {
        UpcomingFromSource.Clear();
        if (shuffle)
        {
            var rng = new Random();
            source = source.OrderBy(x => rng.Next()).ToList();
        }
        foreach (var song in source)
        {
            UpcomingFromSource.Enqueue(song);
        }
    }

    public void Enqueue(Song song, bool playNext)
    {
        if (playNext)
        {
            ManuallyEnqueued.AddFirst(song);
        }
        else
        {
            ManuallyEnqueued.AddLast(song);
        }
        
    }

    public IEnumerable<PlayQueueItem> EnumerateQueue(bool fullyContiguous = true)
    {
        if (_playFromManualQueue && ManuallyEnqueued.Count > 0)
        {
            foreach (var song in ManuallyEnqueued)
            {
                var pqi = new PlayQueueItem(song, true);
                yield return pqi;
            }

            if (fullyContiguous)
            {
                foreach (var song in UpcomingFromSource)
                {
                    yield return new(song);
                }
            }
        }
        else
        {
            foreach (var song in UpcomingFromSource)
            {
                yield return new(song);
            }
        }
    }

    
}

public class PlayQueueItem
{
    public PlayQueueItem(Song song, bool isManuallyEnqueued = false)
    {
        Song = song;    
        IsManuallyEnqueued = isManuallyEnqueued;
    }
        
    public Song Song { get; }
    public bool IsManuallyEnqueued { get; }
        
    public static implicit operator Song(PlayQueueItem item) => item.Song;
}