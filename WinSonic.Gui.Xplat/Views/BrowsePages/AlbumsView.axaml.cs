using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using WinSonic.Gui.Common.ViewModels.BrowsePages;

namespace WinSonic.Gui.Xplat.Views.BrowsePages;

public partial class AlbumsView : ContentPage
{
    private AlbumsViewModel Context => (AlbumsViewModel)DataContext!;

    public AlbumsView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Context.OnLoaded();
    }
}
