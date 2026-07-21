using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class LandingPageViewModel : PageViewModelBase
{
    public override string Title { get; protected set; } = Strings._LandingTitle;
    public override bool CanNavigateNext { get; protected set; } = true;
    public override bool CanNavigatePrevious { get; protected set; } = false;

    public string SettingsButtonText => Strings._Settings;
    
    
}
