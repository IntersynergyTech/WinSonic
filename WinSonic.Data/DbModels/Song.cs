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
    public virtual Album? Album { get; set; }

    public int? Track { get; set; }

    public virtual CoverArt? CoverArt { get; set; }

    public string? Genre { get; set; }

    public int? Bpm { get; set; }
    public string? Comment { get; set; }
    public string? SortTitle { get; set; }
    public int? Duration { get; set; }
    public bool IsExplicit { get; set; }

    public virtual Artist? Artist { get; set; }
    
    public virtual ICollection<Artist>? Artists { get; set; }
    public virtual ICollection<Artist>? AlbumArtists { get; set; }
    public virtual ICollection<Playlist>? AppearsInPlaylists { get; set; }

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

    public virtual ICollection<LocalCacheEntries.CachedSong> LocalCacheEntries { get; set; }

    public decimal? RgTrackGain { get; set; }
    public decimal? RgAlbumGain { get; set; }
    public decimal? RgTrackPeak { get; set; }
    public decimal? RgAlbumPeak { get; set; }
    
}
