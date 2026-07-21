
using ReactiveUI.Fody.Helpers;
using WinSonic.Gui.Avalonia.Models;
using WinSonic.Gui.Avalonia.ViewModels.Pages;

namespace WinSonic.Gui.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private GlobalContext _globalContext = new GlobalContext();

    public void Initialize()
    {
        CurrentPage = new LoadingViewModel(_globalContext);
    }   

    [Reactive]
    public ContextViewModelBase CurrentPage { get; set; }
}
