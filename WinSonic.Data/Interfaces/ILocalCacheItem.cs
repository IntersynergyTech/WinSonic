namespace WinSonic.Data.DbModels;

public interface ILocalCacheItem<TCacheable>
{
    public Guid Id { get; set; }
    public string Filename { get; set; }
    public TCacheable ParentItem { get; set; }
}
