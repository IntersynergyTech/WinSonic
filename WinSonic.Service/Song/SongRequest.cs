namespace WinSonic.Service.Song;

public class SongRequest
{
    public bool RequestOriginalSource { get; init; }
    public string? Format { get; init; }
    public int? MaxBitRate { get; init; }

    public static SongRequest OriginalSource() => new() { RequestOriginalSource = true };
}
