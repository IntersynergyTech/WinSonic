using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.Sync;
using WinSonic.Gui.Common;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels;
using WinSonic.Gui.Xplat.Misc;
using WinSonic.Gui.Xplat.Views;
using Path = System.IO.Path;

namespace WinSonic.Gui.Xplat;

public partial class App : Application
{
    public static Action<IServiceCollection>? ConfigurePlatformSpecificServices { get; set; }
    
    public override void Initialize()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
#if DEBUG
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
#endif
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .Enrich.WithComputed("SourceContextName", "Substring(SourceContext, LastIndexOf(SourceContext, '.') + 1)")
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Verbose, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} T{ThreadId} {SourceContextName}] {Message:lj}{NewLine}{Exception}")
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

        ConfigurePlatformSpecificServices?.Invoke(collection);

        collection.AddSerilog();

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();

        services.InitialiseServices();

        DependencyService.Services = services;

        var playerWindowViewModel = services.GetRequiredService<PlayerWindowViewModel>();
        var hasSettings = services.GetRequiredService<BaseDataContext>().Settings.AnyAsync().GetAwaiter().GetResult();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (hasSettings)
            {
                desktop.MainWindow = new PlayerWindow { DataContext = playerWindowViewModel };
                return;
            }

            var wizardViewModel = services.GetRequiredService<SettingsWizardViewModel>();
            var wizardWindow = new SettingsWizardWindow { DataContext = wizardViewModel };

            wizardViewModel.RequestCloseAsync += async () =>
            {
                var syncManager = services.GetRequiredService<SyncManager>();
                var progressWindow = new SyncProgressWindow();
                progressWindow.Show();

                try
                {
                    await syncManager.StartBigSyncAsync();
                }
                finally
                {
                    progressWindow.Close();
                }

                var nextWindow = new PlayerWindow { DataContext = services.GetRequiredService<PlayerWindowViewModel>() };
                if (desktop.MainWindow == wizardWindow)
                {
                    desktop.MainWindow = nextWindow;
                }

                wizardWindow.Close();
            };

            desktop.MainWindow = wizardWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new PlayerWindow { DataContext = playerWindowViewModel };
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
