using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class PlayerWindow : Window
{
    private PlayerWindowViewModel Context => (PlayerWindowViewModel) DataContext!;
    
    public PlayerWindow()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Context.OnLoaded();
    }
}

