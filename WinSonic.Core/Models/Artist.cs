namespace WinSonic.Core.Models;

public class Artist
{
    public string Id { get; }
    public string Name { get; }
    public string SortName { get;}
    
    public Artist(string id, string name, string sortName)
    {
        Id = id;
        Name = name;
        SortName = sortName;
    }
}
