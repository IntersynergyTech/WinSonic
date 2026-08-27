using WinSonic.Core;
using WinSonic.Core.Models;
using Api = WinSonic.Subsonic.Client.Model;

namespace WinSonic.Subsonic.Helpers;

public static class SubsonicModelExtensions
{
    public static DateTime? ToDateTime(this Api.ItemDate date)
    {
        if (date == null || (date.Year == 0 && date.Month == 0 && date.Day == 0))
        {
            return null;
        }
        if (date.Month == 0 || date.Day == 0)
        {
            return new DateTime(date.Year, 1, 1, 0,0,0);
        }
        
        return new DateTime(date.Year, date.Month, date.Day, 0,0,0);
        
    }

    
}
