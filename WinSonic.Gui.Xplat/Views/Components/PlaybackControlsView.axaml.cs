using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using WinSonic.Gui.Common.ViewModels.Components;

namespace WinSonic.Gui.Xplat.Views.Components;

public partial class PlaybackControlsView : UserControl
{
    private PlaybackControlsViewModel Context => (PlaybackControlsViewModel) DataContext!;
    
    public PlaybackControlsView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Context.Init();
    }
}

