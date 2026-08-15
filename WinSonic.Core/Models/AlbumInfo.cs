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
    public int? Year { get; set; }
    public bool IsExplicit { get; }

    public AlbumInfo(
        string id,
        string title,
        string? sortTitle,
        string? artist,
        string? coverArtId,
        int songCount,
        TimeSpan duration,
        int? year,
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
        Year = year;
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
        int? year,
        bool isExplicit,
        List<Song> songs
    ) : base(id, title, sortTitle, artist, coverArtId, songCount, duration, year, isExplicit)
    {
        Songs = songs;
    }
}
