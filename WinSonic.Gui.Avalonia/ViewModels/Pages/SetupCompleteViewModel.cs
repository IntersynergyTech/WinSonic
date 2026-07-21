using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class SetupCompleteViewModel : PageViewModelBase
{
    public override string Title { get; protected set; } = Strings._SetupCompleteTitle;
    public string Body { get; }  = Strings._SetupCompleteBody;
    public string LetsGoButtonText { get; } = Strings._LetsGo;
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
}
