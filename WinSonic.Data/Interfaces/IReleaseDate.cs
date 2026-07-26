using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public interface IReleaseDate
{
    public DateTime? ReleaseDate { get; set; }
    public ReleaseDateType? ReleaseDateType { get; set; }
    public int? Year => ReleaseDate?.Year;
}
