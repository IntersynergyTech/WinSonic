using Microsoft.Extensions.DependencyInjection;

namespace WinSonic.Gui.Pages;

public static class PageConfiguration
{
    public static void ConfigurePages(this IServiceCollection services)
    {
        // real pages
        services.AddScoped<SettingsPage>();
        services.AddScoped<TestPage>();
        services.AddScoped<ConsolePage>();
        services.AddScoped<ServiceTest>();
        
        services.AddScoped<PlaylistPage>();
        
        //nav stubs
    }
}
