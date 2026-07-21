using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class TestPageViewModel : PageViewModelBase
{
    public TestPageViewModel()
    {
        
    }
    public override string Title { get; protected set; } = "test page";
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
}
