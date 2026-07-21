using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using WinSonic.Gui.Avalonia.ViewModels;
using WinSonic.Gui.Avalonia.Views;

namespace WinSonic.Gui.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private readonly bool _firstRunComplete = true;
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (_firstRunComplete)
            {
                desktop.MainWindow = new MainWindow { DataContext = new MainViewModel(), };
            }
            else
            {
                desktop.MainWindow = new SetupWizard { DataContext = new SetupWizardViewModel(), };
            }
            
        }

        base.OnFrameworkInitializationCompleted();
    }
}
