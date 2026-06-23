namespace WinSonic.Core.Models;

public class PlaylistInfo
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

    public PlaylistInfo(
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
        DateTime cacheExpiry
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
    }
}

public class PlaylistFull : PlaylistInfo
{
    public PlaylistFull(
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
    ) : base(
        id,
        name,
        songCount,
        duration,
        created,
        changed,
        comment,
        owner,
        isPublic,
        coverArtId,
        isReadOnly,
        cacheExpiry
    )
    {
        Entries = entries;
    }

    public List<Song> Entries { get; }
}
