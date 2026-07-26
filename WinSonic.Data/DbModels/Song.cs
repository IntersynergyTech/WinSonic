using System.ComponentModel.DataAnnotations;
using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class Song: ICacheableEntity, IReleaseDate, IRateable, IStarrable, IMediaFormat, ISortable
{
    [Key]
    public string Id { get; set; }

    public string Title { get; set; }

    public string? DisplayArtist { get; set; }
    public string? DisplayAlbumArtist { get; set; }
    public Album? Album { get; set; }
    public Artist? Artist { get; set; }

    public int? Track { get; set; }

    public CoverArt? CoverArt { get; set; }

    public string? Genre { get; set; }

    public int? Bpm { get; set; }
    public string? Comment { get; set; }
    public string? SortTitle { get; set; }
    
    
    public ICollection<Artist>? Artists { get; set; }
    public ICollection<Artist>? AlbumArtists { get; set; }

    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public ReleaseDateType? ReleaseDateType { get; set; }
    public int? Rating { get; set; }
    public DateTime? StarredAt { get; set; }
    public int SampleRate { get; set; }
    public int BitDepth { get; set; }
    public int Bitrate { get; set; }
    public int ChannelCount { get; set; }
    public int Filesize { get; set; }
}
