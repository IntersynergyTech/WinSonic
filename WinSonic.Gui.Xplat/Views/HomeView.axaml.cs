using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class HomeView : ContentPage
{
    private HomeViewModel Context => (HomeViewModel)DataContext!;
    private HomeViewModel _localContext;
    
    public HomeView()
    {
        InitializeComponent();
    }

    private void SettingButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.Navigation != null)
        {
            Navigation.PushAsync(new Views.SettingsView() { DataContext = new SettingsViewModel() });
        }
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        _localContext = Context;
        _localContext?.OnLoaded();
    }
    
    private void Control_OnUnloaded(object? sender, RoutedEventArgs e)
    {
        _localContext?.OnUnloaded();
    }
}
