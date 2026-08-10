using Avalonia.Controls;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class HomeView : ContentPage
{
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
    
}
