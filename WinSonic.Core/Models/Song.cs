namespace WinSonic.Core.Models;

public class Song
{
    public string Id { get; }
    public string Album { get; }
    public string AlbumId { get; }

    public string Artist { get; }
    public Artist[] Artists { get; }

    public string CoverArtId { get; }
    public TimeSpan Duration { get; }

    public bool IsExplicit { get; }
    
    public ReplayGain ReplayGain { get; }

    public string Title { get; }


    public Song(string id, string album,
        string albumId,
        string artist,
        Artist[] artists,
        string coverArtId,
        TimeSpan duration,
        bool isExplicit,
        ReplayGain replayGain,
        string title
    )
    {
        Id = id;
        Album = album;
        AlbumId = albumId;
        Artist = artist;
        Artists = artists;
        CoverArtId = coverArtId;
        Duration = duration;
        IsExplicit = isExplicit;
        ReplayGain = replayGain;
        Title = title;
    }
}
