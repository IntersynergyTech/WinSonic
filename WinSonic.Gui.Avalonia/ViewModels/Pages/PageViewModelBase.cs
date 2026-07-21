namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract string Title { get; protected set; }
    
    public abstract bool CanNavigateNext { get; protected set; }
    
    public abstract bool CanNavigatePrevious { get; protected set; }
}
