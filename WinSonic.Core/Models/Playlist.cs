namespace WinSonic.Core.Models;

public class Playlist
{
    public string Id { get; }
    public string Name { get; }
    public int SongCount { get; }
    public TimeSpan Duration { get; }
    public DateTime Created { get; }
    public DateTime Changed { get; }
    public string Comment { get; }
    public string Owner { get; }
    public bool IsPublic { get; }
    public string CoverArtId { get; }
    public bool IsReadOnly { get; }
    public DateTime CacheExpiry { get; }

    public List<Song> Entries { get; }

    public Playlist(
        string id,
        string name,
        int songCount,
        TimeSpan duration,
        DateTime created,
        DateTime changed,
        string comment,
        string owner,
        bool isPublic,
        string coverArtId,
        bool isReadOnly,
        DateTime cacheExpiry,
        List<Song> entries
    )
    {
        Id = id;
        Name = name;
        SongCount = songCount;
        Duration = duration;
        Created = created;
        Changed = changed;
        Comment = comment;
        Owner = owner;
        IsPublic = isPublic;
        CoverArtId = coverArtId;
        IsReadOnly = isReadOnly;
        CacheExpiry = cacheExpiry;
        Entries = entries;
    }
}
