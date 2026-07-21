namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class HomePageViewModel : PageViewModelBase
{
    public override string Title { get; protected set; } = "Home";
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
}
