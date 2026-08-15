using WinSonic.Core;
using WinSonic.Core.Models;
using Api = WinSonic.Subsonic.Client.Model;

namespace WinSonic.Subsonic.Helpers;

public static class SubsonicModelExtensions
{
    public static DateTime ToDateTime(this Api.ItemDate date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0,0,0);
        
    }

    
}
