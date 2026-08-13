using Avalonia;
using Avalonia.Controls;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class MainView : NavigationPage
{
    public MainView()
    {
        InitializeComponent();
    }

    private readonly ViewLocator _viewLocator = new ();

    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        
        if (CurrentPage == null) NavigationService.NavigateTo(new HomeViewModel());
    }
}
