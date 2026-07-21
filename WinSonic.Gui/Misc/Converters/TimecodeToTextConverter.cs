using System.Globalization;
using System.Windows.Data;

namespace WinSonic.Gui.Misc.Converters;

public class TimecodeToTextConverter : IValueConverter
{
    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var incoming = (TimeSpan?) value;

        if (!incoming.HasValue) return "--:--";

        if (incoming?.TotalMinutes > 60)
        {
            return incoming?.ToString(@"hh\:mm\:ss");
        }

        return incoming?.ToString(@"mm\:ss");
    }

    public object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        throw new NotImplementedException();
    }
}
