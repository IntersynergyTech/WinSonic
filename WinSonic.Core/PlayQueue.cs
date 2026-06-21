using System.Collections.Concurrent;
using WinSonic.Core.Models;

namespace WinSonic.Core;

public class PlayQueue
{
    public ConcurrentQueue<Song> UpcomingFromSource { get; } = new ConcurrentQueue<Song>();
    public LinkedList<Song> ManuallyEnqueued { get; } = new LinkedList<Song>();

    private bool _playFromManualQueue = false;

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

    public void ResetAndEnqueueFromSource(List<Song> source, bool shuffle)
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

    public IEnumerable<Song> EnumerateQueue()
    {
        if (_playFromManualQueue && ManuallyEnqueued.Count > 0)
        {
            foreach (var song in ManuallyEnqueued)
            {
                yield return song;
            }
        }
        else
        {
            foreach (var song in UpcomingFromSource)
            {
                yield return song;
            }
        }
    }
    
}
