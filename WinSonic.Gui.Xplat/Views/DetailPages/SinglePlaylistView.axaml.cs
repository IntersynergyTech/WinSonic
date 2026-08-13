using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels.DetailPages;

namespace WinSonic.Gui.Xplat.Views.DetailPages;

public partial class SinglePlaylistView : UserControl
{
    public SinglePlaylistView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var context = (SinglePlaylistViewModel) DataContext;
        context!.OnLoaded();
    }
}

