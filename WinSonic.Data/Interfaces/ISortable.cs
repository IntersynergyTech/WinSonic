namespace WinSonic.Data.DbModels;

public interface ISortable
{
    public string Title { get; set; }
    public string? SortTitle { get; set; }
    public string SortableTitle => SortTitle ?? Title;
}
