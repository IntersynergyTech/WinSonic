using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels.DetailPages;

namespace WinSonic.Gui.Xplat.Views.DetailPages;

public partial class SingleAlbumView : UserControl
{
    public SingleAlbumView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var context = (SingleAlbumViewModel)DataContext!;
        context.OnLoaded();
    }
}
