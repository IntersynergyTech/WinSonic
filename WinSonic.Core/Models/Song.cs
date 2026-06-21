namespace WinSonic.Core.Models;

public class Song
{
    public string Id { get; }
    public string Album { get; }
    public string AlbumId { get; }

    public string Artist { get; }
    public Artist[] Artists { get; }

    public string CoverArtId { get; }

    public bool IsExplicit { get; }
    
    public ReplayGain ReplayGain { get; }


    public Song(string id, string album,
        string albumId,
        string artist,
        Artist[] artists,
        string coverArtId,
        bool isExplicit,
        ReplayGain replayGain
    )
    {
        Id = id;
        Album = album;
        AlbumId = albumId;
        Artist = artist;
        Artists = artists;
        CoverArtId = coverArtId;
        IsExplicit = isExplicit;
        ReplayGain = replayGain;
    }
}
