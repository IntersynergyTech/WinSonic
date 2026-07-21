using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Avalonia.ViewModels;

namespace WinSonic.Gui.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();  
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var model = (MainViewModel) this.DataContext;
        model.Initialize();
    }
}
