using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using WinSonic.Core;
using WinSonic.Gui.Common;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels;
using WinSonic.Gui.Xplat.Misc;
using WinSonic.Gui.Xplat.Views;
using Path = System.IO.Path;

namespace WinSonic.Gui.Xplat;

public partial class App : Application
{
    public override void Initialize()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
            .WriteTo.Debug(restrictedToMinimumLevel: LogEventLevel.Verbose)
            .WriteTo.File(
                Path.Combine(new StorageManager().GetLogsDirectory(), "log.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                restrictedToMinimumLevel: LogEventLevel.Warning
            )
            .CreateLogger();

        Log.Information("Starting WinSonic");

        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDeveloperTools();
#endif
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //Setup global exception handlers
        Dispatcher.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddCommonGuiServices();
        collection.AddXplatServices();

        collection.AddSerilog();

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();

        services.InitialiseServices();

        DependencyService.Services = services;

        var vm = services.GetRequiredService<PlayerWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new PlayerWindow { DataContext = vm };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new PlayerWindow { DataContext = vm };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception;
        Log.Fatal(exception.ToString(), $"Unhandled domain exception (terminating: {e.IsTerminating})");
    }

    private void TaskSchedulerOnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Log.Error(e.Exception.ToString(), "Unobserved task exception");

        // Prevent the exception from terminating the process
        e.SetObserved();
    }

    private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // Log the exception
        Log.Error(e.Exception.ToString(), "Unhandled UI thread exception");

        // Optionally prevent the application from crashing
        e.Handled = true;
    }
}
