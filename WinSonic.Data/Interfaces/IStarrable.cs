namespace WinSonic.Data.DbModels;

public interface IStarrable
{
    public DateTime? StarredAt { get; set; }
    public bool IsStarred
    {
        get => StarredAt.HasValue;
        set => StarredAt = DateTime.UtcNow;
    }
}
