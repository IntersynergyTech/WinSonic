using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels.DetailPages;

namespace WinSonic.Gui.Xplat.Views.DetailPages;

public partial class SingleArtistView : UserControl
{
    public SingleArtistView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var context = (SingleArtistViewModel)DataContext!;
        context.OnLoaded();
    }
}
