namespace WinSonic.Data.DbModels;

public interface IRateable
{
    public int? Rating { get; set; }
    public bool HasRating => Rating != null;
}
