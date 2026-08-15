using System;
using System.Globalization;
using Avalonia.Data.Converters;
using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Xplat.Misc.Converters;

public class TimecodeToApproximateTextConverter : IValueConverter
{
    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var time = (TimeSpan) value;
        
        var hours = time.Hours;
        var minutes = time.Minutes;
        
        var minutesOnly = hours == 0;
        
        var minsPlaceholder = minutes > 1 ? Strings._MinsWordy : Strings._MinWordy;
        var minsText = minsPlaceholder.Replace("{{mins}}", minutes.ToString());
        
        if (minutesOnly)
        {
            return minsText;
        }
        
        var hoursPlaceholder = hours > 1 ? Strings._HoursWordy : Strings._HourWordy;
        var hoursText = hoursPlaceholder.Replace("{{hours}}", hours.ToString());
        
        var totalText = Strings._HoursMinsWordyText.Replace("{{hours}}", hoursText).Replace("{{mins}}", minsText);
        return totalText;

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
