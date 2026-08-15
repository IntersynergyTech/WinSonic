using System.ComponentModel.DataAnnotations;
using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class DbPlayQueueEntry
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public int OrderIndex { get; set; }
    [Required]
    public PlayQueueEntryType Type { get; set; }
    [Required]
    public virtual DbSong Song { get; set; }
}
