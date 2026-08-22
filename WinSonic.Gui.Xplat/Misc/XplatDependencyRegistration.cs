using Microsoft.Extensions.DependencyInjection;
using WinSonic.Service.SecureData;

namespace WinSonic.Gui.Xplat.Misc;

public static class XplatDependencyRegistration
{
    public static void AddXplatServices(this IServiceCollection services)
    {
        services.AddSingleton<ISecureDataService, Platform.XplatSecureDataService>();
    }
    
}
