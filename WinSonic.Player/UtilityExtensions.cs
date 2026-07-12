using SoundFlow.Structs;

namespace WinSonic.Player;

public static class UtilityExtensions
{
    public static string ToShortString(this AudioFormat format)
    {
        return $"{format.Channels}C {format.Format} {(format.SampleRate/1000d)}kHz {format.Layout}";
    }
}
