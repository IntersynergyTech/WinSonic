namespace WinSonic.Core.Models;

public class AlbumInfo
{
    public string Id { get; }
    public string Title { get; }
    public string? SortTitle { get; }
    public string? Artist { get; }
    public string? CoverArtId { get; }
    public int SongCount { get; }
    public TimeSpan Duration { get; }
    public bool IsExplicit { get; }

    public AlbumInfo(
        string id,
        string title,
        string? sortTitle,
        string? artist,
        string? coverArtId,
        int songCount,
        TimeSpan duration,
        bool isExplicit
    )
    {
        Id = id;
        Title = title;
        SortTitle = sortTitle;
        Artist = artist;
        CoverArtId = coverArtId;
        SongCount = songCount;
        Duration = duration;
        IsExplicit = isExplicit;
    }
}

public class AlbumFull : AlbumInfo
{
    public List<Song> Songs { get; }

    public AlbumFull(
        string id,
        string title,
        string? sortTitle,
        string? artist,
        string? coverArtId,
        int songCount,
        TimeSpan duration,
        bool isExplicit,
        List<Song> songs
    ) : base(id, title, sortTitle, artist, coverArtId, songCount, duration, isExplicit)
    {
        Songs = songs;
    }
}
