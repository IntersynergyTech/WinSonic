using WinSonic.Core.Models;

namespace WinSonic.Gui.Common.Messages;

public class TrackContextQueueMessage
{
    public TrackContextQueueMessage(Song song, TrackContextQueueType type)
    {
        Song = song;
        Type = type;
    }
    
    public Song Song { get; }
    public TrackContextQueueType Type { get; }

    public enum TrackContextQueueType
    {
        // Adds to the end of the manually enqueued songs, after which the context autoplay continues
        AddToQueue,

        // Adds to the front of the queue, before the next song plays
        PlayNext,

        // Adds to the end of the autoplay context queue.
        AddToEnd
    }
}
