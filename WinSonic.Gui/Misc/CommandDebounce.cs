using System.Diagnostics;

namespace WinSonic.Gui.Misc;

public class CommandDebouncer
{
    private long _thresholdTicks;
    private long _lastInvocation = 0;
    public CommandDebouncer(int thresholdMs)
    {
        _thresholdTicks = TimeSpan.FromMilliseconds(thresholdMs).Ticks;
    }

    public void MaybeInvoke(Action action)
    {
        var currentTime = DateTime.UtcNow.Ticks;
        var elapsedSince = currentTime - _lastInvocation;
        Debug.WriteLine($"DebouncCheck: Now: {currentTime} Prev: {_lastInvocation} Elapsed: {elapsedSince} ElapsedD1k: {elapsedSince / 1000}ms ElapsedTiemspan: {TimeSpan.FromTicks(elapsedSince).TotalMilliseconds}");
        if (elapsedSince > _thresholdTicks)
        {
            _lastInvocation = currentTime;
            action();
        }
        else
        {
            Debug.WriteLine($"Debounced as it's only been {(TimeSpan.FromTicks(elapsedSince).TotalMilliseconds)}ms");
        }
    }
}
