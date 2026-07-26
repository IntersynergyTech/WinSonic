namespace WinSonic.Data.DbModels;

public interface IMediaFormat
{
    public int SampleRate { get; set; }
    public int BitDepth { get; set; }
    public int Bitrate { get; set; }
    public int ChannelCount { get; set; }
    public int Filesize { get; set; }
}
