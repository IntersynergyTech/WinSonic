using System.ComponentModel.DataAnnotations;

namespace WinSonic.Data.DbModels;

public class DbPlayHistoryEntry
{
    [Key]
    public long Id { get; set; }
    [Required]
    public virtual DbSong Song { get; set; }
    public DateTime PlayedAt { get; set; }
    public bool Scrobbled { get; set; }
}
