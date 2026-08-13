using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels.BrowsePages;

namespace WinSonic.Gui.Xplat.Views.BrowsePages;

public partial class PlaylistsView : ContentPage
{
    private PlaylistsViewModel Context => (PlaylistsViewModel) DataContext!;

    

    public PlaylistsView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Context.OnLoaded();
    }
}
