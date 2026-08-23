using System;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;

namespace WinSonic.Gui.Xplat.Mac;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        App.ConfigurePlatformSpecificServices = ConfigureMacPlatformServices;
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    private static void ConfigureMacPlatformServices(IServiceCollection services)
    {
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont().LogToTrace();
}
